using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script para el comportamiento de los enemigos
// Se define las estadisticas de movimiento, salud, y el daño que recibe de parte del jugador

public class EnemyBehavior : MonoBehaviour
{
    // Elementos a buscar
    private CharacterStats characterStats;
    private Rigidbody2D enemy;
    private Transform player;
    public Animator animator;

    // Variables
    private Vector2 movimiento; // movimiento enemigo
    public bool activeEnemy = true; // si es verdad, el enemigo persigue al jugador
    public float velocidad = 5f; // velocidad del enemigo
    public float currentHealth; // salud actual del enemigo
    public float maxHealth = 100; //salud maxima del enemigo
    public bool dropItems; // booleano que define si el enemigo tira un item al ser vencido
    public GameObject droppedItem; // objeto que tira el enemigo
    public bool isBoss = false; // booleano para indicar si el enemigo es un jefe o no

    void Start()
    {
        // Buscar elementos
        characterStats = GameObject.Find("Player").GetComponent<CharacterStats>();
        enemy = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").transform;

        if (gameObject.CompareTag("Boss"))
        {
            droppedItem = GameObject.FindGameObjectWithTag("PortalDropped");
            Debug.Log("Apareción el boss");
        }

        // Definir la salud actual del enemigo como la salud maxima
        currentHealth = maxHealth;

        // Si el enemigo tira un item, desactivar el objeto para que no sea visible
        if (dropItems)
            droppedItem.SetActive(false);
    }

    void Update()
    {
        // Si el enemigo está activo, su movimiento es hacia el jugador
        if (activeEnemy == true)
        {
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            direction.Normalize();
            movimiento = direction;

            // Si el enemigo es un jefe, se activa el animador de su movimiento
            if (isBoss == true)
            {
                animator.SetFloat("Horizontal", direction.x);
                animator.SetFloat("Vertical", direction.y);
                animator.SetFloat("Speed", movimiento.sqrMagnitude);
            }
        }
    }

    void FixedUpdate()
    {
        // Se llama la función de movimiento de personaje
        MoveCharacter(movimiento);
    }

    void MoveCharacter(Vector2 direction)
    {
        // Movimiento de la posicion del personaje
        enemy.MovePosition((Vector2)transform.position + (direction * velocidad * Time.deltaTime));
    }

    public void TakeDamage(float damage)
    {
        // Se le resta el daño hecho a la salud del enemigo
        currentHealth -= damage;

        // Si la salud del enemigo es menor a 0:
        if (currentHealth <= 0)
        {
            characterStats.MatarEnemigos(1); // Se suma uno al contador de enemigos matados del jugador
            // Debug.Log("Enemigo muerto");

            // Si el enemigo tira un item, se activa el objeto
            if (dropItems == true)
            {
                droppedItem.SetActive(true);
            }

            // Se destruye el enemigo
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Si una bala del jugador le pega al enemigo, el enemigo recibe daño y el daño hecho
        // se añade al contador de daño infligido del jugador
        if (collision.CompareTag("Player"))
        {
            TakeDamage(characterStats.dañoInfligido);
            characterStats.dañoInfligidoContador += characterStats.dañoInfligido;
        }
        else if (collision.CompareTag("Players Bullet"))
        {
            TakeDamage(characterStats.dañoInfligido);
            characterStats.dañoInfligidoContador += characterStats.dañoInfligido;
        }
    }
}
