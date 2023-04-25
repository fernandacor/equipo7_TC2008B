using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpecialShot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 20f;
    Vector2 lookingDirection;

    private GameObject player;
    private CharacterStats characterStats;
    private PlayerInput playerInput;
    private Vector2 mousePos;
    private Camera cam;

    private float gunAngle = 0f;
    private float tiempoEntreDisparos = 0f;
    private int repeat = 0;
    private float initialBulletSpeed;
    private int shotsAmount = 0;

    void Awake()
    {
        player = transform.parent.gameObject;
        characterStats = player.GetComponent<CharacterStats>();
        playerInput = player.GetComponent<PlayerInput>();
        cam = GameObject.Find("Main Camera").gameObject.GetComponent<Camera>();
        initialBulletSpeed = bulletSpeed;
    }

    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (playerInput.actions["SpecialShot"].IsPressed())
        {
            // if (repeat == 0)
            // {
            if (tiempoEntreDisparos > 0f)
                tiempoEntreDisparos -= Time.deltaTime;
            else
            {
                RepeatShot(2);
                tiempoEntreDisparos = characterStats.velocidadDisparo;
            }
            // }
        }
    }

    public void Shoot()
    {
        // if está el token de power shot
        // PowerShot(150);

        // if está el token de multishot
        MultiShot(3, 45);

        // else
        // BasicShot();
    }

    public void BasicShot()
    {
        Quaternion shotRotation = Quaternion.Euler(0f, 0f, gunAngle + 90f);
        GameObject bullet = Instantiate(bulletPrefab, transform.position, shotRotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(lookingDirection.normalized * bulletSpeed, ForceMode2D.Impulse);
    }

    public void RepeatShot(int shotsAmount)
    {
        int i = 0;
        while (i < shotsAmount)
        {
            if (tiempoEntreDisparos > 0f)
                tiempoEntreDisparos -= Time.deltaTime;
            else
            {
                Shoot();
                tiempoEntreDisparos = 0.1f;
                i++;
            }
        }
    }

    public void PowerShot(int porcentajeMejora)
    {
        bulletSpeed = initialBulletSpeed + (initialBulletSpeed * porcentajeMejora * 0.01f);
    }

    public void MultiShot(int cantidadDisparos, int rangoAngulos)
    {
        Quaternion shotRotation;
        float shotAngle;
        Vector2 shotDirection;

        GameObject bullet;

        // int cantidadDisparos = 2;
        // int rangoAngulos = 45;

        cantidadDisparos = cantidadDisparos * 2 + 1;
        float diferenciaAngulos = rangoAngulos / (cantidadDisparos - 1);

        for (int i = 0; i < cantidadDisparos; i++)
        {
            if (i % 2 == 1)
            {
                float anguloActual = -rangoAngulos / 2 + diferenciaAngulos * i;
                shotRotation = Quaternion.Euler(0f, 0f, gunAngle + 90 + anguloActual);
                shotAngle = (gunAngle + anguloActual) * Mathf.Deg2Rad;
                shotDirection = new Vector2(Mathf.Cos(shotAngle), Mathf.Sin(shotAngle));

                bullet = Instantiate(bulletPrefab, transform.position, shotRotation);
                bullet.GetComponent<Rigidbody2D>().AddForce(shotDirection * bulletSpeed, ForceMode2D.Impulse);
            }
        }
    }

    void FixedUpdate()
    {
        Rigidbody2D playerRB = player.GetComponent<Rigidbody2D>();
        lookingDirection = mousePos - playerRB.position;
        // Mover el arma en un círculo alrededor del jugador dependiendo de a donde apunte
        transform.position = playerRB.position + lookingDirection.normalized * player.transform.localScale.x * 0.6f;

        gunAngle = Mathf.Atan2(lookingDirection.y, lookingDirection.x) * Mathf.Rad2Deg;
        Debug.Log(gunAngle);
        if (gunAngle <= 90 && gunAngle >= -90)
            transform.rotation = Quaternion.Euler(0, 0, gunAngle);
        else
            transform.rotation = Quaternion.Euler(180, 0, 360 - gunAngle);
    }
}