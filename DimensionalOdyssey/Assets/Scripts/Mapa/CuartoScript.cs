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

    void Start()
    {
        cuarto = gameObject.GetComponent<Tilemap>();

        salidaU = transform.Find("SalidaU").gameObject;
        salidaD = transform.Find("SalidaD").gameObject;
        salidaR = transform.Find("SalidaR").gameObject;
        salidaL = transform.Find("SalidaL").gameObject;

        AbrirCuarto();
    }

    public void AbrirCuarto()
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

    public void CerrarCuarto()
    {
        GetComponent<EnemySpawn>().GenerarEnemigos();

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
}
