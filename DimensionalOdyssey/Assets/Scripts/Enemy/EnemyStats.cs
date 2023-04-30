using UnityEngine;

// Script que define las estadisticas de los enemigos

public class EnemyStats : MonoBehaviour
{
    // Referencia al script de estadisticas del jugador
    private CharacterStats characterStats;

    // Variables de salud maxima y salud actual
    public float maxHealth = 100;
    public float currentHealth;

    // Variables para velocidad de movimiento
    public float velocidadMovimiento;

    // Buscar el animador
    public Animator animator;

    void Start()
    {
        // Se define la salud inicial como la salud maxima
        currentHealth = maxHealth;

        // Se busca el script de estadisticas del jugador
        characterStats = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
    }

    void TakeDamage(float damage)
    {
        // Se le resta el daño a la salud del enemigo
        currentHealth -= damage;

        // Si la salud del enemigo es menor o igual a 0, se destruye
        if (currentHealth <= 0)
        {
            Destroy(gameObject, 2);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Si una bala del jugador colisiona con el enemigo, el enemigo recibe daño
        if (collision.CompareTag("Players Bullet"))
        {
            TakeDamage(characterStats.dañoInfligido);
        }
    }
}