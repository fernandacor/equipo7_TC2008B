using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    [SerializeField] InventoryManager.AllItems requiredItem;
    public bool canShoot = true;
    public GameObject shootingItem;
    public Transform shootingPoint;

    public bool hasRequiredItem(InventoryManager.AllItems itemRequired)
    {
        if(InventoryManager.Instance._inventoryItems.Contains(itemRequired))
        {
            Debug.Log("hasRequiredItem = true");
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Gun"))
        {
            if(hasRequiredItem(requiredItem) == true)
            {
                Debug.Log("Se tiene el elemento");
                canShoot = !canShoot;
                Debug.Log("canShoot = true");
            }
        }
    }

    void Shoot()
    {
        if(canShoot == false)
            return;

        GameObject disparable = Instantiate(shootingItem, shootingPoint);
        disparable.transform.parent = null;
    }

    private void Update()
    {
        if (canShoot == true)
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                Shoot();
            }
        }
    }
}
