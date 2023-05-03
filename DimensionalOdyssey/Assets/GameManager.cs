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
    BuyingFromShop,
    chooseWeapon
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameState gameState = GameState.Playing;//

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;//se crea la instancia
            // DontDestroyOnLoad(gameObject);//no se destruye el objeto
        }
        else
        {
            Destroy(gameObject);//se destruye el objeto
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

            case GameState.chooseWeapon:
                break;
        }
    }

    public void SetGameState(GameState newState)//funcion para cambiar el estado del juego
    {
        gameState = newState;//se cambia el estado del juego

        if (newState == GameState.Paused || newState == GameState.OpeningChest || //si el estado es pausado, abriendo cofre o comprando en la tienda
        newState == GameState.BuyingFromShop || newState == GameState.AbrirInventario)//se pausa el juego
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
