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
        if(InventoryManager.Instance._inventoryItems.Contains(itemRequired))
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
        if (hasRequiredItem(requiredItem))
        {
            Debug.Log("Se activo el pasillo");
            pasillo.SetActive(true);
        }
    }
}
