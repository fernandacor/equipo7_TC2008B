using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoPersonaje : MonoBehaviour
{

    // Mover al personaje
    private CharacterStats characterStats;
    private Vector2 movimiento;
    private PlayerInput playerInput;

    // Apuntar
    private GameObject firePoint;

    // Animación de movimiento
    private Animator playerAnimator;

    // Comportamiento de los cuartos
    private GameObject cuartoActual;

    private void Awake()
    {
        characterStats = GetComponent<CharacterStats>();
        playerAnimator = GetComponent<Animator>();
        firePoint = transform.Find("Fire Point").gameObject;
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        movimiento = playerInput.actions["Move"].ReadValue<Vector2>().normalized;

        playerAnimator.SetFloat("Horizontal", movimiento.x);
        playerAnimator.SetFloat("Vertical", movimiento.y);
        playerAnimator.SetFloat("Speed", movimiento.sqrMagnitude);
    }

    void FixedUpdate()
    {
        Rigidbody2D playerRB = GetComponent<Rigidbody2D>();
        playerRB.MovePosition(playerRB.position + movimiento * characterStats.velocidadMovimiento * Time.fixedDeltaTime);

        Renderer playerRenderer = GetComponent<Renderer>();
        if (movimiento.y > 0)
            firePoint.GetComponent<Renderer>().sortingOrder = playerRenderer.sortingOrder - 1;
        else
            firePoint.GetComponent<Renderer>().sortingOrder = playerRenderer.sortingOrder + 1;
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        CuartoScript cuartoScript;
        if (trigger.CompareTag("Room"))
        {
            cuartoActual = trigger.gameObject;
            cuartoScript = cuartoActual.GetComponent<CuartoScript>();
            if (!cuartoScript.descubierto)
            {
                cuartoScript.descubierto = true;
                cuartoScript.CerrarCuarto();
            }
        }
        else if (trigger.CompareTag("Boton"))
        {
            cuartoScript = cuartoActual.GetComponent<CuartoScript>();
            cuartoScript.AbrirCuarto();
        }
        else if (trigger.name == "Multishot Button")
        {
            firePoint.GetComponent<SpecialShot>().UseMultiShot(true, 4, 60);
        }
        else if (trigger.name == "Repeatshot Button")
        {
            firePoint.GetComponent<SpecialShot>().RepeatShot(3);
        }
        else if (trigger.name == "Powershot Button")
        {
            firePoint.GetComponent<SpecialShot>().PowerShot(100);
        }
    }
}
