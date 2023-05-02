using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking; 
using TMPro;

public class StatsIniciales
{
    public int idArma;
    public float energia;
    public float xp;
    public float velocidadMov;
    public float velocidadDis;
    public float vida;
    public float resistencia;
    public float recuperacionEn;
    public float enemiesKilled;
    public float damageDealt;
    public float coinsTaken;

}

public class StatsList
{
    public List<StatsIniciales> stats;
}

public class CrearStatsIniciales : MonoBehaviour
{
    private CharacterStats characterStats;
    [SerializeField] Button addButton;
    public int valorEnergia;
    public int valorXp;
    public int valorVelocidadMov;
    public int valorVelocidadDis;
    public int valorVida;
    public int valorResistencia;
    public int valorRecuperacionEn;
    public int valorDamageDealt;
    public int valorCoinsTaken;
    public string url = "http://127.0.0.1:5235";
    public string EP = "/api/addEstadisticas";
    // Start is called before the first frame update
    /*
    void Start()
    {
        characterStats = FindObjectOfType<CharacterStats>();
        addButton.onClick.AddListener(InsertStatsIniciales);
    } */

    public void InsertStatsIniciales()
    {
        StatsIniciales newStatsIniciales = new StatsIniciales();
        // aqui falta agregar los valores de las stats iniciales.
        newStatsIniciales.idArma = 1;
        newStatsIniciales.energia = 30;
        newStatsIniciales.xp = 0;
        newStatsIniciales.velocidadMov = 30;
        newStatsIniciales.velocidadDis = 3;
        newStatsIniciales.vida = 30;
        newStatsIniciales.resistencia = 0;
        newStatsIniciales.recuperacionEn = 3;
        newStatsIniciales.enemiesKilled = 0;
        newStatsIniciales.damageDealt = 0;
        newStatsIniciales.coinsTaken = 0;
        string jsonData = JsonUtility.ToJson(newStatsIniciales);
        Debug.Log(jsonData);
        StartCoroutine(AddStats(jsonData));
    }


    IEnumerator AddStats(string jsonData)
    {
        using (UnityWebRequest www = UnityWebRequest.Put(url + EP, jsonData))
        {
            www.method = "POST";
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success) {
                Debug.Log("Response: " + www.downloadHandler.text);
                //if (errorText != null) errorText.text = "Se han insertado las stats correctamente";
            } else {
                Debug.Log("Error: " + www.error);
                //if (errorText != null) errorText.text = "Error: " + www.error;
            }
        }
    }
}
