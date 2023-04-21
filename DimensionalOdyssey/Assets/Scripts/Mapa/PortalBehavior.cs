using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalBehavior : MonoBehaviour
{
    public bool switchScene = false;
    public string sceneName;

    public bool switchRoom = false;
    private bool playerDetected;
    [SerializeField] Transform posToGo;
    public GameObject player;


    void Start()
    {
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
