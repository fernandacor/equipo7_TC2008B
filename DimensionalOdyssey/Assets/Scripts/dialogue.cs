using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class dialogue : MonoBehaviour
{
    //Fields
    //Window
    public GameObject window;
    //Indicator
    public GameObject indicator;
    //Text component
    public TMP_Text dialogueText;
    //Dialogue list
    public List<string> dialogues;
    //Writing speed
    public float writingSpeed;
    //Index on dialogue
    private int Index;
    //Character index
    private int charIndex;
    //Started boolean
    private bool started;
    //Wait for next boolean
    private bool waitForNext;

    private void Awake()
    {
        //Hide window and show indicator
        ToggleWindow(false);
        ToggleIndicator(false);
    }

    public void ToggleWindow(bool show)
    {
        window.SetActive(show);
    }

    public void ToggleIndicator(bool show)
    {
        indicator.SetActive(show);
    }

    //Start dialogue
    public void StartDialogue()
    {
        if (started)
            return;

        //Boolean to indicate that we have started
        started = true;
        //Show window and hide indicator
        ToggleWindow(true);
        ToggleIndicator(false);
        //Start writing first dialogue
        GetDialogue(0);
    }

    private void GetDialogue(int i)
    {
        //Start index at 0
        Index = i;
        //Reset character index
        charIndex = 0;
        //Clear dialogue component text
        dialogueText.text = string.Empty;
        //Start writing
        StartCoroutine(Writing());
    }
    //End dialogue
    public void EndDialogue()
    {
        //Bool is disabled
        started = false;
        waitForNext = false;

        //Stop coroutines, IENumerators
        StopAllCoroutines();

        //Hide window
        ToggleWindow(false);

    }

    //Writing logic
    IEnumerator Writing()
    {
        //Wait x seconds
        yield return new WaitForSeconds(writingSpeed);
        //Restart the same process
        StartCoroutine(Writing());
        string currentDialogue = dialogues[Index];
        //Write the character
        dialogueText.text += currentDialogue[charIndex];
        //Increase the character index
        charIndex++;
        //Make sure you have reached the end of the sentence
        if (charIndex < currentDialogue.Length)
        {
            //Wait x seconds
            yield return new WaitForSeconds(writingSpeed);
            //Restart the same process
            StartCoroutine(Writing());
        }
        else
        {
            //End this sentence and wait for the next one
            waitForNext = true;
        }
    }

    private void Update()
    {  
        if(!started)
        {
            return;
        }

        if (waitForNext && Input.GetKeyDown(KeyCode.Space))
        {
            waitForNext = false;
            Index++;

            //Check if we are in the scope of dialogues List
            if(Index < dialogues.Count)
            {   
                //If so, fetch next dialogue
                GetDialogue(Index);
            }
            else
            {
                //If not, end dialogue process
                EndDialogue();
                ToggleIndicator(true);
            }
        }
    }

}
