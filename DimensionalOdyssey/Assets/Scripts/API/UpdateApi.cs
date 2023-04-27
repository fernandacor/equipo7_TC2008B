using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking; 
using TMPro;

[System.Serializable]
public class PersonajeAPI
{
    public int energia;
    public int xp;
    public int idPartida;
    public int velocidadMov;
    public int velocidadDis;
    public int vida;
    public int resistencia;
    public int recuperacionEn;
    public int roboVida; 
    public int enemiesKilled;
}

public class UpdateApi : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] string url;
    [SerializeField] string updatePersonajeEP;
    [SerializeField] TMP_Text errorText;
    [SerializeField] TMP_InputField energiaInput;
    [SerializeField] TMP_InputField xpInput;
    [SerializeField] TMP_InputField partidaInput;
    [SerializeField] TMP_InputField movInput;
    [SerializeField] TMP_InputField disInput;
    [SerializeField] TMP_InputField vidaInput;
    [SerializeField] TMP_InputField resistenciaInput;
    [SerializeField] TMP_InputField recuperacionInput;
    [SerializeField] TMP_InputField roboInput;
    [SerializeField] TMP_InputField enemiesInput;
    [SerializeField] Button updateButton;

    void Start()
    {
        updateButton.onClick.AddListener(UpdateCharacter);
    }

    public void UpdateCharacter()
    {
        PersonajeAPI characterToUpdate = new PersonajeAPI();
        characterToUpdate.energia = int.Parse(energiaInput.text);
        characterToUpdate.xp = int.Parse(xpInput.text);
        characterToUpdate.velocidadMov = int.Parse(movInput.text);
        characterToUpdate.velocidadDis = int.Parse(disInput.text);
        characterToUpdate.vida = int.Parse(vidaInput.text);
        characterToUpdate.resistencia = int.Parse(resistenciaInput.text);
        characterToUpdate.recuperacionEn = int.Parse(recuperacionInput.text);
        characterToUpdate.roboVida = int.Parse(roboInput.text);
        characterToUpdate.enemiesKilled = int.Parse(enemiesInput.text);
        characterToUpdate.idPartida = int.Parse(partidaInput.text);

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
                if (errorText != null) errorText.text = "Se han actualizado los datos correctamente";
            } else {
                Debug.Log("Error: " + www.error);
                if (errorText != null) errorText.text = "Error: " + www.error;
            }
        }
    }

}
