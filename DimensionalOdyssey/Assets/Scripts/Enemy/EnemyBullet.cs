using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script para que las balas del enemigo no se destruyan al colisionar con el enemigo
// Pero si cuando colisionan con cualquier otro objeto

public class EnemyBullet : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            return;
        }
        Destroy(gameObject);
    }
}
