using Controller;
using Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using View;



namespace Controller
{

    internal class GameManager : MonoBehaviour
    {

        public List<GameTask> gameTasks;
        int currentTaskIndex;

        public GameObject PilePanel, InventoryPanel;
        public bool stopPlayerSelection;
       
        public PlayerController playerController;
        public WeldingController welder;
        public PileController pileController;
        public InventoryController inventoryController;
        public  Inventory selectedInventory;
        public static GameManager instance;
     
        private bool runolyOnce;
        public UnityAction NextTask;
        public List<UnityEngine.UI.Button> Gamebuttons;
        public ItemView pileView, inventoryView;

        
        private void Awake()
        {
            instance = this;
        }

        private void OnEnable()
        {
            welder.OnStartWeldAction += OnStartWelding;
            welder.OnCompleteWeldAction += OnCompleteWelding;
            NextTask+= NextTaskProceed;
        }



        private void Start()
        {
            StartCoroutine(IntroductionDialogues());
        }


        public void DisableAllPanel()
        {
            PilePanel.SetActive(false);
            InventoryPanel.SetActive(false);
           
        }

        private void Update()
        {
            //if (!stopPlayerSelection)
            //    return;

            //if(!runolyOnce)
            //{
            //    StartCoroutine(StartWelding());
            //}
            //else
            //{
            //    if (Input.GetAxis("Mouse Y") != 0)
            //    {
            //        welder.ApplyWelding(Input.GetAxis("Mouse Y"));
            //    }
            //}

            
        }

        public void MakeAllButtons_Noninteractable()
        {
            foreach (var button in Gamebuttons)
            {
                button.interactable = false;
            }
            pileView.GetComponent<BoxCollider>().enabled = false;
            inventoryView.GetComponent<BoxCollider>().enabled = false;
        }
        public void MakeAllButtons_interactable()
        {
            foreach (var button in Gamebuttons)
            {
                button.interactable = true;
            }
            pileView.GetComponent<BoxCollider>().enabled = true;
            inventoryView.GetComponent<BoxCollider>().enabled = true;
        }


        IEnumerator StartWelding()
        {
            welder.gameObject.SetActive(true);
            welder.UpdatePositions(selectedInventory.weldingPoints[0].startingPoint.position-Vector3.forward*0.5f - Vector3.up * 0.5f, selectedInventory.weldingPoints[0].endingPoint.position - Vector3.forward * 0.5f -Vector3.up*0.5f);
          
            yield return new WaitForSeconds(1);
            runolyOnce=true;

        }


        private void OnStartWelding()
        {

        }

        private void OnCompleteWelding()
        {
            for (int i = 0; i < GameManager.instance.selectedInventory.parts.Count; i++)
            {
                GameManager.instance.selectedInventory.parts[i].gameObject.SetActive(false);
            }
            GameManager.instance.selectedInventory.endResult.SetActive(true);
            

        }

        private IEnumerator IntroductionDialogues()
        {
            stopPlayerSelection = true;
            ShowText("Hi this is a Demo of welding Simulation");
            yield return new WaitForSeconds(2.5f);
            HideText();
            yield return new WaitForSeconds(2.5f);
            ShowText("In screen There is A and B mark which opne inventory and pile panel respectively");
            yield return new WaitForSeconds(2.5f);
            HideText();
            yield return new WaitForSeconds(2.5f);
            ShowText("Just move to mark and press mouse left button and it will open the panel");
            yield return new WaitForSeconds(2.5f);
            HideText();
            NextTaskProceed();
        }





        private void ShowText(string text)
        {
            DialogueController.instance.DisplayText(text);
            

        }
        private void HideText()
        {
            DialogueController.instance.HideText();
        }


        public void NextTaskProceed()
        {
            if (currentTaskIndex> gameTasks.Count-1)
            {
                Debug.Log("All Task Complete");
                return;
            }
            if (currentTaskIndex > 0)
                gameTasks[currentTaskIndex-1].gameObject.SetActive(false);
            gameTasks[currentTaskIndex].gameObject.SetActive(true);

            gameTasks[currentTaskIndex].onTaskStarted();
            
            runolyOnce = false;
            welder.gameObject.SetActive(false);
        }







    }
}