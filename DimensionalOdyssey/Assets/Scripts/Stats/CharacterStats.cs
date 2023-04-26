using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    private HealthBar healthBar;
    public float maxHealth = 100;
    public float currentHealth;

    private ManaBar manaBar;
    public float maxMana = 100;
    public float currentMana;
    public float useMana;
    public float recoverEnergy = 30;

    //public MovimientoPersonaje movimientoPersonaje;
    public float velocidadMovimiento = 20;

    public float resistencia;
    public float velocidadDisparo;

    public float enemigosMatados; //counter de cuantos enemigos mata
    public float dañoInfligido; //contados de daño hecho a enemigos
    public float dañoRecibido; //
    public float monedasTiene; //cuantas monedas tiene

    // Animación de muerte
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        //Health Bar
        healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        //Mana Bar
        manaBar = GameObject.FindGameObjectWithTag("ManaBar").GetComponent<ManaBar>();
        currentMana = maxMana;
        manaBar.SetMaxEnergy(maxMana);

        StartCoroutine(ManaRecovery());
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void LoseEnergy(float lostEnergy)
    {
        currentMana -= lostEnergy;
        manaBar.SetEnergy(currentMana);
    }

    public void RecoverEnergy(float recoverEnergy)
    {
        currentMana += recoverEnergy;
        manaBar.SetEnergy(currentMana);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            LoseEnergy(10);
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            RecoverEnergy(10);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            TakeDamage(10);
        }

        animator.SetFloat("Health", currentHealth);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemys Bullet"))
        {
            TakeDamage(10);
        }

        if (collision.CompareTag("Enemy"))
        {
            TakeDamage(5);
        }
    }

    IEnumerator ManaRecovery()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (currentMana < maxMana)
            {
                RecoverEnergy(recoverEnergy);
            }
        }
    }
}

