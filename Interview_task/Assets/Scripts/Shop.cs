using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; 

[CreateAssetMenu(fileName = "ShopItem", menuName = "ScriptableObjects/New Item", order = -1)]
public class Shop : ScriptableObject
{
    public string title;
    public string description;
    public int cost;
    
}
