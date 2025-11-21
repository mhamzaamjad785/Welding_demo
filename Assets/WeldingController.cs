using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeldingController : MonoBehaviour
{
    
    private Vector3 StartPosition, EndPosition;
    float progress;

    public UnityAction OnStartWeldAction, OnCompleteWeldAction;


    public void UpdatePositions(Vector3 start, Vector3 end)
    {
        OnStartWeldAction?.Invoke();
        StartPosition = start;
        EndPosition = end;
    }


    public void ApplyWelding(float value)
    {
        progress = Mathf.Clamp01(value);
        transform.position = Vector3.Lerp(StartPosition, EndPosition, value);
        if(progress==1)
        {
            OnCompleteWeldAction?.Invoke();
        }

    }

}
