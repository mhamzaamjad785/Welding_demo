using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



namespace Controller
{

    internal abstract class GameTask : MonoBehaviour
    {
       
        public string[] Dialogues;
        public int currentDialogueIndex;
        public bool isTaskStarted { get; private set; }
        public bool isTaskCompleted { get; private set; }
        public UnityAction onTaskStarted,onTaskCompleted;
        public WeldingController weldingController;





        public virtual void Start()
        {
            weldingController = GetComponent<WeldingController>();
        }


        public virtual void OnEnable()
        {
            onTaskStarted+= TaskStarted;
            onTaskCompleted+= TaskCompleted;
        }
        public virtual void OnDisable()
        {
            onTaskStarted -= TaskStarted;
            onTaskCompleted -= TaskCompleted;
        }

        private void TaskStarted()
        {
            isTaskStarted = true;
           
        }
        private void TaskCompleted()
        {
            isTaskCompleted = true;
           
        }

        





    }
}