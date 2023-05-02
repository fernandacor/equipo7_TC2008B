using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElegirArma : MonoBehaviour
{
    public GameObject cajita;
    public GameObject pistola;
    public GameObject escopeta;
    public GameObject metralladora;

    private GameManager gameManager;

    void Start()
    {
        pistola.SetActive(false);
        escopeta.SetActive(false);
        metralladora.SetActive(false);

        gameManager = GameManager.instance;
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            cajita.SetActive(false);
            pistola.SetActive(true);
            escopeta.SetActive(false);
            metralladora.SetActive(false);
            Debug.Log("Escogiste la pistola");

            gameManager.SetGameState(GameState.chooseWeapon);
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            cajita.SetActive(false);
            pistola.SetActive(false);
            escopeta.SetActive(true);
            metralladora.SetActive(false);
            Debug.Log("Escogiste la escopeta");

            gameManager.SetGameState(GameState.chooseWeapon);
        }

        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            cajita.SetActive(false);
            pistola.SetActive(false);
            escopeta.SetActive(false);
            metralladora.SetActive(true);
            Debug.Log("Escogiste la metralladora");

            gameManager.SetGameState(GameState.chooseWeapon);
        }

        else{
            gameManager.SetGameState(GameState.Playing);
        }
    }
}
