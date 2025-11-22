using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    private TextMeshProUGUI text;
    private CanvasGroup canvasGroup;
   public static DialogueController instance;

    private void Awake()
    {
        if(instance==null)
            instance = this;
    }


    public void DisplayText(string dialogue)
    {
        if (text == null)
            text = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        if (canvasGroup == null)
            canvasGroup = GetComponent<CanvasGroup>();
        text.text = dialogue;
        canvasGroup.alpha = 1;

    }
    public void HideText()
    {
        if (canvasGroup == null)
            canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
    }






}
