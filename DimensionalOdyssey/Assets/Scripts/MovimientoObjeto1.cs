using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

<<<<<<< HEAD:DimensionalOdyssey/Assets/Scripts/MovimientoObjeto1.cs
public class MovimientoObjeto1 : MonoBehaviour
=======
public class movimientoObjeto : MonoBehaviour
>>>>>>> inventario:DimensionalOdyssey/Assets/Scripts/movimientoObjeto.cs
{
    //Define direction, speed, and that the object is a RigidBody2D
    public float velocidadMovimiento;
    private Vector2 movimiento;
    private Rigidbody2D objectToMove;
    private GameObject cuartoActual;

    // Start is called before the first frame update
    void Start()
    {
        //Look for the object
        objectToMove = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movimiento.x = Input.GetAxisRaw("Horizontal");
        movimiento.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        objectToMove.MovePosition(objectToMove.position + movimiento * velocidadMovimiento * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Room")
        {
            cuartoActual = collision.gameObject;
            CuartoScript cuartoScript = cuartoActual.GetComponent<CuartoScript>();
            if (!cuartoScript.descubierto)
            {
                cuartoScript.descubierto = true;
                cuartoScript.CerrarCuarto();
            }
        }
        else if (collision.tag == "Boton")
        {
            CuartoScript cuartoScript = cuartoActual.GetComponent<CuartoScript>();
            cuartoScript.AbrirCuarto();
        }

    }
}
