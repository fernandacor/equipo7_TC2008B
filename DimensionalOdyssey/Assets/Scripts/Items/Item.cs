using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {

	new public string name = "New Item";	// Name of the item
	public Sprite icon;				// Item icon
	public bool isDefaultItem = false;      // Is the item default wear?
	public bool stackable = true;

	// Called when the item is pressed in the inventory
	public virtual void Use ()
	{
		// Use the item
		// Something might happen
	}

	public void RemoveFromInventory ()
	{
		Inventory.instance.Remove(this);
	}
	
}
