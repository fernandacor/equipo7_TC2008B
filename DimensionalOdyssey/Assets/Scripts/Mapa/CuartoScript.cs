using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CuartoScript : MonoBehaviour
{
    private Tilemap cuarto;

    private GameObject salidaUp;
    private GameObject salidaDown;
    private GameObject salidaRight;
    private GameObject salidaLeft;

    public GameObject pasilloUp;
    public GameObject pasilloDown;
    public GameObject pasilloRight;
    public GameObject pasilloLeft;

    public bool descubierto;

    void Start()
    {
        cuarto = gameObject.GetComponent<Tilemap>();

        salidaUp = transform.Find("Salida Up").gameObject;
        salidaDown = transform.Find("Salida Down").gameObject;
        salidaRight = transform.Find("Salida Right").gameObject;
        salidaLeft = transform.Find("Salida Left").gameObject;

        AbrirCuarto();
    }

    public void AbrirCuarto()
    {
        if (pasilloUp == null)
            salidaUp.SetActive(true);
        else
        {
            salidaUp.SetActive(false);
            pasilloUp.SetActive(true);
        }

        if (pasilloDown == null)
            salidaDown.SetActive(true);
        else
        {
            salidaDown.SetActive(false);
            pasilloDown.SetActive(true);
        }

        if (pasilloRight == null)
            salidaRight.SetActive(true);
        else
        {
            salidaRight.SetActive(false);
            pasilloRight.SetActive(true);
        }

        if (pasilloLeft == null)
            salidaLeft.SetActive(true);
        else
        {
            salidaLeft.SetActive(false);
            pasilloLeft.SetActive(true);
        }
    }

    public void CerrarCuarto()
    {
        GetComponent<EnemySpawn>().GenerarEnemigos();

        salidaUp.SetActive(true);
        salidaDown.SetActive(true);
        salidaRight.SetActive(true);
        salidaLeft.SetActive(true);

        if (pasilloUp != null)
            pasilloUp.SetActive(false);
        if (pasilloDown != null)
            pasilloDown.SetActive(false);
        if (pasilloRight != null)
            pasilloRight.SetActive(false);
        if (pasilloLeft != null)
            pasilloLeft.SetActive(false);
    }
}
