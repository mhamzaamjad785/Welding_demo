using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    internal class ItemButton : MonoBehaviour
    {
        public EndProductType endProductType;
        public ItemType itemType;
        [HideInInspector]public Button button;

        private void Awake()
        {
            button = GetComponent<Button>();
            button.interactable = false;
        }


    }
}