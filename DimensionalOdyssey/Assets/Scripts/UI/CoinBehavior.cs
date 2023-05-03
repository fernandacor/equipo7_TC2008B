using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script que define el comportamiento de las monedas

public class CoinBehavior : MonoBehaviour
{
    // Valor de la moneda
    public int value;

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Si el jugador colisiona con una moneda, se elimina la moneda y se añade el valor de la moneda a las monedas del jugador
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            ShopManager.instance.AddCoins(value);
        }
    }
}