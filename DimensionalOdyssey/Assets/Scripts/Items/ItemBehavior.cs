using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script para definir el comportamiento de los items

public class ItemBehavior : MonoBehaviour
{
    // Se busca el inventario y la lista de todo 
    [SerializeField] InventoryManager.AllItems itemType;

    // Booleano que detecta si el objeto puede ser recogido o no
    [HideInInspector] public bool pickUp = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si el trigger detecta al jugador, el objeto se vuelve recogibles
        if (collision.gameObject.tag == "Player")
        {
            pickUp = true;
        }
    }

    private void Update()
    {
        // Cuando el jugador pica E, recoge el item y se registra en el inventario
        if (Input.GetKeyDown(KeyCode.E) && pickUp == true)
        {
            InventoryManager.Instance.AddItem(itemType);
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Si el jugador sale del trigger, el item deja de ser recogible
        if (collision.gameObject.tag == "Player")
        {
            pickUp = false;
        }
    }
}
