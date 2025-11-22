using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using View;


namespace Controller
{

    internal class PlayerController : MonoBehaviour
    {
        [SerializeField]private float playerMovementSpeed=100;
        CharacterController characterController;
        [SerializeField]Transform target;
       
        Vector3 origin, direction;
        float distanceOfRay =200;
        
        Coroutine actionCoroutine;
       



        // Start is called before the first frame update
        void Start()
        {
            characterController = GetComponent<CharacterController>();
           
            
        }

        // Update is called once per frame
        void Update()
        {
            if(!ItemView.isPanelShow && !GameManager.instance.stopPlayerSelection)
            {
               
                Detection();
               
                    DoRotation();
            }

         
        }
      
        private void DoRotation()
        {
            
            target.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(
                Mathf.Clamp(Input.mousePosition.x, 0, Screen.width),
                Mathf.Clamp(Input.mousePosition.y, 0, Screen.height),
                Vector3.Distance(Camera.main.transform.position, target.transform.position)
                ));


           
        }




        private void Detection()
        {

            origin = Camera.main.transform.position;
          
            direction = (target.transform.position - Camera.main.transform.position).normalized;
           
            Ray ray = new Ray(origin, direction);
            if (Physics.Raycast(ray,out RaycastHit hitInfo, distanceOfRay))
            {
                if(hitInfo.collider!=null)
                    CheckIfSelectedHasItemView(hitInfo);
            }
            else
            {
              
            }

             Debug.DrawRay(origin, direction * distanceOfRay, Color.red);
        }

       

        private void CheckIfSelectedHasItemView(RaycastHit hitInfo)
        {
            if(hitInfo.collider.TryGetComponent<ItemView>(out ItemView itemView))
            {
                ItemView.selectedItemView = itemView;
               
                if(Input.GetMouseButtonDown(0))
                {
                    itemView.IPanelOpen?.Invoke();
                    
                }
            }
          
        }

      
        




    }
}