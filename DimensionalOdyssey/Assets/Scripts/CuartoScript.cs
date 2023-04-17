using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CuartoScript : MonoBehaviour
{
    public bool descubierto;

    private Tilemap cuarto;
    private GameObject pasillos;
    private int anchoPasillos = 10;

    [SerializeField] TileBase paredArriba;
    [SerializeField] TileBase paredDerecha;
    [SerializeField] TileBase paredAbajo;
    [SerializeField] TileBase paredIzquierda;
    [SerializeField] TileBase esquinaDerechaArriba;
    [SerializeField] TileBase esquinaDerechaAbajo;
    [SerializeField] TileBase esquinaIzquierdaArriba;
    [SerializeField] TileBase esquinaIzquierdaAbajo;
    [SerializeField] TileBase piso;
    [SerializeField] TileBase fondo;

    // Start is called before the first frame update
    void Start()
    {
        cuarto = gameObject.GetComponent<Tilemap>();
        pasillos = GameObject.FindGameObjectWithTag("Aisle");

        AbrirCuarto();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AbrirCuarto()
    {
        Tilemap pisoPasillos = pasillos.transform.Find("Piso").GetComponent<Tilemap>();

        AbrirEntradaDerecha(pisoPasillos, true);
        AbrirEntradaIzquierda(pisoPasillos, true);
        AbrirEntradaArriba(pisoPasillos, true);
        AbrirEntradaAbajo(pisoPasillos, true);

        pisoPasillos.gameObject.GetComponent<Renderer>().sortingOrder = -1;
        pisoPasillos.SwapTile(fondo, piso);
    }

    public void CerrarCuarto()
    {
        Tilemap pisoPasillos = pasillos.transform.Find("Piso").GetComponent<Tilemap>();

        AbrirEntradaDerecha(pisoPasillos, false);
        AbrirEntradaIzquierda(pisoPasillos, false);
        AbrirEntradaArriba(pisoPasillos, false);
        AbrirEntradaAbajo(pisoPasillos, false);

        pisoPasillos.gameObject.GetComponent<Renderer>().sortingOrder = 1;
        pisoPasillos.SwapTile(piso, fondo);
    }

    void AbrirEntradaDerecha(Tilemap pisoPasillos, bool abrir)
    {
        Vector3Int afueraDelCuarto = new Vector3Int((int)transform.position.x + cuarto.cellBounds.xMax + 1, (int)transform.position.y, 0);
        Vector3Int posicionPared = new Vector3Int(cuarto.cellBounds.xMax - 1, (int)cuarto.cellBounds.center.y - (anchoPasillos / 2), 0);

        if (abrir)
            DibujarEntrada(pisoPasillos, afueraDelCuarto, posicionPared, esquinaDerechaAbajo, null, esquinaDerechaArriba, false);
        else
            DibujarEntrada(pisoPasillos, afueraDelCuarto, posicionPared, paredDerecha, paredDerecha, paredDerecha, false);
    }

    void AbrirEntradaIzquierda(Tilemap pisoPasillos, bool abrir)
    {
        Vector3Int afueraDelCuarto = new Vector3Int((int)transform.position.x + cuarto.cellBounds.xMin - 1, (int)transform.position.y, 0);
        Vector3Int posicionPared = new Vector3Int(cuarto.cellBounds.xMin, (int)cuarto.cellBounds.center.y - (anchoPasillos / 2), 0);

        if (abrir)
            DibujarEntrada(pisoPasillos, afueraDelCuarto, posicionPared, esquinaIzquierdaAbajo, null, esquinaIzquierdaArriba, false);
        else
            DibujarEntrada(pisoPasillos, afueraDelCuarto, posicionPared, paredIzquierda, paredIzquierda, paredIzquierda, false);
    }

    void AbrirEntradaArriba(Tilemap pisoPasillos, bool abrir)
    {
        Vector3Int afueraDelCuarto = new Vector3Int((int)transform.position.x, (int)transform.position.y + cuarto.cellBounds.yMax + 1, 0);
        Vector3Int posicionPared = new Vector3Int((int)cuarto.cellBounds.center.x - (anchoPasillos / 2), (int)cuarto.cellBounds.yMax - 1, 0);

        if (abrir)
            DibujarEntrada(pisoPasillos, afueraDelCuarto, posicionPared, esquinaIzquierdaArriba, null, esquinaDerechaArriba, true);
        else
            DibujarEntrada(pisoPasillos, afueraDelCuarto, posicionPared, paredArriba, paredArriba, paredArriba, true);
    }

    void AbrirEntradaAbajo(Tilemap pisoPasillos, bool abrir)
    {
        Vector3Int afueraDelCuarto = new Vector3Int((int)transform.position.x, (int)transform.position.y + cuarto.cellBounds.yMin - 1, 0);
        Vector3Int posicionPared = new Vector3Int((int)cuarto.cellBounds.center.x - (anchoPasillos / 2), (int)cuarto.cellBounds.yMin, 0);

        if (abrir)
            DibujarEntrada(pisoPasillos, afueraDelCuarto, posicionPared, esquinaIzquierdaAbajo, null, esquinaDerechaAbajo, true);
        else
            DibujarEntrada(pisoPasillos, afueraDelCuarto, posicionPared, paredAbajo, paredAbajo, paredAbajo, true);
    }

    void DibujarEntrada(Tilemap pisoPasillos, Vector3Int afueraDelCuarto, Vector3Int posicionPared, TileBase tileInicio, TileBase tilesMedio, TileBase tileFin, bool vertical)
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
                    tileArray[i] = tilesMedio;
            }

            transform.Find("Paredes").GetComponent<Tilemap>().SetTiles(posiciones, tileArray);
        }
    }
}