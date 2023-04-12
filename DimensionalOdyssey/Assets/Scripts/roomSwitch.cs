using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomSwitch : MonoBehaviour
{
    private bool playerDetected;
    [SerializeField] Transform posToGo;
    public GameObject playerGO;

    // Start is called before the first frame update
    void Start()
    {
        playerDetected = false;   
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerDetected)
        {
            //if (Input.GetKeyDown(KeyCode.E))
            //{
                playerGO.transform.position = posToGo.position;
                playerDetected = false;
            //}
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerDetected = true;
            playerGO = collision.gameObject;
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
