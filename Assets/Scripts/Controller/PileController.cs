using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PileController : MonoBehaviour
{
    public List<Button> itemButtons;
    
    public void EnableFirstTaskTiles()
    {
        DisableAllButtons();
        itemButtons[0].interactable = true;
        itemButtons[1].interactable = true;
    }
    public void EnableSecondTaskTiles()
    {
        DisableAllButtons();
        itemButtons[2].interactable = true;
        itemButtons[3].interactable = true;
    }

    public void EnableThirdTaskTiles()
    {
        DisableAllButtons();
        itemButtons[4].interactable = true;
        itemButtons[5].interactable = true;
        itemButtons[6].interactable = true;

    }








    private void DisableAllButtons()
    {
        foreach (var button in itemButtons)
        {
            button.interactable = false;
        }
    }

}
