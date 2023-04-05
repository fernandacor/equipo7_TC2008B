using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class abrirCofres : MonoBehaviour
{
    //defines object to whom the script applies to
    //[SerializeField] GameObject Player; //defines object to whom the script applies to

    //allows to change the number of health and hearts the game starts with (from 0-10)
    private bool isOpen;

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

    void OnTriggerEnter2D(Collider2D other)
    {
        //if the player touches a trigger with the tag "enemy", health is lost
        if(other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Space) && isOpen == false)
        {
            isOpen = true;
            cajaAbierta.SetActive(true);
            cajaCerrada.SetActive(false);
        }
    }
}