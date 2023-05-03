using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PocionBehavior : MonoBehaviour
{
    [SerializeField] InventoryManager.Pociones tipoPocion;
    private GameObject player;
    private CharacterStats characterStats;
    private HealthBar healthBar;
    private ManaBar manaBar;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        characterStats = player.GetComponent<CharacterStats>();
        healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>();
        manaBar = GameObject.FindGameObjectWithTag("ManaBar").GetComponent<ManaBar>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("player detected");
            PickUp(collision);
            Destroy(gameObject);
        }
    }

    public void PickUp(Collider2D player)
    {
        switch (tipoPocion)
        {
            case InventoryManager.Pociones.pocionVelocidad:
                characterStats.velocidadMovimiento += 3;
                break;
            case InventoryManager.Pociones.xpBoost:
                characterStats.currentExperience += 10;
                break;
        }

        if (characterStats.currentMana < characterStats.maxMana)
        {
            switch (tipoPocion)
            {
                case InventoryManager.Pociones.pocionEnergia:
                    characterStats.currentMana += 10;
                    break;
                case InventoryManager.Pociones.pocionSuperEnergia:
                    characterStats.currentMana = characterStats.maxMana;
                    break;
            }
        }

        if (characterStats.currentHealth < characterStats.maxHealth)
        {
            switch(tipoPocion)
            {
                case InventoryManager.Pociones.pocionVida:
                    characterStats.currentHealth += 10;
                    break;
                case InventoryManager.Pociones.pocionSuperVida:
                    characterStats.currentHealth = characterStats.maxHealth;
                    break;
            }
        }
    }
}