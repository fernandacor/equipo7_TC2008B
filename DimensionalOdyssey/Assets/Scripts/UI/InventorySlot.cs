using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;

    Item item;
    // Start is called before the first frame update
    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = newItem.icon;
        icon.enabled = true;
        // removeButton.interactable = true;
    }

    // Update is called once per frame
   public void ClearSlot(){
        item = null;

        icon.sprite = null;
        icon.enabled = false;
    }

    // public void OnRemoveButton(){
    //     Inventory.instance.Remove(item);
    // }
}
