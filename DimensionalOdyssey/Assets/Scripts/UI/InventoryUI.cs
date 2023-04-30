using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject inventoryUI;
    
    public bool isInventoryOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        inventoryUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKey(KeyCode.Escape))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            isInventoryOpen = inventoryUI.activeSelf;
            if (isInventoryOpen)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    void Resume() // function to resume the game
    {
        Time.timeScale = 1f;
    }

    void Pause() // function to pause the game
    {
        Time.timeScale = 0f;
    }
}
