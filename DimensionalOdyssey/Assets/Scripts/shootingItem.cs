using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingItem : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        transform.Translate(transform.right * transform.localScale.x * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            return;

        //Trigger the custom action on the other object IF it exists
        if(collision.GetComponent<shootingAction>())
            collision.GetComponent<shootingAction>().Action();
        //Destroy
        Destroy(gameObject);
    }
}
