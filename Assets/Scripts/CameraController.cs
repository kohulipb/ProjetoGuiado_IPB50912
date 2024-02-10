using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    private InputMaster input;
  

    [SerializeField] private Camera wide;
    [SerializeField] private Camera mid;
    [SerializeField] private Camera close;
    [SerializeField] private Camera ortho;
    [SerializeField] private Camera drone;


    private void Start()
       
    {

        input = new InputMaster();
        input.Enable();

        input.Cameras.changeToOrtho.started += ChangeToOrtho;
        input.Cameras.changeToClose.started += ChangeToClose;
        input.Cameras.changeToWide.started += ChangeToWide;
        input.Cameras.changeToMid.started += ChangeToMid;
        input.Cameras.changeToDrone.started += ChangeToDrone;
    }


    private void FixedUpdate()
    {
        
    }

    private void ChangeToOrtho(InputAction.CallbackContext context)
    {
        ortho.enabled = true;
        close.enabled = false;
        wide.enabled = false;
        mid.enabled = false;
        drone.enabled = false;
        Debug.Log("4");
    }
    private void ChangeToClose(InputAction.CallbackContext context)
    {
        close.enabled = true;
        wide.enabled = false; mid.enabled = false; drone.enabled = false; ortho.enabled = false;
        Debug.Log("3");
    }
    private void ChangeToWide(InputAction.CallbackContext context)
    {
        wide.enabled = true;
        mid.enabled = false; drone.enabled = false; ortho.enabled=false; close.enabled = false;
        Debug.Log("1");
    }
    private void ChangeToMid(InputAction.CallbackContext context)
    {
        mid.enabled = true;
        drone.enabled=false; ortho.enabled=false; close.enabled = false; wide.enabled = false;
        Debug.Log("2");
    }
    private void ChangeToDrone(InputAction.CallbackContext context)
    {
        drone.enabled = true;
        mid.enabled=false; ortho.enabled = false; close.enabled = false; wide.enabled = false;
        Debug.Log("5");
    }
}
