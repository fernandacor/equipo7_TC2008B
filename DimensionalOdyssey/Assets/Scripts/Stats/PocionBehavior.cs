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
    [SerializeField] private AudioSource potionSFX;

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
            // Debug.Log("player detected");
            PickUp(collision);
            Destroy(gameObject);
        }
    }

    public void PickUp(Collider2D player)
    {
        switch (tipoPocion)
        {
            case InventoryManager.Pociones.pocionVida:
                characterStats.currentHealth += characterStats.maxHealth * 0.3f;
                healthBar.SetHealth(characterStats.currentHealth);
                break;
            case InventoryManager.Pociones.pocionSuperVida:
                characterStats.currentHealth += characterStats.maxHealth * 0.8f;
                healthBar.SetHealth(characterStats.currentHealth);
                break;
            case InventoryManager.Pociones.pocionEnergia:
                characterStats.currentMana += characterStats.maxMana * 0.3f;
                manaBar.SetEnergy(characterStats.currentMana);
                break;
            case InventoryManager.Pociones.pocionSuperEnergia:
                characterStats.currentMana += characterStats.maxMana * 0.8f;
                manaBar.SetEnergy(characterStats.currentMana);
                break;
            case InventoryManager.Pociones.xpBoost:
                characterStats.currentExperience += characterStats.maxExperience * 0.5f;
                break;
            case InventoryManager.Pociones.pocionVelocidad:
                characterStats.velocidadMovimiento *= 1.2f;
                break;
            case InventoryManager.Pociones.pocionResistencia:
                characterStats.resistencia *= 1.4f;
                break;
            case InventoryManager.Pociones.pocionFuerza:
                characterStats.dañoInfligido *= 1.5f;
                break;
        }
    }
}