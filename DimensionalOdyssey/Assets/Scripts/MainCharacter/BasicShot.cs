using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BasicShot : MonoBehaviour
{
    [SerializeField] InventoryManager.AllItems reqItem1, reqItem2, reqItem3;
    private ManaBar manaBar;
    public GameObject bulletPrefab;
    public float bulletSpeed = 20f;

    private GameObject player;
    private CharacterStats characterStats;
    private PlayerInput playerInput;
    private Vector2 mousePos;
    private Camera cam;
    public GameObject Apuntador;

    private bool canShoot;

    private float gunAngle = 0f;
    private float entreDisparos = 0f;
    Vector2 lookingDirection;

    void Awake()
    {
        canShoot = false;
        player = transform.parent.gameObject;
        characterStats = player.GetComponent<CharacterStats>();
        playerInput = player.GetComponent<PlayerInput>();
        cam = GameObject.Find("Main Camera").gameObject.GetComponent<Camera>();
        Apuntador.SetActive(false);
    }

    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (HasRequiredItem(reqItem1, reqItem2, reqItem3) == true)
        {
            canShoot = true;
            Debug.Log("canShoot = true porque tienes el item requerido");
            Apuntador.SetActive(true);
            Debug.Log("apuntador activado");
        }

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

        if (HasRequiredItem(reqItem1, reqItem2, reqItem3) == true)
        {
            canShoot = true;
            Debug.Log("canShoot = true porque tienes el item requerido");
            Apuntador.SetActive(true);
            Debug.Log("apuntador activado");
        }

        if (characterStats.currentMana <= 0)
        {
            canShoot = false;
            Debug.Log("cannot shoot, no mana left");
        }

        if (playerInput.actions["BasicShot"].WasPressedThisFrame() && canShoot == true)
        {
            Shoot();
        }

        if (playerInput.actions["BasicShot"].WasPressedThisFrame() && canShoot == false)
        {
            Debug.Log("cannot shoot, no item");
        }
    }

    public bool HasRequiredItem(InventoryManager.AllItems reqItem1, InventoryManager.AllItems reqItem2, InventoryManager.AllItems reqItem3)
    {
        if (InventoryManager.Instance._inventoryItems.Contains(reqItem1) || InventoryManager.Instance._inventoryItems.Contains(reqItem2) || InventoryManager.Instance._inventoryItems.Contains(reqItem3))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Shoot()
    {
        characterStats.LoseEnergy(10);
        Quaternion shotRotation = Quaternion.Euler(0f, 0f, gunAngle + 90f);
        GameObject bullet = Instantiate(bulletPrefab, transform.position, shotRotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(lookingDirection.normalized * bulletSpeed, ForceMode2D.Impulse);
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
