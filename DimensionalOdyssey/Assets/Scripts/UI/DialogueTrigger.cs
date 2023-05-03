using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogueScript;
    private bool playerDetected;

    [SerializeField] private AudioSource dialogueSFX;

    //Detect trigger with player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If we triggered the player enable playerDetected and show indicator
        if (collision.gameObject.tag == "Player")
        {
            //If detected, show indicator
            playerDetected = true;
            dialogueScript.ToggleIndicator(playerDetected);
            dialogueSFX.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //If we lost trigger player disable playerDetected and hide indicator
        if (collision.gameObject.tag == "Player")
        {
            //If not detected, hide indicator
            playerDetected = false;
            dialogueScript.ToggleIndicator(playerDetected);
            dialogueScript.EndDialogue();
        }
    }
    //While detected, if space is pressed, start Dialogue
    private void Update()
    {
        if (playerDetected && Input.GetKeyDown(KeyCode.Space))
        {
            dialogueScript.StartDialogue();
        }
    }

}
