using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Disparar : MonoBehaviour
{
    [SerializeField] InventoryManager.AllItems reqItem1, reqItem2, reqItem3;
    public ManaBar manaBar;
    public CharacterStats characterStats;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    private PlayerInput playerInput;

    private bool canShoot;

    private Vector2 mousePos;
    private Camera cam;
    private GameObject player;
    private float shotAngle = 0f;

    void Awake()
    {
        canShoot = false;
        player = transform.parent.gameObject;
        cam = GameObject.Find("Main Camera").gameObject.GetComponent<Camera>();
        playerInput = transform.parent.GetComponent<PlayerInput>();
    }

    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (characterStats.currentMana <= 0)
        {
            canShoot = false;
        }

        if (playerInput.actions["BasicShot"].WasPressedThisFrame() && canShoot == true)
        {
            Shoot();
        }

        if (HasRequiredItem(reqItem1, reqItem2, reqItem3) == true)
        {
            canShoot = true;
            Debug.Log("canShoot = true porque tienes el item requerido");
        }
    }

    //If tiene alguna de las pistolas, canShoot = true
    //If canShoot = true, significa que mana > 0
    //If mana = 0, canShoot = false
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


    //Token Behavior
    void TokenBehavior(int token)
    {
        Debug.Log("sisi");
        // tokenMultidisparoDoble - dos disparos en distintas direcciones
        // tokenMultidisparoTriple - tres disparos en distintas direcciones
        // tokenMultidisparoCuadruple - cuatro disparos en distintas direcciones
        // tokenDisparoDoble - dos disparos en la misma dirección
        // tokenDisparoTriple - tres disparos en la misma dirección
        // tokenReboteBalas - balas rebotan de las paredes
        // tokenCombo - balas rebotan del enemigo y se dirigen a otro
        // tolenAtaqueDirigido - balas persiguen al enemigo
    }
}
