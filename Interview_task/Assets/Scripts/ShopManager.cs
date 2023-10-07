using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ShopManager : MonoBehaviour
{
    public int treats;
    public TMP_Text treatsUI;
    public Shop[] shopItems;
    public ShopSOs[] shopPanels;
    public GameObject[] panelsSO;
    public Button[] purchaseButtons;
    

    private void Start()
    {
        for (int i = 0; i < shopItems.Length; i++)
        {
            panelsSO[i].SetActive(true);
        }
        treatsUI.text = "Treats: " + treats.ToString();
        LoadPanels();
        IsPurchasable();
    }

    


    public void IsPurchasable()
    {
        for (int i = 0; i < shopItems.Length; i++)
        {
            if (treats >= shopItems[i].cost)
                purchaseButtons[i].interactable = true;
            else
                purchaseButtons[i].interactable = false;
        }
    }

    public void GetTreats()
    {
        treats++;
        treatsUI.text = "Treats: " + treats.ToString();
        IsPurchasable();
    }

    public void PurchaseItem(int btnNumber)
    {
        if (treats >= shopItems[btnNumber].cost)
        {
            treats -= shopItems[btnNumber].cost;
            treatsUI.text = "Treats: " + treats.ToString();
            IsPurchasable();
        }
    }

    public void LoadPanels()
    {
        for (int i = 0; i < shopItems.Length; i++)
        {
            shopPanels[i].titleText.text = shopItems[i].title;
            shopPanels[i].descriptionText.text = shopItems[i].description;
            shopPanels[i].costText.text = "Treats: " + shopItems[i].cost.ToString();
        }
    }
}