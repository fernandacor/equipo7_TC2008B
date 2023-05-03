using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking; 
using TMPro;

[System.Serializable]
public class Partida
{
    public int idPartida;
    public string username;
    public string fecha;
}

public class LoadGameSlot : MonoBehaviour
{
    public TextMeshProUGUI[] slotTexts;
    private List<Partida> partidas;
    private const string url = "http://127.0.0.1:5235";
    private const string EP = "/api/partida";

    void Start()
    {
        StartCoroutine(GetPartidas());
    }

    private IEnumerator GetPartidas()
    {
        UnityWebRequest www = UnityWebRequest.Get(url + EP);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Response: " + www.downloadHandler.text);
            partidas = JsonUtility.FromJson<List<Partida>>(www.downloadHandler.text);
            UpdateUI();
        }
        else
        {
            Debug.LogError(www.error);
        }
    }

    private void UpdateUI()
    {
        for (int i = 0; i < slotTexts.Length; i++)
        {
            if (i < partidas.Count)
            {
                slotTexts[i].text = partidas[i].fecha;
            }
            else
            {
                slotTexts[i].text = "Empty";
            }
        }
    }
}
