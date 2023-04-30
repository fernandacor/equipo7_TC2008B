using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject inventoryUI;
    
    [HideInInspector]public bool isInventoryOpen = false;//variable to check if the inventory is open or not

    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        inventoryUI.SetActive(false);
        gameManager = GameManager.instance;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            isInventoryOpen = inventoryUI.activeSelf;
            if (isInventoryOpen)
            {
                gameManager.SetGameState(GameState.AbrirInventario);
            }
            else
            {
                gameManager.SetGameState(GameState.Playing);
            }
        }
    }
}
