using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpecialShot : MonoBehaviour
{
    [SerializeField] InventoryManager.AllItems reqItem1, reqItem2, reqItem3;
    [SerializeField] InventoryManager.AllItems multishotToken, repeatedshotToken, powershotToken;
    private ManaBar manaBar;
    private CharacterStats characterStats;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    private PlayerInput playerInput;
    public GameObject Apuntador;

    private bool canShoot;

    private Vector2 mousePos;
    private Camera cam;
    private GameObject player;
    private float shotAngle = 0f;
    public float bulletSpeed = 20f;
    Vector2 lookingDirection;

    private float gunAngle = 0f;
    private float tiempoEntreDisparos = 0f;
    private float initialBulletSpeed;
    public int repeat = 0;
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

        if (HasRequiredItem(reqItem1, reqItem2, reqItem3))
        {
            canShoot = true;
            Debug.Log("canShoot = true porque tienes el item requerido");
            Apuntador.SetActive(true);
            Debug.Log("apuntador activado");
        }

        if (HasRequiredToken(multishotToken))
            UseMultiShot(true, 3, 60);

        if (HasRequiredToken(repeatedshotToken))
            RepeatShot(2);

        if (HasRequiredToken(powershotToken))
            PowerShot(100);

        if (tiempoEntreDisparos > 0f)
            tiempoEntreDisparos -= Time.deltaTime;

        if (characterStats.currentMana <= 0)
            canShoot = false;

        if (playerInput.actions["SpecialShot"].IsPressed() && tiempoEntreDisparos <= 0f && canShoot)
        {
            Shoot();
            if (repeat > 0)
            {
                tiempoEntreDisparos = 0.1f;
                repeat -= 1;
            }
            else
            {
                characterStats.LoseEnergy(10);
                tiempoEntreDisparos = characterStats.velocidadDisparo;
                repeat = shotsAmount - 1;
            }
        }

    }

    public bool HasRequiredItem(InventoryManager.AllItems reqItem1, InventoryManager.AllItems reqItem2, InventoryManager.AllItems reqItem3)
    {
        if (InventoryManager.Instance._inventoryItems.Contains(reqItem1) || InventoryManager.Instance._inventoryItems.Contains(reqItem2) || InventoryManager.Instance._inventoryItems.Contains(reqItem3))
            return true;
        else
            return false;
    }

    public bool HasRequiredToken(InventoryManager.AllItems reqItem)
    {
        if (InventoryManager.Instance._inventoryItems.Contains(reqItem))
            return true;
        else
            return false;
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
            shotsAmount = shotsAmount_;
            repeat = shotsAmount - 1;
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
        characterStats.LoseEnergy(10);
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