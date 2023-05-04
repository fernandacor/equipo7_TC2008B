using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking; 
using TMPro;

[System.Serializable]
public class PersonajeAPI
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
    public int idPartida;
}

public class UpdateApi : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] string url = "http://127.0.0.1:5235";
    [SerializeField] string updatePersonajeEP = "/api/personajes";
    //[SerializeField] private CharacterStats characterStats;
    

    [SerializeField] private CharacterStats characterStats;
    [SerializeField] private WeaponSelection weaponSelection;

    void Start()
    {
        
    }


    public void UpdateCharacter()
    {
        PersonajeAPI characterToUpdate = new PersonajeAPI();

        characterToUpdate.idArma = weaponSelection.idArma;
        characterToUpdate.energia = characterStats.currentMana;
        characterToUpdate.xp = characterStats.currentExperience;
        characterToUpdate.velocidadMov = characterStats.velocidadMovimiento;
        characterToUpdate.velocidadDis = characterStats.velocidadDisparo;
        characterToUpdate.vida = characterStats.currentHealth;
        characterToUpdate.resistencia = characterStats.resistencia;
        characterToUpdate.recuperacionEn = characterStats.recoverEnergy;
        characterToUpdate.enemiesKilled = characterStats.enemigosMatados;
        characterToUpdate.damageDealt = characterStats.dañoInfligidoContador;
        characterToUpdate.coinsTaken = characterStats.monedasTiene;
        characterToUpdate.idPartida = 7;

        string jsonData = JsonUtility.ToJson(characterToUpdate);

        StartCoroutine(UpdatePersonaje(jsonData));
    }

    IEnumerator UpdatePersonaje(string jsonData)
    {
        using (UnityWebRequest www = UnityWebRequest.Put(url + updatePersonajeEP, jsonData))
        {
            www.method = "PUT";
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success) {
                Debug.Log("Response: " + www.downloadHandler.text);
                //if (errorText != null) errorText.text = "Se han actualizado los datos correctamente";
            } else {
                Debug.Log("Error: " + www.error);
                //if (errorText != null) errorText.text = "Error: " + www.error;
            }
        }
    }

}
