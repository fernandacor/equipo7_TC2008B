using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoPersonaje : MonoBehaviour
{
    [SerializeField] public float velocidadMovimiento;
    Vector2 movimiento;
    public Rigidbody2D rb2D;
    public Animator animator;
    public Camera cam;
    Vector2 mousePos;
    private GameObject cuartoActual;

    // // Start is called before the first frame update
    // void Start()
    // {
    //     //Look for the object
    //     objectToMove = GetComponent<Rigidbody2D>();
    // }

    void Update()
    {
        movimiento.x = Input.GetAxisRaw("Horizontal");
        movimiento.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Mathf.Abs(movimiento.x) > Mathf.Abs(movimiento.y))
        {
            movimiento.y = 0;
        }
        else
        {
            movimiento.x = 0;
        }

        animator.SetFloat("Horizontal", movimiento.x);
        animator.SetFloat("Vertical", movimiento.y);
        animator.SetFloat("Speed", movimiento.sqrMagnitude);
    }

    void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + movimiento * velocidadMovimiento * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb2D.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        //rb.rotation = angle;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CuartoScript cuartoScript;
        if (collision.tag == "Room")
        {
            cuartoActual = collision.gameObject;
            cuartoScript = cuartoActual.GetComponent<CuartoScript>();
            if (!cuartoScript.descubierto)
            {
                cuartoScript.descubierto = true;
                cuartoScript.CerrarCuarto();
            }
        }
        else if (collision.tag == "Boton")
        {
            cuartoScript = cuartoActual.GetComponent<CuartoScript>();
            cuartoScript.AbrirCuarto();
        }
    }
}
