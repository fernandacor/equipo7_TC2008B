using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    private HealthBar healthBar;
    public int maxHealth = 100;
    public int currentHealth;

    private ManaBar manaBar;
    public int maxMana = 100;
    public int currentMana;
    public int useMana;
    public int recuperacionMana;

    //public MovimientoPersonaje movimientoPersonaje;
    public float velocidadMovimiento = 20;

    public float resistencia;
    public float velocidadDisparo;
    public float robodeVida;

    // Animación de muerte
    private Animator animator;

    void Awake()
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
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void LoseEnergy(int lostEnergy)
    {
        currentMana -= lostEnergy;
        manaBar.SetEnergy(currentMana);
    }

    public void RecoverEnergy(int recoverEnergy)
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
}

