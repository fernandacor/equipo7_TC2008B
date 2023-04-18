using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;
    public int[,] shopItems = new int[4, 4];
    public float currentCoins;
    public TMP_Text coinCounter;
    public int counter;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        coinCounter.text = counter.ToString();
        counter = 0;

        //IDS
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;

        //Prices
        shopItems[2, 1] = 10;
        shopItems[2, 2] = 20;
        shopItems[2, 3] = 30;
        shopItems[2, 4] = 40;

        //Quantities
        shopItems[3, 1] = 0;
        shopItems[3, 2] = 0;
        shopItems[3, 3] = 0;
        shopItems[3, 4] = 0;

    }

    public void AddCoins(int n)
    {
        counter += n;
        coinCounter.text = counter.ToString();
    }

    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Button").GetComponent<EventSystem>().currentSelectedGameObject;

        if (currentCoins >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID])
        {
            currentCoins -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];
            shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID] += 1;
            coinCounter.text = currentCoins.ToString();
            ButtonRef.GetComponent<ButtonInfo>().quantitytText.text = shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();
        }
    }
}
