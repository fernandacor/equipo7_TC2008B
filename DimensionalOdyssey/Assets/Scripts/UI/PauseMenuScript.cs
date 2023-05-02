using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    [HideInInspector] public bool gameIsPaused = false;//variable para saber si el juego esta pausado

    public GameObject pauseMenu;//menu de pausa

    private GameManager gameManager;

    void Start()
    {

        pauseMenu.SetActive(false);
        gameManager = GameManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))//si se presiona escape
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);//se activa o desactiva el menu de pausa
            gameIsPaused = pauseMenu.activeSelf;//se cambia el estado del juego
            if (gameIsPaused)//si el juego esta pausado
            {
                gameManager.SetGameState(GameState.Paused);//se cambia el estado del juego
            }
            else
            {
                gameManager.SetGameState(GameState.Playing);//se cambia el estado del juego
            }
        }
    }

}
