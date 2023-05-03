using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking; 
using TMPro;

[System.Serializable]
public class Partidas
{
    public int idPartida;
    public string username;
    public string fecha;
}

public class PartidaList 
{
    public List<Partidas> partidas;
}

public class CrearPartida : MonoBehaviour
{
    [SerializeField] Button addButton;
    public string url = "http://127.0.0.1:5235";
    public string EP = "/api/partida";
    public PartidaList partidas;

    [SerializeField] private CrearStatsIniciales crearStatsIniciales;
    // Start is called before the first frame update
    void Start()
    {
        crearStatsIniciales = FindObjectOfType<CrearStatsIniciales>();
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
                crearStatsIniciales.InsertStatsIniciales();
            } else {
                Debug.Log("Error: " + www.error);
                //if (errorText != null) errorText.text = "Error: " + www.error;
            }
        }
    }

    private IEnumerator GetPartida()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url + EP))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Response: " + www.downloadHandler.text);
                string jsonString = "{\"partidas\":" + www.downloadHandler.text + "}";
                Debug.Log(jsonString);
                partidas = JsonUtility.FromJson<PartidaList>(jsonString);

            }
            else
            {
                Debug.LogError(www.error);
            }
            // Actualizar los textos de los objetos una vez que se han obtenido los datos
        }
    }
}
