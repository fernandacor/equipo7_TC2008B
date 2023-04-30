using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    public bool gameIsPaused = false;//variable para saber si el juego esta pausado

    public GameObject pauseMenu;//menu de pausa

    private GameManager gameManager;

    void Start()
    {

        pauseMenu.SetActive(false);

    }

    void Awake()
    {
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
                gameManager.SetGameState(GameState.Playing);//se cambia el estado del juego
            }
            else
            {
                gameManager.SetGameState(GameState.Paused);//se cambia el estado del juego
            }
            gameIsPaused = !gameIsPaused;//se cambia el estado del juego
        }
    }

    // public void Resume()//funcion para reanudar el juego
    // {
    //     pauseMenu.SetActive(false);//se desactiva el menu de pausa
    //     Time.timeScale = 1f;//se reanuda el tiempo
    //     gameIsPaused = false;//se cambia el estado del juego
    // }

    // void Pause()//funcion para pausar el juego
    // {
    //     pauseMenu.SetActive(true);//se activa el menu de pausa
    //     Time.timeScale = 0f;//se pausa el tiempo
    //     gameIsPaused = true;//se cambia el estado del juego
    // }
}
