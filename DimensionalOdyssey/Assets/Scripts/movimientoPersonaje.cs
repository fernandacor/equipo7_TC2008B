using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoPersonaje : MonoBehaviour
{
    [SerializeField] public float velocidadMovimiento;
    Vector2 movimiento;
    public Rigidbody2D rb2D;
    public Animator animator;

    void Update()
    {
        movimiento.x = Input.GetAxisRaw("Horizontal");
        movimiento.y = Input.GetAxisRaw("Vertical");

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
    }
}
