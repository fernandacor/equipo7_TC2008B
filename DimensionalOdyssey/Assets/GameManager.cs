using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static event Action<GameState> OnGameStateChanged;
    public GameState State;
    // Start is called before the first frame update
    void Awake(){
        Instance = this;
    }

    void Start(){
        UpdateGameState(GameState.paused);
    }

    public void UpdateGameState(GameState newState){//cambia el estado del juego
        State = newState;
        switch (newState) {
            case GameState.paused:
                handlePause();
                break;
            case GameState.inventory:
                break;
            case GameState.gameover:
                break;
            case GameState.store:
                break;
            default:
                throw new System.ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChanged?.Invoke(newState);
    }

    private void handlePause(){
    }
}

public enum GameManagerState{ //estados del juego
    paused,
    inventory,
    gameover, 
    store,  
    }
