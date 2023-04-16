using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CuartoScript : MonoBehaviour
{
    public bool descubierto;
    Tilemap cuarto;
    GameObject pasillos;
    public TileBase esquinaDerechaArriba;
    public TileBase esquinaDerechaAbajo;
    public TileBase esquinaIzquierdaArriba;
    public TileBase esquinaIzquierdaAbajo;
    public int anchoPasillos = 10;


    // Start is called before the first frame update
    void Start()
    {
        cuarto = gameObject.GetComponent<Tilemap>();
        pasillos = GameObject.FindGameObjectWithTag("Aisle");

        DibujarEntradas();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void DibujarEntradas()
    {
        Tilemap pisoPasillos = pasillos.transform.Find("Piso").GetComponent<Tilemap>();

        DibujarEntradaDerecha(pisoPasillos);
        DibujarEntradaIzquierda(pisoPasillos);
        DibujarEntradaArriba(pisoPasillos);
        DibujarEntradaAbajo(pisoPasillos);
    }

    void DibujarEntrada(Tilemap pisoPasillos, Vector3Int afueraDelCuarto, Vector3Int posicionPared, TileBase tileInicio, TileBase tileFin, bool vertical)
    {
        if (pisoPasillos.GetTile(afueraDelCuarto) != null)
        {
            Vector3Int[] posiciones = new Vector3Int[anchoPasillos];
            TileBase[] tileArray = new TileBase[posiciones.Length];

            for (int i = 0; i < posiciones.Length; i++)
            {
                if (vertical)
                    posiciones[i] = cuarto.WorldToCell(cuarto.transform.position) + new Vector3Int(posicionPared.x + i, posicionPared.y, posicionPared.z);
                else
                    posiciones[i] = cuarto.WorldToCell(cuarto.transform.position) + new Vector3Int(posicionPared.x, posicionPared.y + i, posicionPared.z);

                if (i == 0)
                    tileArray[i] = tileInicio;
                else if (i == posiciones.Length - 1)
                    tileArray[i] = tileFin;
                else
                    tileArray[i] = null;
            }

            transform.Find("Paredes").GetComponent<Tilemap>().SetTiles(posiciones, tileArray);
        }
    }

    void DibujarEntradaDerecha(Tilemap pisoPasillos)
    {
        Vector3Int afueraDelCuarto = new Vector3Int((int)transform.position.x + cuarto.cellBounds.xMax + 1, (int)transform.position.y, 0);
        Vector3Int posicionPared = new Vector3Int(cuarto.cellBounds.xMax - 1, (int)cuarto.cellBounds.center.y - (anchoPasillos / 2), 0);

        DibujarEntrada(pisoPasillos, afueraDelCuarto, posicionPared, esquinaDerechaAbajo, esquinaDerechaArriba, false);
    }

    void DibujarEntradaIzquierda(Tilemap pisoPasillos)
    {
        Vector3Int afueraDelCuarto = new Vector3Int((int)transform.position.x + cuarto.cellBounds.xMin - 1, (int)transform.position.y, 0);
        Vector3Int posicionPared = new Vector3Int(cuarto.cellBounds.xMin, (int)cuarto.cellBounds.center.y - (anchoPasillos / 2), 0);

        DibujarEntrada(pisoPasillos, afueraDelCuarto, posicionPared, esquinaIzquierdaAbajo, esquinaIzquierdaArriba, false);
    }

    void DibujarEntradaArriba(Tilemap pisoPasillos)
    {
        Vector3Int afueraDelCuarto = new Vector3Int((int)transform.position.x, (int)transform.position.y + cuarto.cellBounds.yMax + 1, 0);
        Vector3Int posicionPared = new Vector3Int((int)cuarto.cellBounds.center.x - (anchoPasillos / 2), (int)cuarto.cellBounds.yMax - 1, 0);

        DibujarEntrada(pisoPasillos, afueraDelCuarto, posicionPared, esquinaIzquierdaArriba, esquinaDerechaArriba, true);
    }

    void DibujarEntradaAbajo(Tilemap pisoPasillos)
    {
        Vector3Int afueraDelCuarto = new Vector3Int((int)transform.position.x, (int)transform.position.y + cuarto.cellBounds.yMin - 1, 0);
        Vector3Int posicionPared = new Vector3Int((int)cuarto.cellBounds.center.x - (anchoPasillos / 2), (int)cuarto.cellBounds.yMin, 0);

        DibujarEntrada(pisoPasillos, afueraDelCuarto, posicionPared, esquinaIzquierdaAbajo, esquinaDerechaAbajo, true);
    }
}
