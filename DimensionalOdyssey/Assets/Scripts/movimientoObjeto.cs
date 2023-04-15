using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class movimientoObjeto : MonoBehaviour
{
    //Define direction, speed, and that the object is a RigidBody2D
    public float velocidadMovimiento;
    private Vector2 movimiento;
    private Rigidbody2D objectToMove;
    private Vector2 enterPositionInTrigger = Vector2.zero;
    public GameObject cuartoActual;
    public TileBase paredDerecha;

    // Start is called before the first frame update
    void Start()
    {
        //Look for the object
        objectToMove = GetComponent<Rigidbody2D>();
        // cuarto.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Input
        movimiento.x = Input.GetAxisRaw("Horizontal");
        movimiento.y = Input.GetAxisRaw("Vertical");

        // Vector2 direccionMovimiento = new Vector2(movimiento.x, movimiento.y).normalized;
        // Tilemap cuarto = GameObject.Find("Cuarto").GetComponent<Tilemap>();



        // print(enterPositionInTrigger);
        //float inputMagnitude = Math.Clamp01(direccionMovimiento.magnitude);

        //transform.Translate(direccionMovimiento * velocidadMovimiento * inputMagnitude * Time.deltaTime);
        // print(cuartoActual.GetComponent<Tilemap>().cellBounds);
    }

    void FixedUpdate()
    {
        //Movement
        objectToMove.MovePosition(objectToMove.position + movimiento * velocidadMovimiento * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // print(collision.GetComponent<Tilemap>().GetCellCenterLocal(new Vector3Int((int)collision.transform.position.x, (int)collision.transform.position.y)));
        // print(collision.GetComponent<Tilemap>().localBounds);
        // print(new Vector2(collision.transform.position.x, collision.transform.position.y));
        // print(collision.GetComponent<Tilemap>().GetTile(new Vector3Int(17, 0)).name);
        // print(collision.transform.TransformPoint(collision.transform.position));
        // enterPositionInTrigger = new Vector2(transform.position.x, transform.position.y);
        if (collision.tag == "Room")
        {
            cuartoActual = collision.gameObject;
            if (!collision.GetComponent<CuartoScript>().descubierto)
            {
                collision.GetComponent<CuartoScript>().descubierto = true;

                Tilemap cuarto = collision.GetComponent<Tilemap>();
                // print(cuarto.transform.position);

                Vector3Int[] positions = new Vector3Int[7];
                TileBase[] tileArray = new TileBase[positions.Length];

                for (int index = 0; index < positions.Length; index++)
                {
                    positions[index] = cuarto.WorldToCell(cuarto.transform.position) + new Vector3Int(cuarto.cellBounds.xMax - 1, index - 5, 0);
                    tileArray[index] = paredDerecha;
                }

                cuarto.SetTiles(positions, tileArray);

                positions = new Vector3Int[3];
                tileArray = new TileBase[positions.Length];

                for (int index = 0; index < positions.Length; index++)
                {
                    positions[index] = cuarto.WorldToCell(cuarto.transform.position) + new Vector3Int(cuarto.cellBounds.xMax - 1, index, 0);
                    tileArray[index] = null;
                }

                cuarto.SetTiles(positions, tileArray);

            }
            // if (collision.gameObject.descubierto)
            //     // Instantiate(cuarto, collision.transform.position, Quaternion.identity);
        }
        // transform.position = new Vector2(transform.position.x - 17f, 0f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Vector2 exitPosition = new Vector2(transform.position.x, transform.position.y);
        // cuarto.SwapTile(piso, paredVertical);


    }

}
