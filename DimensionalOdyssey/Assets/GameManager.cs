using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Playing,
    Death,
    Paused,
    OpeningChest,
    AbrirInventario,
    BuyingFromShop
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameState gameState = GameState.Playing;//

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        switch (gameState)
        {
            case GameState.Playing:
                // Game is not paused, handle normal gameplay
                break;

            case GameState.Paused:
                // Game is paused, handle pause menu and other pause behavior
                break;

            case GameState.OpeningChest:
                // Player is opening a chest, pause game and handle chest behavior
                break;

            case GameState.BuyingFromShop:
                // Player is buying from a shop, pause game and handle shop behavior
                break;

            default:
                // Handle unexpected state
                break;
            
            case GameState.AbrirInventario:
                // Player is opening inventory, pause game and handle inventory behavior
                break;
            
            case GameState.Death:
                break;
        }
    }

    public void SetGameState(GameState newState)
    {
        gameState = newState;

        if (newState == GameState.Paused || newState == GameState.OpeningChest || 
        newState == GameState.BuyingFromShop || newState == GameState.AbrirInventario)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
