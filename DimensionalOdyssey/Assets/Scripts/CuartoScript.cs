using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CuartoScript : MonoBehaviour
{
    public bool descubierto;
    public GameObject esceneManager;

    private Tilemap cuarto;
    private GameObject pasillos;
    private int anchoPasillos = 10;

    TileBase paredArriba;
    TileBase paredDerecha;
    TileBase paredAbajo;
    TileBase paredIzquierda;
    TileBase esquinaArribaDerecha;
    TileBase esquinaArribaIzquierda;
    TileBase esquinaAbajoDerecha;
    TileBase esquinaAbajoIzquierda;
    TileBase piso;
    TileBase fondo;

    private void Awake()
    {
        paredArriba = esceneManager.GetComponent<EsceneManagerScript>().tileParedArriba;
        paredDerecha = esceneManager.GetComponent<EsceneManagerScript>().tileParedDerecha;
        paredAbajo = esceneManager.GetComponent<EsceneManagerScript>().tileParedAbajo;
        paredIzquierda = esceneManager.GetComponent<EsceneManagerScript>().tileParedIzquierda;
        esquinaArribaDerecha = esceneManager.GetComponent<EsceneManagerScript>().tileEsquinaArribaDerecha;
        esquinaArribaIzquierda = esceneManager.GetComponent<EsceneManagerScript>().tileEsquinaArribaIzquierda;
        esquinaAbajoDerecha = esceneManager.GetComponent<EsceneManagerScript>().tileEsquinaAbajoDerecha;
        esquinaAbajoIzquierda = esceneManager.GetComponent<EsceneManagerScript>().tileEsquinaAbajoIzquierda;
        piso = esceneManager.GetComponent<EsceneManagerScript>().tilePiso;
        fondo = esceneManager.GetComponent<EsceneManagerScript>().tileFondo;
    }

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

        // Generar enemigos
    }

    void AbrirEntradaArriba(Tilemap pisoPasillos, bool abrir)
    {
        Vector3Int afueraDelCuarto = new Vector3Int((int)transform.position.x, (int)transform.position.y + cuarto.cellBounds.yMax + 1, 0);
        Vector3Int posicionPared = new Vector3Int((int)cuarto.cellBounds.center.x - (anchoPasillos / 2), (int)cuarto.cellBounds.yMax - 1, 0);

        if (abrir)
            DibujarEntrada(pisoPasillos, afueraDelCuarto, posicionPared, esquinaArribaIzquierda, null, esquinaArribaDerecha, true);
        else
            DibujarEntrada(pisoPasillos, afueraDelCuarto, posicionPared, paredArriba, paredArriba, paredArriba, true);
    }

    void AbrirEntradaAbajo(Tilemap pisoPasillos, bool abrir)
    {
        Vector3Int afueraDelCuarto = new Vector3Int((int)transform.position.x, (int)transform.position.y + cuarto.cellBounds.yMin - 1, 0);
        Vector3Int posicionPared = new Vector3Int((int)cuarto.cellBounds.center.x - (anchoPasillos / 2), (int)cuarto.cellBounds.yMin, 0);

        if (abrir)
            DibujarEntrada(pisoPasillos, afueraDelCuarto, posicionPared, esquinaAbajoIzquierda, null, esquinaAbajoDerecha, true);
        else
            DibujarEntrada(pisoPasillos, afueraDelCuarto, posicionPared, paredAbajo, paredAbajo, paredAbajo, true);
    }

    void AbrirEntradaDerecha(Tilemap pisoPasillos, bool abrir)
    {
        Vector3Int afueraDelCuarto = new Vector3Int((int)transform.position.x + cuarto.cellBounds.xMax + 1, (int)transform.position.y, 0);
        Vector3Int posicionPared = new Vector3Int(cuarto.cellBounds.xMax - 1, (int)cuarto.cellBounds.center.y - (anchoPasillos / 2), 0);

        if (abrir)
            DibujarEntrada(pisoPasillos, afueraDelCuarto, posicionPared, esquinaAbajoDerecha, null, esquinaArribaDerecha, false);
        else
            DibujarEntrada(pisoPasillos, afueraDelCuarto, posicionPared, paredDerecha, paredDerecha, paredDerecha, false);
    }

    void AbrirEntradaIzquierda(Tilemap pisoPasillos, bool abrir)
    {
        Vector3Int afueraDelCuarto = new Vector3Int((int)transform.position.x + cuarto.cellBounds.xMin - 1, (int)transform.position.y, 0);
        Vector3Int posicionPared = new Vector3Int(cuarto.cellBounds.xMin, (int)cuarto.cellBounds.center.y - (anchoPasillos / 2), 0);

        if (abrir)
            DibujarEntrada(pisoPasillos, afueraDelCuarto, posicionPared, esquinaAbajoIzquierda, null, esquinaArribaIzquierda, false);
        else
            DibujarEntrada(pisoPasillos, afueraDelCuarto, posicionPared, paredIzquierda, paredIzquierda, paredIzquierda, false);
    }

    void DibujarEntrada(Tilemap pisoPasillos, Vector3Int afueraDelCuarto, Vector3Int posicionPared, TileBase tileInicio, TileBase tilesMedio, TileBase fin, bool vertical)
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
                    tileArray[i] = fin;
                else
                    tileArray[i] = tilesMedio;
            }

            transform.Find("Paredes").GetComponent<Tilemap>().SetTiles(posiciones, tileArray);
        }
    }
}
