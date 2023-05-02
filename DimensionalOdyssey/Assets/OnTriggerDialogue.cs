using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnTriggerDialogue : MonoBehaviour
{
    public GameObject Dialogue;

    void Start()
    {
        Dialogue.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player is in the trigger");
            Dialogue.SetActive(true);
            Debug.Log("Dialogue is active");
        }
    }
}
