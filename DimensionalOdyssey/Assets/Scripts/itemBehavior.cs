using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    [SerializeField] InventoryManager.AllItems itemType;
    public bool pickUp = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pickUp = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && pickUp == true)
        {
            InventoryManager.Instance.AddItem(itemType);
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pickUp = false;
        }
    }
}
