using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CuartoScript : MonoBehaviour
{
    public bool descubierto;
    Tilemap cuarto;
    GameObject pasillos;
    public TileBase piso;
    public TileBase esquinaDA;

    // Start is called before the first frame update
    void Start()
    {
        cuarto = gameObject.GetComponent<Tilemap>();
        pasillos = GameObject.FindGameObjectWithTag("Aisle");

        DibujarEntradas();
        // print(cuarto.cellBounds.xMax + 1);
        print(pasillos.GetComponent<Tilemap>().GetTile(new Vector3Int(((int)transform.position.x + cuarto.cellBounds.xMax + 1), (int)transform.position.y, 0)));


    }

    // Update is called once per frame
    void Update()
    {

    }


    void DibujarEntradas()
    {
        int cuartoXMax = cuarto.cellBounds.xMax;

        if (pasillos.GetComponent<Tilemap>().GetTile(new Vector3Int(((int)transform.position.x + cuarto.cellBounds.xMax + 1), (int)transform.position.y, 0)) != null)
        {
            Vector3Int[] positions = new Vector3Int[10];
            TileBase[] tileArray = new TileBase[positions.Length];

            for (int index = 0; index < positions.Length; index++)
            {
                positions[index] = cuarto.WorldToCell(cuarto.transform.position) + new Vector3Int(cuarto.cellBounds.xMax - 1, (int)cuarto.cellBounds.center.y + index - 5, 0);
                print(positions[index]);
                tileArray[index] = null;
            }


            transform.Find("Paredes").GetComponent<Tilemap>().SetTiles(positions, tileArray);
        }

        // Vector2 position = new Vector2(transform.position.x + 18, transform.position.y); // replace x and y with the position coordinates
        // Collider2D collider = Physics2D.OverlapPoint(position);
        // print(position);
        // print(gameObject.name);
        // if (collider != null)
        // {
        //     GameObject gameObject = collider.gameObject;
        //     // Use the gameObject
        //     if (gameObject.tag == "Aisle")
        //     {
        //         Vector3Int[] positionsV = new Vector3Int[10];
        //         TileBase[] tileArrayV = new TileBase[positionsV.Length];

        //         for (int index = 0; index < positionsV.Length; index++)
        //         {
        //             positionsV[index] = cuarto.WorldToCell(cuarto.transform.position) + new Vector3Int(cuarto.cellBounds.xMax - 1, index - 5, 0);
        //             tileArrayV[index] = piso;
        //         }

        //         cuarto.SetTiles(positionsV, tileArrayV);
        //     }
        // }

    }
}
