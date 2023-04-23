using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{

    // Mover al personaje
    public float velocidadMovimiento;
    private Vector2 movimiento;
    private Rigidbody2D playerRB;

    // Apuntar - Shooter
    private Vector2 mousePos;
    private Camera cam;
    private GameObject firePoint;
    private Renderer playerRenderer;

    // Animación
    private Animator playerAnimator;

    // Comportamiento de los cuartos
    private GameObject cuartoActual;

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerRenderer = GetComponent<Renderer>();
        playerAnimator = GetComponent<Animator>();
        firePoint = transform.Find("FirePoint").gameObject;
        cam = GameObject.Find("Main Camera").gameObject.GetComponent<Camera>();
    }

    void Update()
    {
        movimiento.x = Input.GetAxisRaw("Horizontal");
        movimiento.y = Input.GetAxisRaw("Vertical");
        movimiento = movimiento.normalized;

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        playerAnimator.SetFloat("Horizontal", movimiento.x);
        playerAnimator.SetFloat("Vertical", movimiento.y);
        playerAnimator.SetFloat("Speed", movimiento.sqrMagnitude);
    }

    void FixedUpdate()
    {
        playerRB.MovePosition(playerRB.position + movimiento * velocidadMovimiento * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - playerRB.position;
        firePoint.transform.position = playerRB.position + lookDir.normalized * transform.localScale.x * 0.6f;
        if (movimiento.y > 0)
            firePoint.GetComponent<Renderer>().sortingOrder = playerRenderer.sortingOrder - 1;
        else
            firePoint.GetComponent<Renderer>().sortingOrder = playerRenderer.sortingOrder + 1;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        if (angle <= 90 && angle >= -90)
            firePoint.transform.rotation = Quaternion.Euler(0, 0, angle);
        else
            firePoint.transform.rotation = Quaternion.Euler(180, 0, 360 - angle);
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
