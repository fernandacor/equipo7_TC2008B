using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private Transform player;
    private Rigidbody2D enemyRB;
    private Vector2 movimiento;
    public float velocidad = 5f;
    // public bool activeEnemy = false;
    public Animator animator;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // if (activeEnemy == true)
        // {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        direction.Normalize();
        movimiento = direction;
        // }

        // if (GameObject.Find("Boss") && activeEnemy == true)
        if (GameObject.Find("Boss"))
        {
            animator.SetFloat("Horizontal", movimiento.x);
            animator.SetFloat("Vertical", movimiento.y);
            animator.SetFloat("Speed", movimiento.sqrMagnitude);
        }

        if (currentHealth <= 0)
        {
            Destroy(gameObject, 3);
        }
    }


    void FixedUpdate()
    {
        MoveCharacter(movimiento);
    }

    void MoveCharacter(Vector2 direction)
    {
        enemyRB.MovePosition((Vector2)transform.position + (direction * velocidad * Time.deltaTime));
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //     if (collision.gameObject.tag == "Player")
        //     {
        //         activeEnemy = true;
        //     }
        if (collision.gameObject.tag == "Players Bullet")
        {
            currentHealth -= 1;
        }
    }
}
