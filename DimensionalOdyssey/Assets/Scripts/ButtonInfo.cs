using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonInfo : MonoBehaviour
{
    public int ItemID;
    public TMP_Text priceText;
    public TMP_Text quantitytText;
    public GameObject ShopManager;

    void Update()
    {
        priceText.text = "Price: $" + ShopManager.GetComponent<ShopManager>().shopItems[2, ItemID].ToString();
        quantitytText.text = ShopManager.GetComponent<ShopManager>().shopItems[3, ItemID].ToString();
    }
}
