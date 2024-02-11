using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    private InputMaster input;
    private bool onDrone;

    [Header("Camera objects")]
    [SerializeField] private Camera wide;
    [SerializeField] private Camera mid;
    [SerializeField] private Camera close;
    [SerializeField] private Camera ortho;
    [SerializeField] private Camera drone;

    [Header("Drone options")]
    [SerializeField] private Rigidbody droneObj;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float moveSpeed;

    private Vector3 EulerAngleVelocity;
    private Vector3 deltaRotation;
    private float EulerValues;

    private void Start()
       
    {
        onDrone = false;
        input = new InputMaster();
        input.Enable();
        input.Drone.Disable();

        //input.Cameras.changeToOrtho.started += ChangeToOrtho;
        //input.Cameras.changeToClose.started += ChangeToClose;
        //input.Cameras.changeToWide.started += ChangeToWide;
        //input.Cameras.changeToMid.started += ChangeToMid;
        //input.Cameras.changeToDrone.started += ChangeToDrone;
    }


    private void Update()
    {
        if (input.Drone.enabled)
        {
            if (input.Drone.MoveBack.IsPressed())
            {
                droneObj.transform.Rotate(0, 0, -(rotationSpeed*Time.fixedDeltaTime));
                droneObj.AddRelativeForce(0,0,moveSpeed*Time.fixedUnscaledDeltaTime);
            }
            if (input.Drone.MoveFwrd.IsPressed())
            {
                droneObj.transform.Rotate(0, 0, rotationSpeed * Time.fixedDeltaTime);
                droneObj.AddRelativeForce(0, 0, moveSpeed * Time.fixedUnscaledDeltaTime);
            }
            if (input.Drone.MoveLeft.IsPressed())
            {
                droneObj.transform.Rotate(-(rotationSpeed * Time.fixedDeltaTime), 0, 0);
                droneObj.AddRelativeForce(moveSpeed * Time.fixedUnscaledDeltaTime, 0, 0);
            }
            if (input.Drone.MoveRight.IsPressed())
            {
                droneObj.transform.Rotate(rotationSpeed * Time.fixedDeltaTime,0 , 0);
                droneObj.AddRelativeForce(-1*moveSpeed * Time.fixedUnscaledDeltaTime, 0, 0);
            }
            if (input.Drone.ThrottleDown.IsPressed())
            {
                droneObj.AddRelativeForce(0, -1* moveSpeed * Time.fixedUnscaledDeltaTime, 0);
            }
            if (input.Drone.ThrottleUp.IsPressed())
            {
                droneObj.AddRelativeForce(0, moveSpeed * Time.fixedUnscaledDeltaTime, 0);
            }
            if (input.Drone.YawLeft.IsPressed())
            {
                droneObj.transform.Rotate(0, -(rotationSpeed * Time.fixedDeltaTime), 0);
            }
            if (input.Drone.YawRight.IsPressed())
            {
                droneObj.transform.Rotate(0, (rotationSpeed * Time.fixedDeltaTime), 0);
            }
        }
    }
    private void FixedUpdate()
    {
        droneObj.AddRelativeForce(0, -(droneObj.mass * Physics.gravity.y), 0);
    }
    public void ChangeToOrtho()
    {
        input.Drone.Disable();
        ortho.enabled = true;
        close.enabled = false;
        wide.enabled = false;
        mid.enabled = false;
        drone.enabled = false;
        onDrone = false;
        Debug.Log("4");
 
    }
    public void ChangeToClose()
    {
        input.Drone.Disable();
        onDrone = false;
        close.enabled = true;
        wide.enabled = false; mid.enabled = false; drone.enabled = false; ortho.enabled = false;
        Debug.Log("3");
  
    }
    public void ChangeToWide()
    {
        input.Drone.Disable();
        onDrone = false;
        wide.enabled = true;
        mid.enabled = false; drone.enabled = false; ortho.enabled=false; close.enabled = false;
        Debug.Log("1");

    }
    public void ChangeToMid()
    {
        input.Drone.Disable();
        onDrone = false;
        mid.enabled = true;
        drone.enabled=false; ortho.enabled=false; close.enabled = false; wide.enabled = false;
        Debug.Log("2");
    
    }
    public void ChangeToDrone()
    {
        input.Drone.Enable();
        drone.enabled = true;
        mid.enabled=false; ortho.enabled = false; close.enabled = false; wide.enabled = false;
        Debug.Log("5");
        onDrone = true;
    }

 
}
