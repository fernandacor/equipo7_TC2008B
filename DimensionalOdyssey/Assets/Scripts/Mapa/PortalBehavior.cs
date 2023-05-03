using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalBehavior : MonoBehaviour
{
    public bool switchScene; 
    public string sceneName;

    private bool playerDetected;
    [SerializeField] Transform posToGo;
    private GameObject player;
    [SerializeField] private AudioSource portalSFX;


    void Start()
    {
        playerDetected = false;
    }

    void Update()
    {
        if (playerDetected && !switchScene)
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
        if (collision.gameObject.CompareTag("Player") && switchScene)
        {
            SceneManager.LoadScene(sceneName);
            portalSFX.Play();
        }
        else if (collision.gameObject.CompareTag("Player") && !switchScene)
        {
            playerDetected = true;
            player = collision.gameObject;
            portalSFX.Play();
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
