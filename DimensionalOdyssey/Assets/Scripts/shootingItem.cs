using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingItem : MonoBehaviour
{
    // public float speed;

    // private void Update()
    // {
    //     transform.Translate(transform.right * transform.localScale.x * speed * Time.deltaTime);
    // }

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if(collision.tag == "Player")
    //         return;

    //     //Trigger the custom action on the other object IF it exists
    //     if(collision.GetComponent<shootingAction>())
    //         collision.GetComponent<shootingAction>().Action();
    //     //Destroy
    //     Destroy(gameObject);
    // ]

    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb2D;
    public float force;

    void Start ()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb2D = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb2D.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot + 90);
    }
}
