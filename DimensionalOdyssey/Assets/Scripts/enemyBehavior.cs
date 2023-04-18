using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehavior : MonoBehaviour
{
    private Transform player;
    private Rigidbody2D enemy;
    private Vector2 movimiento;
    public float velocidad = 5f;
    public bool activeEnemy = false;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // if (activeEnemy == true)
        // {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //enemy.rotation = angle;
        direction.Normalize();
        movimiento = direction;

        // animator.SetFloat("Horizontal", movimiento.x);
        // animator.SetFloat("Vertical", movimiento.y);
        // animator.SetFloat("Speed", movimiento.sqrMagnitude);
        // }
    }

    void FixedUpdate()
    {
        moveCharacter(movimiento);
    }

    void moveCharacter(Vector2 direction)
    {
        enemy.MovePosition((Vector2)transform.position + (direction * velocidad * Time.deltaTime));
    }

    // void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.gameObject.tag == "Player")
    //     {
    //         activeEnemy = true;
    //     }
    // }
}
