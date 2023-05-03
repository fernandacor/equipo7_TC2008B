using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{

    [SerializeField] InventoryManager.AllItems requiredItem;

    // Booleanos que definen caracteristicas de la puerta
    public bool isDoorOpen = false; // si esta abierta o no
    public bool doorHorizontal = false; // si se abre horizontalmente
    public bool doorVertical = false; // si se abre verticalmente

    // Vectores para la posicion de la puerta abierta y cerrada
    Vector3 doorClosedPos;
    Vector3 doorOpenPos;

    // Velocidad a la que se abre la puerta
    float doorOpenSpeed = 10f;

    void Awake()
    {
        // Puertas en posicion cerrada   
        doorClosedPos = transform.position;

        // Si la puerta es horizontal, se desplaza sobre el eje x
        if (doorHorizontal == true)
        {
            doorOpenPos = new Vector3(transform.position.x + 13f, transform.position.y, transform.position.z);
        }
        // Si la puerta es vertical, se desplaza sobre el eje y
        else if (doorVertical == true)
        {
            doorOpenPos = new Vector3(transform.position.x, transform.position.y + 13f, transform.position.z);
        }
    }

    void OpenDoor()
    {
        // Si la posicion actual de la puerta no es la posicion abierta, se mueve hacia ella
        if (transform.position != doorOpenPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, doorOpenPos, doorOpenSpeed * Time.deltaTime);
        }

    }

    void CloseDoor()
    {
        // Si la posicion actual de la puerta no es la posicion cerrada, se mueve hacia ella
        if (transform.position != doorClosedPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, doorClosedPos, doorOpenSpeed * Time.deltaTime);
        }
    }

    public bool HasRequiredItem(InventoryManager.AllItems itemRequired)
    {
        // Se checa si el item requerido para abrir la puerta está en el inventario
        if (InventoryManager.Instance._inventoryItems.Contains(itemRequired))
        {
            return true;
        }
        else // Si no, se regresa false
        {
            return false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si el jugador entra en el trigger y se tiene el item requerido, isDoorOpen se vuelve true
        if (collision.CompareTag("Player"))
        {
            if (HasRequiredItem(requiredItem) == true)
            {
                isDoorOpen = !isDoorOpen;
            }
        }
    }

    public void Update()
    {
        // Si la puerta se puede abrir, se abre
        if (isDoorOpen)
        {
            OpenDoor();
        }
        // Si no, se mantiene cerrada
        else
        {
            CloseDoor();
        }
    }
}
