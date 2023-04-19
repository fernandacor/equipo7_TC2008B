using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portalBehavior : MonoBehaviour
{
    private Rigidbody2D rb2D;

    public bool switchScene = false;
    public string sceneName;

    public bool switchRoom = false;
    private bool playerDetected;
    [SerializeField] Transform posToGo;
    public GameObject player;
    public bool rotates;

    void Start()
    {
        if(rotates == true)
        {
            rb2D = GetComponent<Rigidbody2D>();
            rb2D.rotation = 0f;
        }

        playerDetected = false;
    }

    void Update()
    {
        if (playerDetected && switchRoom == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                player.transform.position = posToGo.position;
                playerDetected = false;
            }
        }
    }

    void FixedUpdate()
    {
        if(rotates == true)
        {
            rb2D.rotation += 1.0f;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && switchScene == true)
        {
            SceneManager.LoadScene(sceneName);
        }

        if (collision.gameObject.tag == "Player" && switchRoom == true)
        {
            playerDetected = true;
            player = collision.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerDetected = false;
        }
    }
}
