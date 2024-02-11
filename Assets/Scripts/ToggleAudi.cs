using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ToggleAudi : MonoBehaviour
{

    public GameObject sfx;
    public Toggle toggle;
    private void Update()
    {
        if (toggle.isOn)
        {  
           sfx.SetActive(true);
        }
        else 
        {
            sfx.SetActive(false);
        }
       
    }
    
}
