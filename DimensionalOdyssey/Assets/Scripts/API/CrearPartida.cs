using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking; 
using TMPro;

public class CrearPartida : MonoBehaviour
{
    [SerializeField] Button addButton;
    public string url = "http://127.0.0.1:5235";
    public string EP = "/api/partida";
    // Start is called before the first frame update
    void Start()
    {
        addButton.onClick.AddListener(InsertNewPartida);
    }

    // Update is called once per frame

    public void InsertNewPartida()
    {
        StartCoroutine(AddPartida());
    }

    IEnumerator AddPartida()
    {
        using (UnityWebRequest www = UnityWebRequest.Post(url + EP, ""))
        {
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success) {
                Debug.Log("Response: " + www.downloadHandler.text);
                Debug.Log("Se ha creado la partida de manera exitosa.");
                //if (errorText != null) errorText.text = "Se ha creado la partida exitosamente";
            } else {
                Debug.Log("Error: " + www.error);
                //if (errorText != null) errorText.text = "Error: " + www.error;
            }
        }
    }
}
