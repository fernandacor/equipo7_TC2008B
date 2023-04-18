using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pasilloToggle : MonoBehaviour
{
    [SerializeField] InventoryManager.AllItems requiredItem;
    public GameObject pasillo;

    void Start()
    {
        pasillo.SetActive(false);
    }
    
    public bool hasRequiredItem(InventoryManager.AllItems itemRequired)
    {
        if(InventoryManager.Instance != null && InventoryManager.Instance._inventoryItems.Contains(itemRequired))
        {
            Debug.Log("Tiene el item");
            return true;
        }
        else
        {
            return false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {      
            if (hasRequiredItem(requiredItem) == true)
            {
                Debug.Log("Se activo el pasillo");
                pasillo.SetActive(true);
            }
        }
    }
}
