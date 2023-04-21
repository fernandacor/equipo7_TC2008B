using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TiendaUI : MonoBehaviour
{
    private Transform container;
    private Transform shopItemTemplate;

    private void Awake()
    {
        container = transform.Find("container");
        shopItemTemplate = container.Find("shopItemTemplate");
        shopItemTemplate.gameObject.SetActive(false);
    }
    //     int index = 0;
    //     foreach (ShopItem shopItem in ShopItems.items)
    //     {
    //         index++;
    //         Transform shopItemTransform = Instantiate(shopItemTemplate, container);
    //         shopItemTransform.gameObject.SetActive(true);
    //         shopItemTransform.Find("nameText").GetComponent<Text>().text = shopItem.name;
    //         shopItemTransform.Find("priceText").GetComponent<Text>().text = shopItem.price.ToString();
    //         shopItemTransform.Find("buyButton").GetComponent<Button>().onClick.AddListener(() => OnBuyButtonClick(shopItem));
    //     }
    // }
}
