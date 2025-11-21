using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;
using UnityEngine.UI;



namespace Model
{
   

   internal enum ItemType
    {
        RawMaterial,
        Product
    }
    internal enum EndProductType
    {
       Slide,
       Star,
       Pentagon

    }

    [System.Serializable]
    internal struct WeldingPoints
    {
        public Transform startingPoint;
        public Transform endingPoint;
        public Transform[] weldingObjects;
    }
    internal enum Task_Type
    {
        First,
        Second,
        Third
    }

}