using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpecialShot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 20f;

    private GameObject player;
    private CharacterStats characterStats;
    private PlayerInput playerInput;
    private Vector2 mousePos;
    private Camera cam;

    private float gunAngle = 0f;
    private float entreDisparos = 0f;

    void Awake()
    {
        player = transform.parent.gameObject;
        characterStats = player.GetComponent<CharacterStats>();
        playerInput = player.GetComponent<PlayerInput>();
        cam = GameObject.Find("Main Camera").gameObject.GetComponent<Camera>();
    }

    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (playerInput.actions["SpecialShot"].IsPressed())
        {
            if (entreDisparos > 0f)
                entreDisparos -= Time.deltaTime;
            else
            {
                entreDisparos = characterStats.velocidadDisparo;
                Shoot();
            }
        }
    }

    public void Shoot()
    {
        Quaternion shotRotation;
        float shotAngle;
        Vector2 shotVector;

        GameObject bullet;

        int cantidadDisparos = 3;
        float anguloMenor = 80;
        float anguloMayor = 100;
        float diferenciaAngulos = (anguloMayor - anguloMenor) / (cantidadDisparos - 1);

        for (int i = 0; i < cantidadDisparos; i++)
        {
            shotRotation = Quaternion.Euler(0f, 0f, gunAngle + (anguloMenor + diferenciaAngulos * i));
            shotAngle = (transform.rotation.z + gunAngle + (-diferenciaAngulos + diferenciaAngulos * i)) * Mathf.Deg2Rad;
            shotVector = new Vector2(Mathf.Cos(shotAngle), Mathf.Sin(shotAngle));

            bullet = Instantiate(bulletPrefab, transform.position, shotRotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(shotVector * bulletSpeed, ForceMode2D.Impulse);
        }
    }

    // public void Shoot()
    // {
    //     Quaternion shotRotation;
    //     float shotAngle;
    //     Vector2 shotVector;

    //     GameObject bullet;

    //     int cantidadDisparos = 2;
    //     int rangoAngulos = 60;
    //     float diferenciaAngulos;

    //     if (cantidadDisparos % 2 == 1)
    //         diferenciaAngulos = rangoAngulos / (cantidadDisparos - 1);

    //     for (int i = 0; i < cantidadDisparos; i++)
    //     {
    //         shotRotation = Quaternion.Euler(0f, 0f, gunAngle + (anguloMenor + diferenciaAngulos * i));
    //         shotAngle = (transform.rotation.z + gunAngle + (-diferenciaAngulos + diferenciaAngulos * i)) * Mathf.Deg2Rad;
    //         shotVector = new Vector2(Mathf.Cos(shotAngle), Mathf.Sin(shotAngle));

    //         bullet = Instantiate(bulletPrefab, transform.position, shotRotation);
    //         bullet.GetComponent<Rigidbody2D>().AddForce(shotVector * bulletSpeed, ForceMode2D.Impulse);
    //     }
    // }

    void FixedUpdate()
    {
        Rigidbody2D playerRB = player.GetComponent<Rigidbody2D>();
        Vector2 lookDirection = mousePos - playerRB.position;
        transform.position = playerRB.position + lookDirection.normalized * player.transform.localScale.x * 0.6f;

        gunAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        if (gunAngle <= 90 && gunAngle >= -90)
            transform.rotation = Quaternion.Euler(0, 0, gunAngle);
        else
            transform.rotation = Quaternion.Euler(180, 0, 360 - gunAngle);
    }
}