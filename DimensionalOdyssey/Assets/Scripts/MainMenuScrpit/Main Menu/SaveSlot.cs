using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using TMPro;
using System.Linq;


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
    //private List<string> lastPlayedDate = new List<string>();
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


    private IEnumerator UpdateLastPlayedDate()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url + EP))
        {
            www.SetRequestHeader("Cookie", receivedCookie);
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Response: " + www.downloadHandler.text);
                string jsonString = "{\"partidas\":" + www.downloadHandler.text + "}";
                Debug.Log(jsonString);
                partidaAPIList = JsonUtility.FromJson<PartidaAPIList>(jsonString);

                if (partidaAPIList.partidas.Count > 0)
                {
                    DateTime lastPlayedDateTime = DateTime.MinValue;
                    foreach (PartidaAPI partida in partidaAPIList.partidas)
                    {
                        DateTime partidaDateTime = DateTime.Parse(partida.fecha);
                        if (partidaDateTime > lastPlayedDateTime)
                        {
                            lastPlayedDateTime = partidaDateTime;
                        }
                    }
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
        percentageCompleteText.text = string.Join(", ", lastPlayedDate);
        deathCountText.text = "";
    }

   /*private IEnumerator UpdateLastPlayedDate()
    {
        for (int i = 1; i <= 4; i++)
        {
            using (UnityWebRequest www = UnityWebRequest.Get(url + EP + "/" + i))
            {
                www.SetRequestHeader("Cookie", receivedCookie);
                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.Success)
                {
                    Debug.Log("Response: " + www.downloadHandler.text);
                    string jsonString = "{\"partidas\":" + www.downloadHandler.text + "}";
                    Debug.Log(jsonString);
                    partidaAPIList = JsonUtility.FromJson<PartidaAPIList>(jsonString);

                    if (partidaAPIList.partidas.Count > 0)
                    {
                        DateTime lastPlayedDateTime = DateTime.MinValue;
                        foreach (PartidaAPI partida in partidaAPIList.partidas)
                        {
                            DateTime partidaDateTime = DateTime.Parse(partida.fecha);
                            if (partidaDateTime > lastPlayedDateTime)
                            {
                                lastPlayedDateTime = partidaDateTime;
                            }
                        }
                        // Agregar la fecha de la última partida a la lista lastPlayedDate
                        lastPlayedDate.Add(lastPlayedDateTime.ToString("yyyy/MM/dd"));
                    }
                    else
                    {
                        // Agregar "Empty" a la lista lastPlayedDate si no hay partidas
                        lastPlayedDate.Add("Empty");
                    }
                }
                else
                {
                    Debug.LogError(www.error);
                    // Agregar "Error" a la lista lastPlayedDate si hay un error en la solicitud
                    lastPlayedDate.Add("Error");
                }
            }
        }
        
        // Actualizar los textos de los objetos una vez que se han obtenido los datos
        UpdateTexts();
    }

    public void SetData(GameData data) 
    {
        if (lastPlayedDate.Count == 0 || lastPlayedDate.All(s => s == "Empty"))
        {
            noDataContent.SetActive(true);
            hasDataContent.SetActive(false);
            percentageCompleteText.text = "Empty";
            deathCountText.text = "";
        }
        else
        {
            noDataContent.SetActive(false);
            hasDataContent.SetActive(true);
            percentageCompleteText.text = "Last Played: " + lastPlayedDate.Last();
            deathCountText.text = "";
        }
    }*/

    public string GetProfileId() 
    {
        return this.profileId;
    }

    public void SetInteractable(bool interactable)
    {
        saveSlotButton.interactable = interactable;
    }
}