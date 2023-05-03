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
    public float damage;

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
            PlayerPrefs.SetFloat("Vida", 30);
            maxHealth = PlayerPrefs.GetFloat("Vida"); //salud maxima
            PlayerPrefs.SetFloat("Mana", 30);
            maxMana = PlayerPrefs.GetFloat("Mana"); //energia maxima
            PlayerPrefs.SetFloat("Experience", 30);
            maxExperience = PlayerPrefs.GetFloat("Experience"); //cuanta experiencia necesitas para subir de nivel
            PlayerPrefs.SetFloat("Resistance", 0);
            resistencia = PlayerPrefs.GetFloat("Resistence"); //resistencia a daño 
            PlayerPrefs.SetFloat("VelDis", 0.5f);
            velocidadDisparo = PlayerPrefs.GetFloat("VelDis"); //que tan rapido disparas (creo?)
            PlayerPrefs.SetFloat("VelMov", 30);
            velocidadMovimiento = PlayerPrefs.GetFloat("VelMov"); //que tan rapido caminas
            PlayerPrefs.SetFloat("RecovEne", 3);
            recoverEnergy = PlayerPrefs.GetFloat("RecovEne"); //cuanta energia recuperas por segundo
            PlayerPrefs.SetFloat("damaDealt", 2);
            damage = PlayerPrefs.GetFloat("damaDealt"); //cuanto daño haces
            PlayerPrefs.SetFloat("DañoCont", 0);
            dañoInfligidoContador = PlayerPrefs.GetFloat("DañoCont");
            PlayerPrefs.SetFloat("ContMoney", 0);
            monedasTiene = PlayerPrefs.GetFloat("ContMoney");
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
        maxExperience += 10;
        Debug.Log("Level Up stats changed");
        AgregarPunto(true, true, true, true, true, true);
    }

    public void AgregarPunto(bool health_, bool mana_, bool resistance_, bool shootVel_, bool movementVel_, bool damage_)
    {
        if (health_)
            maxHealth += 10;
        if (mana_)
            maxMana += 10;
        if (resistance_)
            resistencia += 2;
        if (shootVel_)
            velocidadDisparo -= 0.2f;
        if (movementVel_)
            velocidadMovimiento += 2;
        if (damage_)
            damage += 2;
    }

    public void TakeDamage(float damage)
    {
        PlayerPrefs.SetFloat("Damage", damage);
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
        PlayerPrefs.SetFloat("EnemiesKilled", 0);
        enemigosMatados = PlayerPrefs.GetFloat("EnemiesKilled");
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

        if (collision.CompareTag("XP"))
        {
            currentExperience += 10;
            experienceBar.SetExp(currentExperience);
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

