using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] public Camera FPCamera;
    [SerializeField] RigidbodyFirstPersonController FPSController;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFOV = 15f;
    [SerializeField] float zoomedInMouseSensitivity = 2.0f;
    [SerializeField] float zoomedOutMouseSensitivity = 2.0f;
    //RigidbodyFirstPersonController FPSController;
    [SerializeField] Canvas zoomReticle;

    bool isZoomedIn = false;

    private void Start()
    {
        zoomReticle.enabled = false;
    }


    private void OnDisable()
    {
        ZoomOut(); //????????????
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && zoomedInFOV <=40)
        {
            if(isZoomedIn == false)
            {
                ZoomIn();
            }

            else   //????????????????????????????
            {
                ZoomOut();
            }
        }      
    }

    private void ZoomOut()
    {
        isZoomedIn = false;
        FPCamera.fieldOfView = zoomedOutFOV;
        FPSController.mouseLook.XSensitivity = zoomedOutMouseSensitivity;
        FPSController.mouseLook.YSensitivity = zoomedOutMouseSensitivity;
        //zoomReticle.enabled = false;
        if (zoomReticle != null)
        {
            zoomReticle.enabled = false;
        }
    }

    private void ZoomIn()
    {
        isZoomedIn = true;
        FPCamera.fieldOfView = zoomedInFOV;
        FPSController.mouseLook.XSensitivity = zoomedInMouseSensitivity;
        FPSController.mouseLook.YSensitivity = zoomedInMouseSensitivity;
        if(zoomReticle != null)
        {
            zoomReticle.enabled = true;
        }

    }
}
