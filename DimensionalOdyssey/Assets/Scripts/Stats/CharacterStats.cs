using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    private ExperienceBar experienceBar;
    public float maxExperience;
    public float currentExperience;
    public int level;

    private HealthBar healthBar;
    public float maxHealth;
    public float currentHealth;

    private ManaBar manaBar;
    public float maxMana;
    public float currentMana;
    public float useMana;
    public float recoverEnergy;

    //public MovimientoPersonaje movimientoPersonaje;
    public float velocidadMovimiento;

    public float resistencia;
    public float velocidadDisparo;
    public float dañoInfligido;

    public float enemigosMatados; //counter de cuantos enemigos mata
    public float dañoInfligidoContador; //contador de daño hecho a enemigos
    public float dañoRecibido; // contador de daño recibido
    public float monedasTiene; //cuantas monedas tiene

    // Animación de muerte
    private Animator animator;

    public void Start()
    {
        level = 1;

        if (level == 1)
        {
            maxHealth = 30; //salud maxima
            maxMana = 30; //energia maxima
            maxExperience = 30; //cuanta experiencia necesitas para subir de nivel
            resistencia = 0; //resistencia a daño 
            velocidadDisparo = 3; //que tan rapido disparas (creo?)
            velocidadMovimiento = 30; //que tan rapido caminas
            recoverEnergy = 3; //cuanta energia recuperas por segundo
            dañoInfligido = 2; //cuanto daño haces
        }

        animator = GetComponent<Animator>();

        //Health Bar
        healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        //Mana Bar
        manaBar = GameObject.FindGameObjectWithTag("ManaBar").GetComponent<ManaBar>();
        currentMana = maxMana;
        manaBar.SetMaxEnergy(maxMana);

        //Experience Bar
        experienceBar = GameObject.FindGameObjectWithTag("ExperienceBar").GetComponent<ExperienceBar>();
        experienceBar.SetMaxExp(maxExperience);
        experienceBar.SetExp(currentExperience);


        StartCoroutine(ManaRecovery());
    }

    public void levelUp()
    {
        Debug.Log("Level Up:");
        currentExperience -= maxExperience;
        experienceBar.SetMaxExp(maxExperience);
        experienceBar.SetExp(currentExperience);
        level += 1;
        maxHealth += 10;
        maxMana += 10;
        resistencia += 2;
        velocidadDisparo += 2;
        velocidadMovimiento += 2;
        maxExperience += 10;
        dañoInfligido += 2;
        Debug.Log("Level Up stats changed");
    }

    public void TakeDamage(float damage)
    {
        damage = damage - resistencia;
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        dañoRecibido += damage;
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

    public void MatarEnemigos(int cantidad)
    {
        enemigosMatados += cantidad;
        currentExperience += 10;
    }

    public void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Y))
        // {
        //     LoseEnergy(10);
        // }

        // if (Input.GetKeyDown(KeyCode.U))
        // {
        //     RecoverEnergy(10);
        // }

        // if (Input.GetKeyDown(KeyCode.I))
        // {
        //     TakeDamage(10);
        // }

        experienceBar.SetExp(currentExperience);

        animator.SetFloat("Health", currentHealth);
        // animator.SetBool("LevelUp", levelUp);

        if (currentExperience >= maxExperience)
        {
            experienceBar.SetMaxExp(maxExperience);
            Debug.Log("Experience reached max");
            levelUp();
            Debug.Log("Call levelUp function");
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemys Bullet"))
        {
            TakeDamage(10);
        }

        if (collision.CompareTag("Enemy"))
        {
            TakeDamage(5);
        }

        if (collision.CompareTag("Coin"))
        {
            monedasTiene += 1;
            currentExperience += 1;
        }
    }

    public IEnumerator ManaRecovery()
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

