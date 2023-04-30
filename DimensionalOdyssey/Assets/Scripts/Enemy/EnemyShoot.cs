using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    // Elementos a buscar
    public Transform firePoint;
    public GameObject bulletPrefab;
    private Transform player;
    
    // Definir fuerza de las balas y velocidad de disparo
    public float bulletForce = 20f;
    public float fireRate = 1f;


    void Start()
    {
        // Buscar al jugador
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Se repite la función de disparo
        InvokeRepeating("Shoot", fireRate, fireRate);
    }

    void Shoot()
    {
        // Calcular dirección hacia el jugador
        Vector3 direction = player.position - firePoint.position;

        // Instanciar bala y darle velocidad
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(direction.normalized * bulletForce, ForceMode2D.Impulse);
    }
}
