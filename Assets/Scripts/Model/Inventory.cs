using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Model
{
    internal class Inventory : MonoBehaviour
    {

        [SerializeField] private List<GameObject> weldingObjects;
        
        public Transform startingPoint;
        public Transform endingPoint;
        int totalWeldingObjects;


        // Start is called before the first frame update
        void Start()
        {
            totalWeldingObjects = weldingObjects.Count;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void UpdateWeldingObjects(float value)
        {
            int objectsEnabled = (int)(totalWeldingObjects * value);

            for (int i = 0; i < objectsEnabled; i++)
            {
                weldingObjects[i].SetActive(true);
            }


        }

        



    }
}