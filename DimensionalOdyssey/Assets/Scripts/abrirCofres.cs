using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class abrirCofres : MonoBehaviour
{
    //defines object to whom the script applies to
    //[SerializeField] GameObject Player; //defines object to whom the script applies to

    //allows to change the number of health and hearts the game starts with (from 0-10)
    public bool isOpen;

    //defines sprites that belong to a full life and an empty life
    //public Image[] cajas;
    public GameObject cajaAbierta;
    public GameObject cajaCerrada;

    void Start()
    {
        isOpen = false;
        cajaAbierta.SetActive(false);
        cajaCerrada.SetActive(true);
    }

    void Update()
    {
        if (isOpen == true && Input.GetKeyDown(KeyCode.O))
        {
            abrirCaja();
        };
    }

    private void abrirCaja()
    {
        cajaAbierta.SetActive(true);
        cajaCerrada.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isOpen = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isOpen = false;
            cajaCerrada.SetActive(true);
        }
    }
}