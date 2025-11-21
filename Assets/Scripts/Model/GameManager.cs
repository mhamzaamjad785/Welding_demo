using Controller;
using Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Controller
{

    internal class GameManager : MonoBehaviour
    {

        public GameObject PilePanel, InventoryPanel, DisplayAction;
        public bool stopPlayerSelection;
        public PlayerController playerController;
        public WeldingController welder;

        public PileController pileController;
        public InventoryController inventoryController;
        public  Inventory selectedInventory;
        public static GameManager instance;


        private bool runolyOnce;
        
        
        private void Awake()
        {
            instance = this;
        }

        private void OnEnable()
        {
            welder.OnStartWeldAction += OnStartWelding;
            welder.OnCompleteWeldAction += OnCompleteWelding;
        }



        public void DisableAllPanel()
        {
            PilePanel.SetActive(false);
            InventoryPanel.SetActive(false);
            DisplayAction.SetActive(false);
        }

        private void Update()
        {
            if (!stopPlayerSelection)
                return;

            if(!runolyOnce)
            {
                StartCoroutine(StartWelding());
            }
            else
            {
                if (Input.GetAxis("Mouse Y") != 0)
                {
                    welder.ApplyWelding(Input.GetAxis("Mouse Y"));
                }
            }

            
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
            stopPlayerSelection = false;
            runolyOnce = false;
            welder.gameObject.SetActive(false);

        }


    }
}