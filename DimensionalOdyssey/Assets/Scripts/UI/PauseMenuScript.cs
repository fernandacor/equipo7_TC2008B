using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    [HideInInspector] public bool gameIsPaused = false;//variable para saber si el juego esta pausado

    private GameObject pauseMenu;//menu de pausa

    void Start()
    {
        pauseMenu = GameObject.Find("PauseMenu").gameObject;
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))//si se presiona escape
        {
            if (gameIsPaused)//si el juego esta pausado
            {
                Resume();//se reanuda el juego
            }
            else
            {
                Pause();//se pausa el juego
            }
        }
    }

    public void Resume()//funcion para reanudar el juego
    {
        pauseMenu.SetActive(false);//se desactiva el menu de pausa
        Time.timeScale = 1f;//se reanuda el tiempo
        gameIsPaused = false;//se cambia el estado del juego
    }

    void Pause()//funcion para pausar el juego
    {
        pauseMenu.SetActive(true);//se activa el menu de pausa
        Time.timeScale = 0f;//se pausa el tiempo
        gameIsPaused = true;//se cambia el estado del juego
    }
}
