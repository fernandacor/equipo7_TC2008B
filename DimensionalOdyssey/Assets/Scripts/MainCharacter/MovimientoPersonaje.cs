using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{

    // Mover al personaje
    public CharacterStats characterStats;
    private Vector2 movimiento;
    private Rigidbody2D playerRB;

    // Apuntar
    private GameObject firePoint;
    private Renderer playerRenderer;

    // Animación
    private Animator playerAnimator;

    // Comportamiento de los cuartos
    private GameObject cuartoActual;

    private void Awake()
    {
        characterStats = GetComponent<CharacterStats>();
        playerRB = GetComponent<Rigidbody2D>();
        playerRenderer = GetComponent<Renderer>();
        playerAnimator = GetComponent<Animator>();
        firePoint = transform.Find("Fire Point").gameObject;
    }

    void Update()
    {
        movimiento.x = Input.GetAxisRaw("Horizontal");
        movimiento.y = Input.GetAxisRaw("Vertical");
        movimiento = movimiento.normalized;

        playerAnimator.SetFloat("Horizontal", movimiento.x);
        playerAnimator.SetFloat("Vertical", movimiento.y);
        playerAnimator.SetFloat("Speed", movimiento.sqrMagnitude);
    }

    void FixedUpdate()
    {
        playerRB.MovePosition(playerRB.position + movimiento * characterStats.velocidadMovimiento * Time.fixedDeltaTime);

        if (movimiento.y > 0)
            firePoint.GetComponent<Renderer>().sortingOrder = playerRenderer.sortingOrder - 1;
        else
            firePoint.GetComponent<Renderer>().sortingOrder = playerRenderer.sortingOrder + 1;
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        CuartoScript cuartoScript;
        if (trigger.tag == "Room")
        {
            cuartoActual = trigger.gameObject;
            cuartoScript = cuartoActual.GetComponent<CuartoScript>();
            if (!cuartoScript.descubierto)
            {
                cuartoScript.descubierto = true;
                cuartoScript.CerrarCuarto();
            }
        }
        else if (trigger.tag == "Boton")
        {
            cuartoScript = cuartoActual.GetComponent<CuartoScript>();
            cuartoScript.AbrirCuarto();
        }
    }
}
