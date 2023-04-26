using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public CharacterStats characterStats;
    private Rigidbody2D enemy;
    public bool activeEnemy = true;
    public Transform player;
    private Vector2 movimiento;
    public float velocidad = 5f;
    public Animator animator;
    public int currentHealth;
    public int maxHealth = 100;
    public bool dropItems;
    public GameObject droppedItem;
    public bool isBoss = false;

    // Start is called before the first frame update
    void Start()
    {
        characterStats = GetComponent<CharacterStats>();
        enemy = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").transform;
        currentHealth = maxHealth;
        if (dropItems == true)
        {
            droppedItem.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (activeEnemy == true)
        {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        direction.Normalize();
        movimiento = direction;
        
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
        MoveCharacter(movimiento);
    }

    void MoveCharacter(Vector2 direction)
    {
        enemy.MovePosition((Vector2)transform.position + (direction * velocidad * Time.deltaTime));
    }

    void TakeDamage(int damage)
    {
           currentHealth -= damage;

           if (currentHealth <= 0)
           {
                characterStats.enemigosMatados += 1;
                Destroy(gameObject);

               if(dropItems == true)
               {
                droppedItem.SetActive(true);
               }
           }
    }

     void OnTriggerEnter2D(Collider2D collision)
     {
         if (collision.CompareTag("Players Bullet"))
         {
            activeEnemy = true;
            TakeDamage(10);
         }
     }
}
