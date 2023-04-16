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

        setTilesDerecha(pisoPasillos);
        setTilesIzquierda(pisoPasillos);
        setTilesArriba(pisoPasillos);
        setTilesAbajo(pisoPasillos);
    }

    void setTilesDerecha(Tilemap pisoPasillos)
    {
        Vector3Int afueraDelCuarto = new Vector3Int((int)transform.position.x + cuarto.cellBounds.xMax + 1, (int)transform.position.y, 0);

        if (pisoPasillos.GetTile(afueraDelCuarto) != null)
        {
            int anchoPasillo = 10;
            Vector3Int[] posiciones = new Vector3Int[anchoPasillo];
            TileBase[] tileArray = new TileBase[posiciones.Length];

            for (int i = 0; i < posiciones.Length; i++)
            {
                Vector3Int posicionPared = new Vector3Int(cuarto.cellBounds.xMax - 1, (int)cuarto.cellBounds.center.y - (anchoPasillo / 2) + i, 0);
                posiciones[i] = cuarto.WorldToCell(cuarto.transform.position) + posicionPared;

                if (i == 0)
                    tileArray[i] = esquinaDerechaAbajo;
                else if (i == posiciones.Length - 1)
                    tileArray[i] = esquinaDerechaArriba;
                else
                    tileArray[i] = null;
            }

            transform.Find("Paredes").GetComponent<Tilemap>().SetTiles(posiciones, tileArray);
        }
    }

    void setTilesIzquierda(Tilemap pisoPasillos)
    {
        Vector3Int afueraDelCuarto = new Vector3Int((int)transform.position.x + cuarto.cellBounds.xMin - 1, (int)transform.position.y, 0);

        if (pisoPasillos.GetTile(afueraDelCuarto) != null)
        {
            int anchoPasillo = 10;
            Vector3Int[] posiciones = new Vector3Int[anchoPasillo];
            TileBase[] tileArray = new TileBase[posiciones.Length];

            for (int i = 0; i < posiciones.Length; i++)
            {
                Vector3Int posicionPared = new Vector3Int(cuarto.cellBounds.xMin, (int)cuarto.cellBounds.center.y - (anchoPasillo / 2) + i, 0);
                posiciones[i] = cuarto.WorldToCell(cuarto.transform.position) + posicionPared;

                if (i == 0)
                    tileArray[i] = esquinaIzquierdaAbajo;
                else if (i == posiciones.Length - 1)
                    tileArray[i] = esquinaIzquierdaArriba;
                else
                    tileArray[i] = null;
            }

            transform.Find("Paredes").GetComponent<Tilemap>().SetTiles(posiciones, tileArray);
        }
    }

    void setTilesArriba(Tilemap pisoPasillos)
    {
        Vector3Int afueraDelCuarto = new Vector3Int((int)transform.position.x, (int)transform.position.y + cuarto.cellBounds.yMax + 1, 0);

        if (pisoPasillos.GetTile(afueraDelCuarto) != null)
        {
            int anchoPasillo = 10;
            Vector3Int[] posiciones = new Vector3Int[anchoPasillo];
            TileBase[] tileArray = new TileBase[posiciones.Length];

            for (int i = 0; i < posiciones.Length; i++)
            {
                Vector3Int posicionPared = new Vector3Int((int)cuarto.cellBounds.center.x - (anchoPasillo / 2) + i, (int)cuarto.cellBounds.yMax - 1, 0);
                posiciones[i] = cuarto.WorldToCell(cuarto.transform.position) + posicionPared;

                if (i == 0)
                    tileArray[i] = esquinaIzquierdaArriba;
                else if (i == posiciones.Length - 1)
                    tileArray[i] = esquinaDerechaArriba;
                else
                    tileArray[i] = null;
            }

            transform.Find("Paredes").GetComponent<Tilemap>().SetTiles(posiciones, tileArray);
        }
    }

    void setTilesAbajo(Tilemap pisoPasillos)
    {
        Vector3Int afueraDelCuarto = new Vector3Int((int)transform.position.x, (int)transform.position.y + cuarto.cellBounds.yMin - 1, 0);

        if (pisoPasillos.GetTile(afueraDelCuarto) != null)
        {
            int anchoPasillo = 10;
            Vector3Int[] posiciones = new Vector3Int[anchoPasillo];
            TileBase[] tileArray = new TileBase[posiciones.Length];

            for (int i = 0; i < posiciones.Length; i++)
            {
                Vector3Int posicionPared = new Vector3Int((int)cuarto.cellBounds.center.x - (anchoPasillo / 2) + i, (int)cuarto.cellBounds.yMin, 0);
                posiciones[i] = cuarto.WorldToCell(cuarto.transform.position) + posicionPared;

                if (i == 0)
                    tileArray[i] = esquinaIzquierdaAbajo;
                else if (i == posiciones.Length - 1)
                    tileArray[i] = esquinaDerechaAbajo;
                else
                    tileArray[i] = null;
            }

            transform.Find("Paredes").GetComponent<Tilemap>().SetTiles(posiciones, tileArray);
        }
    }
}
