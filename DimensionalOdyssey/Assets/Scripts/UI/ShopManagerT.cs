// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;

//public class ShopManagerT : MonoBehaviour
//{
//    int   coins = 100;
//    int quantity = 0;
//    public ShopItem[] shopItem;
//    public ShopTemplate[] shopPanel;
//    public GameObject[] shopPanelGO;
//    public Button[] myPurchaseBtn;

// public class ShopManagerT : MonoBehaviour
// {
//     public int coins=100;
//     public ShopItem[] shopItem;
//     public ShopTemplate[] shopPanel;
//     public GameObject[] shopPanelGO;
//     public Button[] myPurchaseBtn;

//     void Start()
//     {
//         for (int i = 0; i < shopItem.Length; i++){
//             shopPanelGO[i].SetActive(true);
//         }
//         LoadPanels();
//         CheckPurchasable();
//     }

//     void Update()
//     {
//         // code to update coin counter
//     }

//     public void CheckPurchasable(){
//     for (int i = 0; i < shopItem.Length; i++){
//         if (coins >= shopItem[i].basePrice)
//             myPurchaseBtn[i].interactable = true;
//         else
//             myPurchaseBtn[i].interactable = false;
//         }
//     }

//<<<<<<< HEAD
//    public void PurchaseItem(int btnNo){
//        if (coins >= shopItem[btnNo].basePrice){
//            coins -= shopItem[btnNo].basePrice;
//            //shopItem[btnNo].quantity++;
//            CheckPurchasable();
//       }
//    }
//=======

//     public void PurchaseItem(int btnNo){
//         if (coins >= shopItem[btnNo].basePrice){
//             coins -= shopItem[btnNo].basePrice;
//             shopItem[btnNo].quantity++;
//             CheckPurchasable();
//         }
//     }

//     public void LoadPanels()
//     {
//         for (int i = 0; i < shopItem.Length; i++)
//         {
//             shopPanel[i].titleText.text = shopItem[i].title;
//             shopPanel[i].priceText.text = shopItem[i].basePrice.ToString();
//         }
//     }
// }
