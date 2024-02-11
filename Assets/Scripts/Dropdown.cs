using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropdown : MonoBehaviour
{
    [SerializeField] CameraController cameraMain;
    public void DropdownSample(int index)
    {
        switch (index) 
        { 
            case 0:
                cameraMain.ChangeToWide();
                break;
            case 1:
                cameraMain.ChangeToMid();
                break;
            case 2:
                cameraMain.ChangeToClose();
                break;
            case 3:
                cameraMain.ChangeToOrtho();
                break;
            case 4:
                cameraMain.ChangeToDrone();
                break;
        }
    } 
}
