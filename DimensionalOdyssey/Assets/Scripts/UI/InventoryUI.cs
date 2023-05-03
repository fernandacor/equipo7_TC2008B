using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject inventoryUI;
    private PlayerInput playerInput;
    
    [HideInInspector]public bool isInventoryOpen = false;//variable to check if the inventory is open or not

    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        inventoryUI.SetActive(false);
        gameManager = GameManager.instance;
        playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        playerInput.actions["SwitchMap"].performed += SwitchActionMap;
    }

    private void SwitchActionMap(InputAction.CallbackContext context){
        playerInput.SwitchCurrentActionMap("Inventory");
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
                playerInput.SwitchCurrentActionMap("Inventory");
            }
            else
            {
                gameManager.SetGameState(GameState.Playing);
            }
        }
    }
}
