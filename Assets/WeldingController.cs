using Controller;
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
        progress = 0;
        StartPosition = start;
        EndPosition = end;
    }


    public void ApplyWelding(float value)
    {
        value /= 10;
        progress = Mathf.Clamp01(progress+value);


        int totalObjects = (int)(progress * GameManager.instance.selectedInventory.weldingPoints[0].weldingObjects.Length);


        for (int i = 0; i < totalObjects; i++)
        {
            GameManager.instance.selectedInventory.weldingPoints[0].weldingObjects[i].gameObject.SetActive(true);
        }



        transform.position = Vector3.Lerp(StartPosition, EndPosition, progress);

        if(progress==1)
        {
            
            OnCompleteWeldAction?.Invoke();
        }

    }

}
