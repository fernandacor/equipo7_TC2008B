using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalBehavior : MonoBehaviour
{
    public bool switchScene; // Booleano que indica si el portal cambia de escena. Si no, cambia de cuarto
    public string sceneName; // Nombre de la escena a la que se cambia

    private bool playerDetected; // Booleano que indica si el jugador está en el portal
    [SerializeField] Transform posToGo; // Posicion a la que se mueve el jugador
    private GameObject player; // Referencia al jugador
    [SerializeField] private AudioSource portalSFX; // SFX de portal

    [SerializeField] private UpdateApi updateApi;


    void Start()
    {
        // Inicialmente, el jugador no se detecta
        playerDetected = false;
    }

    void Update()
    {
        // Si el jugador se detecta, no se quiere cambiar de escena, y se pica la tecla E:
        if (playerDetected && !switchScene)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Se mueve al jugador a la posición indicada, y se desconoce al jugador
                player.transform.position = posToGo.position;
                playerDetected = false;
            }
        }
    }

    IEnumerator LoadSceneDelayed(string sceneName, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        // Si el jugador entra en el trigger y se quiere cambiar de escena:
        if (collision.gameObject.CompareTag("Player") && switchScene)
        {
            // portalSFX.Play(); // Se reproduce el SFX de portal
            Debug.Log("UpdateApi: ");
            StartCoroutine(LoadSceneDelayed(sceneName, 1.5f));
            //SceneManager.LoadScene(sceneName); // Se cambia de escena
            // UpdateApi updateApi = GetComponent<UpdateApi>();
            // updateApi.UpdateCharacter();
        }
        // Si no se quiere cambiar de escena:
        else if (collision.gameObject.CompareTag("Player") && !switchScene)
        {
            // UpdateApi updateApi = GetComponent<UpdateApi>();
            // updateApi.UpdateCharacter();
            playerDetected = true; // Se detecta al jugador
            player = collision.gameObject; // Se guarda una referencia al jugador
            portalSFX.Play(); // Se reproduce el SFX de portal
        }

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        // Si el jugador sale del trigger del portal, se desconoce al jugador
        if (collision.gameObject.tag == "Player")
        {
            playerDetected = false;
        }
    }
}
