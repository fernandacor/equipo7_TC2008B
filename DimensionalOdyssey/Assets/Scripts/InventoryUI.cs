using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject inventoryUI;
    
    //InventoryManager inventoryManager;
    
    // Start is called before the first frame update
    void Start()
    {
        //InventoryManager = InventoryManager.instance;
        //inventoryManager.onItemChangedCallback += UpdateUI;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    
    }

    void UpdateUI ()
    {
        Debug.Log("Updating UI");
    }
}
