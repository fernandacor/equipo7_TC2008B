using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemBehavior : MonoBehaviour
{
    [SerializeField] InventoryManager.AllItems itemType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            InventoryManager.Instance.AddItem(itemType);
            Destroy(gameObject);
        }
    }
}
