using UnityEngine;

// Script que define las estadisticas de los enemigos

public class EnemyStats : MonoBehaviour
{
    // Variables de salud maxima y salud actual
    public int maxHealth = 100;
    public int currentHealth;

    // Variables para velocidad de movimiento
    public float velocidadMovimiento;

    // Buscar el animador
    public Animator animator;

    void Start()
    {
        // Se define la salud inicial como la salud maxima
        currentHealth = maxHealth;
    }

    void TakeDamage(int damage)
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