using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Disparar : MonoBehaviour
{
    public ManaBar manaBar;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    private PlayerInput playerInput;

    private Vector2 mousePos;
    private Camera cam;
    private GameObject player;
    private float shotAngle = 0f;

    void Awake()
    {
        player = transform.parent.gameObject;
        cam = GameObject.Find("Main Camera").gameObject.GetComponent<Camera>();
        playerInput = transform.parent.GetComponent<PlayerInput>();
    }

    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (playerInput.actions["BasicShot"].WasPressedThisFrame())
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Quaternion shotRotation = Quaternion.Euler(0f, 0f, shotAngle + 90f);

        GameObject bullet = Instantiate(bulletPrefab, transform.position, shotRotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletForce, ForceMode2D.Impulse);
    }

    void FixedUpdate()
    {
        Rigidbody2D playerRB = player.GetComponent<Rigidbody2D>();
        Vector2 lookDirection = mousePos - playerRB.position;
        transform.position = playerRB.position + lookDirection.normalized * player.transform.localScale.x * 0.6f;

        shotAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        if (shotAngle <= 90 && shotAngle >= -90)
            transform.rotation = Quaternion.Euler(0, 0, shotAngle);
        else
            transform.rotation = Quaternion.Euler(180, 0, 360 - shotAngle);
    }
}
