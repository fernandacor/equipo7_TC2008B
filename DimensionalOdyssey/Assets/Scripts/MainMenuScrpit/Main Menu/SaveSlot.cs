using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using System.Text;


[System.Serializable]
public class PartidaAPI
{
    public int idPartida;
    public string username;
    public string fecha;
}

public class PartidaAPIList 
{
    public List<PartidaAPI> partidas;
}

public class SessionAPIResponse
{
    public string username;
}

public class SaveSlot : MonoBehaviour
{
    [Header("Profile")]
    [SerializeField] private string profileId = "";

    [Header("Content")]
    [SerializeField] private GameObject noDataContent;
    [SerializeField] private GameObject hasDataContent;
    [SerializeField] private TextMeshProUGUI percentageCompleteText;
    [SerializeField] private TextMeshProUGUI deathCountText;

    private Button saveSlotButton;
    private string lastPlayedDate = "";
    private string receivedCookie = "";

    public PartidaAPIList partidaAPIList;


    public string url = "http://127.0.0.1:5235";
    public string EP = "/api/partida";

    private void Awake() 
    {
        saveSlotButton = this.GetComponent<Button>();
        StartCoroutine(UpdateLastPlayedDate());
    }

    public void SetData(GameData data) 
    {
        // there's no data for this profileId
        if (data == null) 
        {
            noDataContent.SetActive(true);
            hasDataContent.SetActive(false);
        }
        // there is data for this profileId
        else 
        {
            noDataContent.SetActive(false);
            hasDataContent.SetActive(true);

            percentageCompleteText.text = lastPlayedDate;
            deathCountText.text = "";
        }
    }

    private IEnumerator GetUsernameFromSession()
    {
        // Crear la solicitud GET para el punto final de sesión
        UnityWebRequest request = UnityWebRequest.Get("http://127.0.0.1:5235/api/session");

        // Agregar la cookie a la solicitud
        request.SetRequestHeader("Cookie", receivedCookie);

        // Enviar la solicitud y esperar la respuesta
        yield return request.SendWebRequest();

        // Comprobar si la solicitud fue exitosa
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(request.error);
            yield break;
        }

        // Analizar la respuesta JSON y extraer el nombre de usuario
        string jsonResponse = request.downloadHandler.text;
        SessionAPIResponse sessionAPIResponse = JsonUtility.FromJson<SessionAPIResponse>(jsonResponse);
        string username = sessionAPIResponse.username;

        // Utilizar el nombre de usuario como sea necesario
        Debug.Log("Nombre de usuario: " + username);

        // Asignar el valor de la cookie recibida a receivedCookie
        string cookie = request.GetResponseHeader("Set-Cookie");
        receivedCookie = cookie.Substring(0, cookie.IndexOf(";"));

    }

    private IEnumerator UpdateLastPlayedDate()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url + EP))
        {
            www.SetRequestHeader("Cookie", receivedCookie);
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Response: " + www.downloadHandler.text);
                string jsonResult = www.downloadHandler.text;
                PartidaAPIList partidaAPIList = JsonUtility.FromJson<PartidaAPIList>(jsonResult);

                if (partidaAPIList.partidas.Count > 0)
                {
                    DateTime lastPlayedDateTime = DateTime.Parse(partidaAPIList.partidas[partidaAPIList.partidas.Count - 1].fecha);
                    lastPlayedDate = "Last Played: " + lastPlayedDateTime.ToString("yyyy/MM/dd");
                }
                else
                {
                    lastPlayedDate = "Empty";
                }
            }
            else
            {
                Debug.LogError(www.error);
            }
            
            // Actualizar los textos de los objetos una vez que se han obtenido los datos
            UpdateTexts();
        }
    }


    private void UpdateTexts()
    {
        percentageCompleteText.text = lastPlayedDate;
        deathCountText.text = "";
    }

    public string GetProfileId() 
    {
        return this.profileId;
    }

    public void SetInteractable(bool interactable)
    {
        saveSlotButton.interactable = interactable;
    }
}