using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : MonoBehaviour
{
    public GameObject shopUI;
    private bool shopBool = false;

    public void Interact()
    {
        if (shopBool == false)
        {
            Time.timeScale = 0;
            shopUI.SetActive(true);
            shopBool = true;
        }
        else if (shopBool == true)
        {
            Time.timeScale = 1;
            shopUI.SetActive(false);
            shopBool = false;
        }
        
    }
    
}
