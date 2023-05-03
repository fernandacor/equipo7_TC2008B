using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoPersonaje : MonoBehaviour
{

    // Mover al personaje
    private CharacterStats characterStats;
    private Vector2 movimiento;
    [HideInInspector] public PlayerInput playerInput;

    // Apuntar
    private GameObject firePoint;

    // Animación de movimiento
    private Animator playerAnimator;

    // Comportamiento de los cuartos
    private GameObject cuartoActual;

    // Menú de pausa
    private PauseMenuScript pauseMenu;

    // Interfaz inventario
    private InventoryUI inventoryUI;

    // Game manager
    private GameManager gameManager;

    private void Awake()
    {
        // Se buscan los elementos necesarios
        characterStats = GetComponent<CharacterStats>(); // script de stats del jugador
        playerAnimator = GetComponent<Animator>(); // animador del personaje
        firePoint = transform.Find("Fire Point").gameObject; // punto de disparo
        playerInput = GetComponent<PlayerInput>(); // sistema de input
        pauseMenu = GameObject.Find("Canvas").GetComponent<PauseMenuScript>(); // menu de pausa
        inventoryUI = GameObject.Find("Canvas").GetComponent<InventoryUI>(); //interfaz de inventario
        gameManager = GameManager.instance; // game manager
    }

    void Update()
    {
        // Si el juego no está en pausa:
        if (!pauseMenu.gameIsPaused)
        {
            movimiento = playerInput.actions["Move"].ReadValue<Vector2>().normalized; // Se lee el input de movimiento

            // Si el jugador está en movimiento, se activa la animación de movimiento
            playerAnimator.SetFloat("Horizontal", movimiento.x);
            playerAnimator.SetFloat("Vertical", movimiento.y);
            playerAnimator.SetFloat("Speed", movimiento.sqrMagnitude);
        }
    }

    void FixedUpdate()
    {
        // Se busca el RigidBody del jugador y se le aplica la velocidad de movimiento
        Rigidbody2D playerRB = GetComponent<Rigidbody2D>();
        playerRB.MovePosition(playerRB.position + movimiento * characterStats.velocidadMovimiento * Time.fixedDeltaTime);

        // Se busca el renderer del punto de disparo y se le aplica una posición
        Renderer playerRenderer = GetComponent<Renderer>();
        if (movimiento.y > 0)
            firePoint.GetComponent<Renderer>().sortingOrder = playerRenderer.sortingOrder - 1;
        else
            firePoint.GetComponent<Renderer>().sortingOrder = playerRenderer.sortingOrder + 1;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        CuartoScript cuartoScript;
        if (collider.CompareTag("Room"))
        {
            cuartoActual = collider.gameObject;
            cuartoScript = cuartoActual.GetComponent<CuartoScript>();
            if (!cuartoScript.descubierto)
            {
                cuartoScript.descubierto = true;
                cuartoScript.CerrarCuarto();
            }
        }
        else if (collider.CompareTag("Boton"))
        {
            cuartoScript = cuartoActual.GetComponent<CuartoScript>();
            cuartoScript.AbrirCuarto();
        }
    }
}
