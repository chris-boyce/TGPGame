using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRot : MonoBehaviour
{
    public Camera mainCamera;
    private Vector3 pointToLook;

    public Transform player;

    [SerializeField] private GameObject turret;
    [SerializeField] private GameObject holoRedTurret;
    [SerializeField] private GameObject holoGreenTurret;
    private GameObject preview;
    private bool isPreview;
    private bool isSwapped = false;
    private Vector3 offSet;
    private Vector3 fallHeight;

    private float maxDistenceFromPlayer = 7.5f;


    private void Start()
    {
        offSet = new Vector3(0, 0.5f, 0);
        fallHeight = new Vector3(0, 10f, 0);
    }
    void Update()
    {
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition); //Set Ray from camera to player mouse
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero); 
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);
            transform.LookAt(new Vector3(pointToLook.x , transform.position.y , pointToLook.z));

        }

        if (Input.GetKeyUp(KeyCode.E) && isPreview == false)
        {
            //Makes a holoturret 
            preview = Instantiate(holoRedTurret, pointToLook , Quaternion.identity); 
            isPreview = true;

        }
        if(isPreview)
        {
            
            float distenceFromPlayer = Vector3.Distance(pointToLook, player.transform.position);
            preview.transform.position = pointToLook + offSet; // Makes HoloTurret Follow the mouse Pos ever frame

            if(distenceFromPlayer < maxDistenceFromPlayer)
            {
                TurnGreenTurret(); //Function To change color of Turret just once :)
                
                if (Input.GetMouseButtonDown(1))
                {
                    
                    Destroy(preview); //When Click Destroys HoloTurret
                    Instantiate(turret, pointToLook + fallHeight, Quaternion.identity); // Makes Real Turret
                    isPreview = false; //Disables The preview mode
                }
            }
            else
            {
                TurnRedTurret(); //Function To change color of Turret just once :)
            }
            
        }

        void TurnGreenTurret() 
        {
            if (!isSwapped)
            {
                Destroy(preview);
                preview = Instantiate(holoGreenTurret, pointToLook, Quaternion.identity); 
                isSwapped = true;
            }
        }
        void TurnRedTurret()
        {
            if (isSwapped)
            {
                Destroy(preview);
                preview = Instantiate(holoRedTurret, pointToLook, Quaternion.identity); 
                isSwapped = false;
            }


        }

        

    }

}


