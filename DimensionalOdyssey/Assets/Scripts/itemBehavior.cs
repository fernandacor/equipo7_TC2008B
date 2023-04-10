using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemBehavior : MonoBehaviour
{
    [SerializeField] InventoryManager.AllItems itemType;
    // public bool pickUp = false;

    // private void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.P)) //Pick something up
    //     {
    //         pickUp = true;
    //         Debug.Log("Pickup is true");
    //     }
    // }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            InventoryManager.Instance.AddItem(itemType);
            Debug.Log("Item added to inventory");
            Destroy(gameObject);
            Debug.Log("Item destroyed");
        }


    }

}
