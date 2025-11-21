using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace View
{
    internal class ItemView : MonoBehaviour
    {


        public static ItemView selectedItemView;

        public static bool isPanelShow = false;

        public UnityEvent ISelect, IDeselect, IPanelOpen, IPanelClose;

        public void OnEnablePanel()
        {
            isPanelShow = true;
        }
        public void OnDisablePanel()
        {
            isPanelShow = false;
        }



    }
}