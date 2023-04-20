/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public float shootingRange;
    public float fireRate = 1f;
    private float nextFireTime;
    public GameObject bullet;
    public GameObject FireSpot;
    public float bulletSpeed;
    private Transform player;

    private Rigidbody2D rb2D;
    public float force;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 direction = player.transform.position - transform.position;
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = direction.normalized * force;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector3.Distance(player.position, transform.position);
        if (distanceFromPlayer <= shootingRange && nextFireTime < Time.time){
            GameObject newBullet = Instantiate(bullet, FireSpot.transform.position, Quaternion.identity);
            Rigidbody2D bulletRb2D = newBullet.GetComponent<Rigidbody2D>();
            Vector3 direction = player.transform.position - FireSpot.transform.position;
            bulletRb2D.velocity = direction.normalized * bulletSpeed;
            nextFireTime = Time.time + fireRate;
        }
    }

    private void OnDrawGizmosSelected(){
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;
    public float fireRate = 1f;

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
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