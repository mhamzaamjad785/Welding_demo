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
        [SerializeField] Transform raycastView;
        Vector3 origin, direction;
        float distanceOfRay =200;
        [SerializeField] GameObject ActionView;
        Coroutine actionCoroutine;




        // Start is called before the first frame update
        void Start()
        {
            characterController = GetComponent<CharacterController>();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            
        }

        // Update is called once per frame
        void Update()
        {
            if(!ItemView.isPanelShow)
            {
                //  Movement();
                Detection();
                DoRotation();
            }

         
        }
        private void Movement()
        {
            float horizontalMovement = transform.position.x + Input.GetAxis("Horizontal") * Time.deltaTime * playerMovementSpeed;
            float verticalMovement = transform.position.z + Input.GetAxis("Vertical") * Time.deltaTime * playerMovementSpeed;
            if (Input.GetAxis("Horizontal") !=0  || Input.GetAxis("Vertical") != 0)
                characterController.Move(new Vector3(horizontalMovement, 0, verticalMovement));
        }
        private void DoRotation()
        {
            target.transform.localPosition = new Vector3(
                Mathf.Clamp(target.transform.localPosition.x + Input.GetAxis("Mouse X"), -4, 4),
                Mathf.Clamp(target.transform.localPosition.y + Input.GetAxis("Mouse Y"), -5.7f, 5.7f),
                target.transform.localPosition.z
                );
        }




        private void Detection()
        {

            origin = Camera.main.transform.position;
            direction = Camera.main.transform.forward;

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

        private Vector3 RaycastDirection()
        {
            raycastView.transform.position = Camera.main.WorldToScreenPoint(target.position);
            //targetPosition = Camera.main.transform.position + Vector3.forward * 100;
            return target.position- Camera.main.transform.position  ;
        }

        private void CheckIfSelectedHasItemView(RaycastHit hitInfo)
        {
            if(hitInfo.collider.TryGetComponent<ItemView>(out ItemView itemView))
            {
                ItemView.selectedItemView = itemView;
                itemView.ISelect?.Invoke();
                if(Input.GetKeyDown(KeyCode.A))
                {
                    itemView.IPanelOpen?.Invoke();
                    
                }
            }
            else
            {
                if(ItemView.selectedItemView!=null)
                {
                    ItemView.selectedItemView.IDeselect?.Invoke();
                   
                }
            }
        }

        public void ShowMessageItemView(string msg)
        {
            ActionView.SetActive(true);
            ActionView.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = msg;
        }
        




    }
}