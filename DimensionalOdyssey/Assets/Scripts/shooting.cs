using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject shootingItem;
    public Transform shootingPoint;
    public bool canShoot = true;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if(!canShoot)
            return;
        
        GameObject disparable = Instantiate(shootingItem, shootingPoint);
        disparable.transform.parent = null;
    }
}
