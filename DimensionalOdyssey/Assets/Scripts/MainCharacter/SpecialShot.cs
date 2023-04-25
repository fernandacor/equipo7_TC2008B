using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpecialShot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 20f;
    Vector2 lookingDirection;
    private ManaBar manaBar;

    private GameObject player;
    private CharacterStats characterStats;
    private PlayerInput playerInput;
    private Vector2 mousePos;
    private Camera cam;

    private float gunAngle = 0f;
    private float tiempoEntreDisparos = 0f;
    private float initialBulletSpeed;
    private int repeat = 0;
    private int shotsAmount = 0;
    private bool useMultiShot = false;
    private int initialCantidadDisparos;
    private int rangoAngulos;

    void Awake()
    {
        player = transform.parent.gameObject;
        characterStats = player.GetComponent<CharacterStats>();
        playerInput = player.GetComponent<PlayerInput>();
        cam = GameObject.Find("Main Camera").gameObject.GetComponent<Camera>();
        initialBulletSpeed = bulletSpeed;
        manaBar = GameObject.Find("ManaBar").GetComponent<ManaBar>();

        RepeatShot(1);
        PowerShot(0);
        UseMultiShot(false, 4, 60);
    }

    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (playerInput.actions["SpecialShot"].IsPressed())
        {
            if (tiempoEntreDisparos > 0f)
                tiempoEntreDisparos -= Time.deltaTime;
            else
            {
                Shoot();
                if (repeat > 0)
                {
                    tiempoEntreDisparos = 0.1f;
                    repeat -= 1;
                }
                else
                {
                    tiempoEntreDisparos = characterStats.velocidadDisparo;
                    repeat = shotsAmount;
                }

            }
        }
    }

    void Shoot()
    {
        if (useMultiShot == true)
            MultiShot();
        else
            BasicShot();
    }

    public void RepeatShot(int shotsAmount_)
    {
        if (shotsAmount_ != shotsAmount)
        {
            shotsAmount = shotsAmount_ - 1;
            repeat = shotsAmount;
        }
    }

    public void PowerShot(int porcentajeMejora)
    {
        bulletSpeed = initialBulletSpeed + (initialBulletSpeed * porcentajeMejora * 0.01f);
    }

    public void UseMultiShot(bool useMultiShot_, int initialCantidadDisparos_, int rangoAngulos_)
    {
        useMultiShot = useMultiShot_;
        initialCantidadDisparos = initialCantidadDisparos_;
        rangoAngulos = rangoAngulos_;
    }

    void BasicShot()
    {
        Quaternion shotRotation = Quaternion.Euler(0f, 0f, gunAngle + 90f);
        GameObject bullet = Instantiate(bulletPrefab, transform.position, shotRotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(lookingDirection.normalized * bulletSpeed, ForceMode2D.Impulse);
    }

    void MultiShot()
    {
        Quaternion shotRotation;
        float shotAngle;
        Vector2 shotDirection;

        GameObject bullet;

        int cantidadDisparos = initialCantidadDisparos * 2 + 1;
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
        if (gunAngle <= 90 && gunAngle >= -90)
            transform.rotation = Quaternion.Euler(0, 0, gunAngle);
        else
            transform.rotation = Quaternion.Euler(180, 0, 360 - gunAngle);
    }
}