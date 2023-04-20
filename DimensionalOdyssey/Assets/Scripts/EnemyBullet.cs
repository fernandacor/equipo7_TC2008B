using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            return; // Si el objeto colisionado es el mismo enemigo, no se destruirá el objeto
        }
        Destroy(gameObject);
    }

}
