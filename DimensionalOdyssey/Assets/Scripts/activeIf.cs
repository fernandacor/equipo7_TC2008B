using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activeIf : MonoBehaviour
{
    [SerializeField] InventoryManager.AllItems requiredItem;
    public GameObject loQueSeActiva;

    void Start()
    {
        loQueSeActiva.SetActive(false);
        Debug.Log("Tienda invisible");
    }

    public bool hasRequiredItem(InventoryManager.AllItems itemRequired)
    {
        if(InventoryManager.Instance._inventoryItems.Contains(itemRequired))
        {
            Debug.Log("Tienes el item");
            return true;
        }
        else
        {
            return false;
        }
    }

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if(collision.gameObject.tag == "Player")
    //     {
    //         Debug.Log("Player en trigger");

    //         if(InventoryManager.Instance._inventoryItems.Contains(requiredItem))
    //         {
    //             Debug.Log("Tienes el item");
    //             loQueSeActiva.SetActive(true);
    //             Debug.Log("Tienda visible");
    //         }
    //     }
    // }

    private bool checkItem()
    {
        if (hasRequiredItem(requiredItem) == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void Update()
    {
        if (checkItem() == true)
        {
            loQueSeActiva.SetActive(true);
            Debug.Log("Tienda visible");
        }
    }
}
