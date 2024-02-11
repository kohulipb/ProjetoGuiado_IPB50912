using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ToggleVFX : MonoBehaviour
{

    public List<GameObject> vfx;
    public Toggle toggle;
    private void Update()
    {
        if (toggle.isOn)
        {
            foreach (GameObject child in vfx) 
            {
                child.SetActive(true);
            }
        }
        else 
        { 
            foreach (GameObject child in vfx)
            {
                child.SetActive(false);
            }
        }
       
    }
    
}
