using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera playerCamera;
    [SerializeField] float zoomInFOV = 15f;
    [SerializeField] float zoomOutFOV = 60f;
    
    [SerializeField] float zoomInSensitivity = .5f;
    [SerializeField] float zoomOutSensitivity = 2f;


    RigidbodyFirstPersonController fpsController;

    bool zoomInToggle = true;

    private void Start() 
    {
       fpsController = GetComponent<RigidbodyFirstPersonController>();    
    }

    // Teacher solution
    // Zoom & Mouse sensitivity - right mouse button press to toggle zoom in/out
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(zoomInToggle==false)
            {
                zoomInToggle = true;
                playerCamera.fieldOfView=zoomInFOV;
                fpsController.mouseLook.XSensitivity = zoomInSensitivity;
                fpsController.mouseLook.YSensitivity = zoomInSensitivity;
            }
            else
            {
                zoomInToggle = false; 
                playerCamera.fieldOfView=zoomOutFOV;
                fpsController.mouseLook.XSensitivity = zoomOutSensitivity;
                fpsController.mouseLook.YSensitivity = zoomOutSensitivity;
            }
        }
    }


    /* My solution to the Zoom - Hold down right mouse button
    void Update()
    {
        if(Input.GetButton("Fire2"))
        {
            ZoomIn();
        }
        else
        {
            ZoomOut();
        }
    }

    void ZoomIn()
    {
        playerCamera.fieldOfView=zoomInFOV;
    }

    void ZoomOut()
    {
        playerCamera.fieldOfView=zoomOutFOV;
    }
    */

}
