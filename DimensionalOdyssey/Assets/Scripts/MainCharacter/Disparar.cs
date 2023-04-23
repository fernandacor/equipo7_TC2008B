using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour
{
    [SerializeField] InventoryManager.AllItems reqItem1, reqItem2, reqItem3;
    public ManaBar manaBar;
    public CharacterStats characterStats;
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    private bool canShoot;

    void Awake()
    {
        canShoot = false;
    }
    
    void Update()
    {
        if (characterStats.currentMana <= 0)
        {
            canShoot = false;
        }

        if (Input.GetButtonDown("Fire1") && canShoot == true)
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
        if(InventoryManager.Instance._inventoryItems.Contains(reqItem1) || InventoryManager.Instance._inventoryItems.Contains(reqItem2) || InventoryManager.Instance._inventoryItems.Contains(reqItem3))
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
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
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
