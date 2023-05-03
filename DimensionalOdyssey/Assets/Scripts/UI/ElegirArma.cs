using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script para elegir el arma inicial que tiene el jugador

public class ElegirArma : MonoBehaviour
{
    // Elementos que conforman la interfaz
    public GameObject cajita; // Panel

    //Opciones de armas
    public GameObject pistola;
    public GameObject escopeta;
    public GameObject metralladora;

    private GameManager gameManager; // Para pausar el juego durante la selección

    void Start()
    {
        // Inicialmente se muestra el panel y se ocultan las armas
        pistola.SetActive(false);
        escopeta.SetActive(false);
        metralladora.SetActive(false);

        gameManager = GameManager.instance; // Se busca el game manager
    }

    public void Update()
    {
        // Si se presiona la tecla 1, se escoge y se muestra la pistola
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            cajita.SetActive(false);
            pistola.SetActive(true);
            escopeta.SetActive(false);
            metralladora.SetActive(false);
            Debug.Log("Escogiste la pistola");

            gameManager.SetGameState(GameState.chooseWeapon);
        }

        // Si se presiona la tecla 2, se escoge y se muestra la escopeta
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            cajita.SetActive(false);
            pistola.SetActive(false);
            escopeta.SetActive(true);
            metralladora.SetActive(false);
            Debug.Log("Escogiste la escopeta");

            gameManager.SetGameState(GameState.chooseWeapon);
        }

        // Si se presiona la tecla 3, se escoge y se muestra la metralladora
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            cajita.SetActive(false);
            pistola.SetActive(false);
            escopeta.SetActive(false);
            metralladora.SetActive(true);
            Debug.Log("Escogiste la metralladora");

            gameManager.SetGameState(GameState.chooseWeapon);
        }

        else
        {
            gameManager.SetGameState(GameState.Playing);
        }
    }
}
