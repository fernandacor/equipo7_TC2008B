using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script para que las balas del jugador no se destruyan al colisionar con el jugador
// Pero si cuando colisionan con cualquier otro objeto

public class Bullet : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            return;
        }
        Destroy(gameObject);
    }

}
