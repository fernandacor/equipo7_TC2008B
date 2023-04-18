using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    [SerializeField] InventoryManager.AllItems requiredItem;
    public bool isDoorOpen = false;
    public bool doorHorizontal = false;
    public bool doorVertical = false;
    Vector3 doorClosedPos;
    Vector3 doorOpenPos;
    float doorOpenSpeed = 10f;

    void Awake()
    {
        doorClosedPos = transform.position;
        if (doorHorizontal == true)
        {
            doorOpenPos = new Vector3(transform.position.x + 9f, transform.position.y, transform.position.z);
        }
        else if (doorVertical == true)
        {
            doorOpenPos = new Vector3(transform.position.x, transform.position.y + 9f, transform.position.z);
        }
    }

    void OpenDoor()
    {
        if (transform.position != doorOpenPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, doorOpenPos, doorOpenSpeed * Time.deltaTime);
        }

    }

    void CloseDoor()
    {
        if (transform.position != doorClosedPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, doorClosedPos, doorOpenSpeed * Time.deltaTime);
        }
    }

    public bool HasRequiredItem(InventoryManager.AllItems itemRequired)
    {
        if (InventoryManager.Instance._inventoryItems.Contains(itemRequired))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (HasRequiredItem(requiredItem) == true)
            {
                isDoorOpen = !isDoorOpen;
            }
        }
    }

    public void Update()
    {
        if (isDoorOpen)
        {
            OpenDoor();
        }
        else
        {
            CloseDoor();
        }
    }
}
