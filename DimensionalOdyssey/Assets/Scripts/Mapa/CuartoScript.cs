using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CuartoScript : MonoBehaviour
{
    private Tilemap cuarto;

    private GameObject salidaU;
    private GameObject salidaD;
    private GameObject salidaR;
    private GameObject salidaL;

    public GameObject pasilloU;
    public GameObject pasilloD;
    public GameObject pasilloR;
    public GameObject pasilloL;

    public bool descubierto;
    GameObject sceneManager;

    private GameObject pasillos;
    // private int anchoPasillos = 10;

    public TileBase paredArriba;
    // TileBase paredDerecha;
    // TileBase paredAbajo;
    // TileBase paredIzquierda;
    // TileBase esquinaArribaDerecha;
    // TileBase esquinaArribaIzquierda;
    // TileBase esquinaAbajoDerecha;
    // TileBase esquinaAbajoIzquierda;
    // TileBase piso;
    // TileBase fondo;

    private void Awake()
    {
        // sceneManager = GameObject.Find("SceneManager");

        // paredArriba = sceneManager.GetComponent<SceneManagerScript>().tileParedArriba;
        // paredDerecha = sceneManager.GetComponent<SceneManagerScript>().tileParedDerecha;
        // paredAbajo = sceneManager.GetComponent<SceneManagerScript>().tileParedAbajo;
        // paredIzquierda = sceneManager.GetComponent<SceneManagerScript>().tileParedIzquierda;
        // esquinaArribaDerecha = sceneManager.GetComponent<SceneManagerScript>().tileEsquinaArribaDerecha;
        // esquinaArribaIzquierda = sceneManager.GetComponent<SceneManagerScript>().tileEsquinaArribaIzquierda;
        // esquinaAbajoDerecha = sceneManager.GetComponent<SceneManagerScript>().tileEsquinaAbajoDerecha;
        // esquinaAbajoIzquierda = sceneManager.GetComponent<SceneManagerScript>().tileEsquinaAbajoIzquierda;
        // piso = sceneManager.GetComponent<SceneManagerScript>().tilePiso;
        // fondo = sceneManager.GetComponent<SceneManagerScript>().tileFondo;
    }

    // Start is called before the first frame update
    void Start()
    {
        cuarto = gameObject.GetComponent<Tilemap>();

        salidaU = transform.Find("SalidaU").gameObject;
        salidaD = transform.Find("SalidaD").gameObject;
        salidaR = transform.Find("SalidaR").gameObject;
        salidaL = transform.Find("SalidaL").gameObject;

        // pasilloVertical = GameObject.Find("PasilloVertical").GetComponent<Tilemap>();
        // pasilloHorizontal = GameObject.Find("PasilloHorizontal").GetComponent<Tilemap>();

        // pasillos = GameObject.FindGameObjectWithTag("Aisle");

        // AbrirCuarto();
        // ObtenerObjeto();
        AbrirCuarto2();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AbrirCuarto2()
    {
        if (pasilloU == null)
            salidaU.SetActive(true);
        else
        {
            salidaU.SetActive(false);
            pasilloU.SetActive(true);
        }

        if (pasilloD == null)
            salidaD.SetActive(true);
        else
        {
            salidaD.SetActive(false);
            pasilloD.SetActive(true);
        }

        if (pasilloR == null)
            salidaR.SetActive(true);
        else
        {
            salidaR.SetActive(false);
            pasilloR.SetActive(true);
        }

        if (pasilloL == null)
            salidaL.SetActive(true);
        else
        {
            salidaL.SetActive(false);
            pasilloL.SetActive(true);
        }
    }

    public void CerrarCuarto2()
    {
        salidaU.SetActive(true);
        salidaD.SetActive(true);
        salidaR.SetActive(true);
        salidaL.SetActive(true);

        if (pasilloU != null)
            pasilloU.SetActive(false);
        if (pasilloD != null)
            pasilloD.SetActive(false);
        if (pasilloR != null)
            pasilloR.SetActive(false);
        if (pasilloL != null)
            pasilloL.SetActive(false);
    }

    // void ObtenerObjeto()
    // {
    //     Vector3 afueraDelCuarto = new Vector3((int)transform.position.x + pasilloVertical.cellBounds.xMax, (int)transform.position.y + cuarto.cellBounds.yMax + 1, 0);
    //     // Vector3Int afueraDelCuarto = new Vector3Int((int)transform.position.x + pasilloVertical.cellBounds.xMax, (int)transform.position.y, 0);
    //     // cuarto.SetTile(afueraDelCuarto, paredArriba);
    //     Collider[] colliders = Physics.OverlapSphere(afueraDelCuarto, 0.1f);
    //     // Comprobar cada collider para encontrar el objeto correspondiente
    //     foreach (Collider collider in colliders)
    //     {
    //         // Obtener la referencia del objeto a través del collider
    //         GameObject obj = collider.gameObject;

    //         // Comprobar si la posición del objeto coincide con la posición deseada
    //         if (obj.transform.position == afueraDelCuarto)
    //         {
    //             // El objeto que estamos buscando ha sido encontrado
    //             Debug.Log("Encontrado el objeto " + obj + " en la posición: " + afueraDelCuarto);
    //             break;
    //         }
    //     }
    // }

    // public void AbrirCuarto()
    // {
    //     Tilemap pisoPasillos = pasillos.transform.Find("Piso").GetComponent<Tilemap>();

    //     AbrirEntradaArriba(pisoPasillos, true);
    //     AbrirEntradaAbajo(pisoPasillos, true);
    //     AbrirEntradaDerecha(pisoPasillos, true);
    //     AbrirEntradaIzquierda(pisoPasillos, true);

    //     pisoPasillos.gameObject.GetComponent<Renderer>().sortingOrder = -1;
    //     pisoPasillos.SwapTile(fondo, piso);
    // }

    // public void CerrarCuarto()
    // {
    //     Tilemap pisoPasillos = pasillos.transform.Find("Piso").GetComponent<Tilemap>();

    //     AbrirEntradaDerecha(pisoPasillos, false);
    //     AbrirEntradaIzquierda(pisoPasillos, false);
    //     AbrirEntradaArriba(pisoPasillos, false);
    //     AbrirEntradaAbajo(pisoPasillos, false);

    //     pisoPasillos.gameObject.GetComponent<Renderer>().sortingOrder = 1;
    //     pisoPasillos.SwapTile(piso, fondo);

    //     GetComponent<EnemySpawn>().GenerarEnemigos();
    //     // Generar enemigos
    // }

    // void AbrirEntradaArriba(Tilemap pisoPasillos, bool abrir)
    // {
    //     Vector3Int afueraDelCuarto = new Vector3Int((int)transform.position.x, (int)transform.position.y + cuarto.cellBounds.yMax + 1, 0);
    //     Vector3Int posicionPared = new Vector3Int((int)cuarto.cellBounds.center.x - (anchoPasillos / 2), (int)cuarto.cellBounds.yMax - 1, 0);

    //     if (abrir)
    //         ActivarEntrada(pisoPasillos, afueraDelCuarto, posicionPared, esquinaArribaIzquierda, null, esquinaArribaDerecha, true);
    //     else
    //         ActivarEntrada(pisoPasillos, afueraDelCuarto, posicionPared, paredArriba, paredArriba, paredArriba, true);
    // }

    // void AbrirEntradaAbajo(Tilemap pisoPasillos, bool abrir)
    // {
    //     Vector3Int afueraDelCuarto = new Vector3Int((int)transform.position.x, (int)transform.position.y + cuarto.cellBounds.yMin - 1, 0);
    //     Vector3Int posicionPared = new Vector3Int((int)cuarto.cellBounds.center.x - (anchoPasillos / 2), (int)cuarto.cellBounds.yMin, 0);

    //     if (abrir)
    //         ActivarEntrada(pisoPasillos, afueraDelCuarto, posicionPared, esquinaAbajoIzquierda, null, esquinaAbajoDerecha, true);
    //     else
    //         ActivarEntrada(pisoPasillos, afueraDelCuarto, posicionPared, paredAbajo, paredAbajo, paredAbajo, true);
    // }

    // void AbrirEntradaDerecha(Tilemap pisoPasillos, bool abrir)
    // {
    //     Vector3Int afueraDelCuarto = new Vector3Int((int)transform.position.x + cuarto.cellBounds.xMax + 1, (int)transform.position.y, 0);
    //     Vector3Int posicionPared = new Vector3Int(cuarto.cellBounds.xMax - 1, (int)cuarto.cellBounds.center.y - (anchoPasillos / 2), 0);

    //     if (abrir)
    //         ActivarEntrada(pisoPasillos, afueraDelCuarto, posicionPared, esquinaAbajoDerecha, null, esquinaArribaDerecha, false);
    //     else
    //         ActivarEntrada(pisoPasillos, afueraDelCuarto, posicionPared, paredDerecha, paredDerecha, paredDerecha, false);
    // }

    // void AbrirEntradaIzquierda(Tilemap pisoPasillos, bool abrir)
    // {
    //     Vector3Int afueraDelCuarto = new Vector3Int((int)transform.position.x + cuarto.cellBounds.xMin - 1, (int)transform.position.y, 0);
    //     Vector3Int posicionPared = new Vector3Int(cuarto.cellBounds.xMin, (int)cuarto.cellBounds.center.y - (anchoPasillos / 2), 0);

    //     if (abrir)
    //         ActivarEntrada(pisoPasillos, afueraDelCuarto, posicionPared, esquinaAbajoIzquierda, null, esquinaArribaIzquierda, false);
    //     else
    //         ActivarEntrada(pisoPasillos, afueraDelCuarto, posicionPared, paredIzquierda, paredIzquierda, paredIzquierda, false);
    // }

    // void ActivarEntrada(Tilemap pisoPasillos, Vector3Int afueraDelCuarto, Vector3Int posicionPared, TileBase tileInicio, TileBase tilesMedio, TileBase fin, bool vertical)
    // {

    //     if (pisoPasillos.GetTile(afueraDelCuarto) != null)
    //     {
    //         Vector3Int[] posiciones = new Vector3Int[anchoPasillos];
    //         TileBase[] tileArray = new TileBase[posiciones.Length];

    //         for (int i = 0; i < posiciones.Length; i++)
    //         {
    //             if (vertical)
    //                 posiciones[i] = cuarto.WorldToCell(cuarto.transform.position) + new Vector3Int(posicionPared.x + i, posicionPared.y, posicionPared.z);
    //             else
    //                 posiciones[i] = cuarto.WorldToCell(cuarto.transform.position) + new Vector3Int(posicionPared.x, posicionPared.y + i, posicionPared.z);

    //             if (i == 0)
    //                 tileArray[i] = tileInicio;
    //             else if (i == posiciones.Length - 1)
    //                 tileArray[i] = fin;
    //             else
    //                 tileArray[i] = tilesMedio;
    //         }

    //         transform.Find("Paredes").GetComponent<Tilemap>().SetTiles(posiciones, tileArray);
    //     }
    // }
}
