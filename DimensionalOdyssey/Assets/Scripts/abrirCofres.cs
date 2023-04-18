using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class abrirCofres : MonoBehaviour
{
    public bool isOpen; // Se vuelve verdad si el trigger reconoce al jugador
    //Es publica para poder ver desde el inspector si se puede abrir el cofre o no

    public GameObject cajaAbierta; // Objeto que se activa cuando el cofre está abierto
    public GameObject cajaCerrada; // Objeto que se activa cuando el cofre está cerrado
    //Son publicas para poner las imagenes de los cofres en el inspector

    public GameObject itemEscupido; // Objeto que sale cuando se abre el cofre

    void Start()
    {
        //Inicialmente, el cofre esta cerrado
        isOpen = false;
        cajaAbierta.SetActive(false);
        cajaCerrada.SetActive(true);
        itemEscupido.SetActive(false);
    }

    void Update()
    {
        //Si el cofre reconoce al jugador y se presiona la tecla E, se abre
        if (isOpen == true && Input.GetKeyDown(KeyCode.E))
        {
            abrirCaja();
            itemEscupido.SetActive(true);
        };
    }

    private void abrirCaja() // Función que activa la imagen de cofre abierto y desactiva el cofre cerrado
    {
        cajaAbierta.SetActive(true);
        cajaCerrada.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player") // Si el jugador entra en el trigger, se activa la variable isOpen
        {
            isOpen = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") // Si el jugador sale del trigger, se desactiva la variable isOpen y se muestra el cofre cerrado
        {
            isOpen = false;
            cajaCerrada.SetActive(true);
        }
    }
}