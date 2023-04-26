using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopMenu", menuName = "ShopMenu/ShopItem", order = 1))]
public class ShopItem : ScriptableObject
{
    public string title;
    public int basePrice;
}
