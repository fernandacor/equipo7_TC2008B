using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public float resistencia;
    public float velocidadMovimiento;
    public float velocidadDisparo;
    public float robodeVida;

    public Animator animator;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Destroy(gameObject, 2);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Players Bullet"))
        {
            TakeDamage(10);
        }
    }
}