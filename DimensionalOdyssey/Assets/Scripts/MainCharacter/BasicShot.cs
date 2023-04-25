using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BasicShot : MonoBehaviour
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

        if (playerInput.actions["BasicShot"].IsPressed())
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
        Quaternion shotRotation = Quaternion.Euler(0f, 0f, gunAngle + 90f);
        GameObject bullet = Instantiate(bulletPrefab, transform.position, shotRotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletSpeed, ForceMode2D.Impulse);
    }

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
