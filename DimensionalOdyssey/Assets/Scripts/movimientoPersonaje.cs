using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoPersonaje : MonoBehaviour
{
    //Define direction, speed, and that the object is a RigidBody2D
    [SerializeField] public Vector2 direccion;
    [SerializeField] public float velocidadMovimiento;
    Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        //Look for the RB2D
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direccion = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + direccion * velocidadMovimiento * Time.fixedDeltaTime);
    }
}
