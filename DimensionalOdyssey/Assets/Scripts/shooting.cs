using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    [SerializeField] InventoryManager.AllItems requiredItem;
    public bool canShoot = true;
    public bool canFire = true;
    private Camera mainCam;
    //public GameObject shootingItem;
    //public Transform shootingPoint;
    public GameObject bullet;
    public Transform bulletTransform;
    private Vector3 mousePos;
    private float timer;
    public float timeBetweenFiring;
    public SpriteRenderer pistola;

    private void Start()
    {
        canFire = false;
        canShoot = false;
        pistola.enabled = false;
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    public bool hasRequiredItem(InventoryManager.AllItems itemRequired)
    {
        if(InventoryManager.Instance._inventoryItems.Contains(itemRequired))
        {
            Debug.Log("hasRequiredItem = true");
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Gun"))
        {
            if(hasRequiredItem(requiredItem) == true)
            {
                Debug.Log("Se tiene el elemento");
                canShoot = !canShoot;
                pistola.enabled = true;
                Debug.Log("canShoot = true");
            }
        }
    }

    // void Shoot()
    // {
    //     if(canShoot == false)
    //         return;

    //     GameObject disparable = Instantiate(shootingItem, shootingPoint);
    //     disparable.transform.parent = null;
    // }

    private void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);

        if (canShoot == true)
        {
            if(!canFire)
            {
                timer += Time.deltaTime;
                if(timer >= timeBetweenFiring)
                {
                    canFire = true;
                    timer = 0;
                }
            }
        }

        if(Input.GetMouseButton(0) && canFire == true)
        {
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        }
    }
}
