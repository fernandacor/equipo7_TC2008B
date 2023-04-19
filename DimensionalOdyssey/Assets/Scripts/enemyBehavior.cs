using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehavior : MonoBehaviour
{
    private Transform enemy;
    private Rigidbody2D rb2D;
    private Vector2 movimiento;
    public float velocidad = 5f;
    public bool activeEnemy = false;
    public int currentHealth;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        enemy = GameObject.Find("Enemy").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // if (activeEnemy == true)
        // {
        // Vector3 direction = enemy.position - transform.position;
        // float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // //rb2D.rotation = angle;
        // direction.Normalize();
        // movimiento = direction;

        // animator.SetFloat("Horizontal", movimiento.x);
        // animator.SetFloat("Vertical", movimiento.y);
        // animator.SetFloat("Speed", movimiento.sqrMagnitude);

        if (currentHealth <= 0)
        {
            Destroy(gameObject, 3);
        }
    }

    void FixedUpdate()
    {
        moveCharacter(movimiento);
    }

    void moveCharacter(Vector2 direction)
    {
        rb2D.MovePosition((Vector2)transform.position + (direction * velocidad * Time.deltaTime));
    }

    // void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.gameObject.tag == "Player")
    //     {
    //         activeEnemy = true;
    //     }
    // }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Players Bullet")
        {
            currentHealth -= 1;
        }
    }
}
