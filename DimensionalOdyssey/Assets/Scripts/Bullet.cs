using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            return; // Si el objeto colisionado es el jugador, no se destruirá el objeto
        }
        Destroy(gameObject);
    }

}
