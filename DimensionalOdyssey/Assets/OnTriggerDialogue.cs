using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnTriggerDialogue : MonoBehaviour
{
    public GameObject Dialogue;
    public bool canInteract;
    public bool itemActive;
    public GameObject item;
    public GameObject item2;

    [SerializeField] private AudioSource muerteSFX;

    void Start()
    {
        Dialogue.SetActive(false);
        item.SetActive(false);
        item2.SetActive(false);
        itemActive = false;
    }

    void Update()
    {
        if (canInteract == true && Input.GetKeyDown(KeyCode.E))
        {
            itemActive = true;
            item.SetActive(true);
            item2.SetActive(true);
        }
        
        // if (Input.GetKeyDown(KeyCode.E) && canInteract == true && itemActive == true)
        // {
        //     item.SetActive(false);
        // }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player is in the trigger");
            Dialogue.SetActive(true);
            Debug.Log("Dialogue is active");
            canInteract = true;  
        }

        if (collision.gameObject.tag == "Sonido")
        {
            muerteSFX.Play();
            // muerteSFX.Stop();
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player is out of the trigger");
            Dialogue.SetActive(false);
            Debug.Log("Dialogue is inactive");
            canInteract = false;
            item.SetActive(false);
        }
    }
}
