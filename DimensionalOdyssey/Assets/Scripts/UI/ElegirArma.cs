using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElegirArma : MonoBehaviour
{
    public GameObject cajita;
    public GameObject pistola;
    public GameObject escopeta;
    public GameObject metralladora;

    void Start()
    {
        pistola.SetActive(false);
        escopeta.SetActive(false);
        metralladora.SetActive(false);
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            cajita.SetActive(false);
            pistola.SetActive(true);
            escopeta.SetActive(false);
            metralladora.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            cajita.SetActive(false);
            pistola.SetActive(false);
            escopeta.SetActive(true);
            metralladora.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            cajita.SetActive(false);
            pistola.SetActive(false);
            escopeta.SetActive(false);
            metralladora.SetActive(true);
        }
    }
}
