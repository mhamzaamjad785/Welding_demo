using Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using View;



namespace Controller
{

    internal class PileController : MonoBehaviour
    {

        public List<Inventory> inventoryPrefabs;
        [SerializeField] List<ItemButton> itemButtons;
       

        private void OnEnable()
        {
            for (int i = 0; i < inventoryPrefabs.Count; i++)
            {
                Inventory temp = inventoryPrefabs[i];
                itemButtons[i].button.onClick.AddListener(
                    () =>
                    {
                       
                        temp.gameObject.SetActive(true);
                        GameManager.instance.stopPlayerSelection = true;
                        GameManager.instance.DisableAllPanel();
                        GameManager.instance.selectedInventory = temp;
                    }
                    );
            }
        }
       


        






    }
}