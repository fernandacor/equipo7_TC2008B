using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private Transform player;
    private Rigidbody2D enemy;
    private Vector2 movimiento;
    public float velocidad = 5f;
    public bool activeEnemy = false;
    public Animator animator;
    public bool dropItems;
    public int currentHealth;
    public int maxHealth = 100;
    public GameObject droppedItem;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").transform;
        currentHealth = maxHealth;
        droppedItem.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (activeEnemy == true)
        {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //enemy.rotation = angle;
        direction.Normalize();
        movimiento = direction;

        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Speed", movimiento.sqrMagnitude);
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
