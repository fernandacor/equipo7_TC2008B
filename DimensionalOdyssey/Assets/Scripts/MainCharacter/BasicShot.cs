using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BasicShot : MonoBehaviour
{
    [SerializeField] InventoryManager.AllItems reqItem1, reqItem2, reqItem3;
    public GameObject bulletPrefab;
    public float bulletSpeed = 20f;

    private GameObject player;
    private CharacterStats characterStats;
    private PlayerInput playerInput;
    private Vector2 mousePos;
    private Camera cam;
    private GameObject apuntador;

    private bool canShoot;

    private float gunAngle = 0f;
    private float tiempoEntreDisparos = 0f;
    Vector2 lookingDirection;

    private bool useMultiShot = false;
    private int initialCantidadDisparos;
    private int rangoAngulos;

    //SFX variable
    [SerializeField] private AudioSource shootSFX;

    void Awake()
    {
        canShoot = false;
        player = transform.parent.gameObject;
        characterStats = player.GetComponent<CharacterStats>();
        playerInput = player.GetComponent<PlayerInput>();
        cam = GameObject.Find("Main Camera").gameObject.GetComponent<Camera>();
        apuntador = transform.parent.transform.Find("Apuntador").gameObject;
    }

    void Start()
    {
        apuntador.SetActive(false);
    }

    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (HasRequiredItem(reqItem1, reqItem2, reqItem3))
        {
            canShoot = true;
            apuntador.SetActive(true);
        }

        if (tiempoEntreDisparos > 0f)
            tiempoEntreDisparos -= Time.deltaTime;

        if (playerInput.actions["BasicShot"].IsPressed() && tiempoEntreDisparos <= 0f && canShoot)
        {
            tiempoEntreDisparos = characterStats.velocidadDisparo;
            Shoot();
        }
    }

    public bool HasRequiredItem(InventoryManager.AllItems reqItem1, InventoryManager.AllItems reqItem2, InventoryManager.AllItems reqItem3)
    {
        if (InventoryManager.Instance._inventoryItems.Contains(reqItem1) || InventoryManager.Instance._inventoryItems.Contains(reqItem2) || InventoryManager.Instance._inventoryItems.Contains(reqItem3))
            return true;
        else
            return false;
    }

    void Shoot()
    {
        if (useMultiShot == true)
            MultiShot();
        else
            NormalShot();
    }

    public void UseMultiShot(bool useMultiShot_, int initialCantidadDisparos_, int rangoAngulos_)
    {
        useMultiShot = useMultiShot_;
        initialCantidadDisparos = initialCantidadDisparos_;
        rangoAngulos = rangoAngulos_;
    }

    void NormalShot()
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
        transform.position = playerRB.position + lookingDirection.normalized * player.transform.localScale.x * 0.6f;

        gunAngle = Mathf.Atan2(lookingDirection.y, lookingDirection.x) * Mathf.Rad2Deg;
        if (gunAngle <= 90 && gunAngle >= -90)
            transform.rotation = Quaternion.Euler(0, 0, gunAngle);
        else
            transform.rotation = Quaternion.Euler(180, 0, 360 - gunAngle);
    }
}
