using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoPersonaje : MonoBehaviour
{
    //Define direction, speed, and that the object is a RigidBody2D
    [SerializeField] public float velocidadMovimiento;
    Vector2 movimiento;
    public Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        //Look for the RB2D
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Input
        movimiento.x = Input.GetAxisRaw("Horizontal");
        movimiento.y = Input.GetAxisRaw("Vertical");

        Vector2 direccionMovimiento = new Vector2(movimiento.x, movimiento.y).normalized;
        //float inputMagnitude = Math.Clamp01(direccionMovimiento.magnitude);

        //transform.Translate(direccionMovimiento * velocidadMovimiento * inputMagnitude * Time.deltaTime);
    }

    void FixedUpdate()
    {
        //Movement
        rb2D.MovePosition(rb2D.position + movimiento * velocidadMovimiento * Time.fixedDeltaTime);
    }
}
