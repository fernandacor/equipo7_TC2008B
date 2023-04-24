using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PocionBehavior : MonoBehaviour
{
    [SerializeField] InventoryManager.Pociones tipoPocion;
    private GameObject player;
    private CharacterStats characterStats;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        characterStats = player.GetComponent<CharacterStats>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("player detected");
            PickUp(collision);
        }
    }

    public void PickUp(Collider2D player)
    {
        switch (tipoPocion)
        {
            case InventoryManager.Pociones.pocionVelocidad:
                characterStats.velocidadMovimiento += 3;
                break;
            case InventoryManager.Pociones.pocionEnergia:
                characterStats.currentMana += 10;
                break;
            case InventoryManager.Pociones.pocionSuperEnergia:
                characterStats.currentMana += 20;
                break;
            case InventoryManager.Pociones.pocionVida:
                characterStats.currentHealth += 10;
                break;
            case InventoryManager.Pociones.pocionSuperVida:
                characterStats.currentHealth += 20;
                break;
            default:
                break;
        }

        Destroy(gameObject);
    }
}