using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using View;



namespace Controller
{

    internal class SliderTask : GameTask
    {

       
        public Button  sliderButton;
        public ItemView pileView;



        public override void Start()
        {
            base.Start();
        
        }

        public override void OnEnable()
        {
            base.OnEnable();
            onTaskStarted += IntroductoryMethod;
        }
        public override void OnDisable()
        {
            base.OnDisable();
            onTaskStarted -= IntroductoryMethod;
        }


        private void IntroductoryMethod()
        { 
            StartCoroutine(Introductory());


        }
        IEnumerator Introductory()
        {
            DialogueController.instance.DisplayText(Dialogues[0]);
            yield return new WaitForSeconds(2.5f);
            DialogueController.instance.DisplayText(Dialogues[1]);
            GameManager.instance.stopPlayerSelection = false;
            GameManager.instance.MakeAllButtons_Noninteractable();
            pileView.GetComponent<BoxCollider>().enabled = true;
        }



    }
}