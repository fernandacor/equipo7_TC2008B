// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.Networking; 
// using TMPro;

// [System.Serializable]
// public class PersonajeAPI
// {
//     public int idArma;
//     public float energia;
//     public float xp;
//     public float velocidadMov;
//     public float velocidadDis;
//     public float vida;
//     public float resistencia;
//     public float recuperacionEn;
//     public float enemiesKilled;
//     public float damageDealt;
//     public float coinsTaken;
// }

// public class UpdateApi : MonoBehaviour
// {
//     // Start is called before the first frame update
//     [SerializeField] string url;
//     [SerializeField] string updatePersonajeEP;
//     //[SerializeField] private CharacterStats characterStats;

//     void Start()
//     {
//         updateButton.onClick.AddListener(UpdateCharacter);
//     }

//     public void UpdateCharacter()
//     {
//         PersonajeAPI characterToUpdate = new PersonajeAPI();
//         characterToUpdate.energia = PlayerPrefs.GetFloat("Mana");
//         characterToUpdate.xp = PlayerPrefs.GetFloat("Experience");
//         characterToUpdate.velocidadMov = PlayerPrefs.GetFloat("VelMov");
//         characterToUpdate.velocidadDis = PlayerPrefs.GetFloat("VelDis");
//         characterToUpdate.vida = PlayerPrefs.GetFloat("Vida");
//         characterToUpdate.resistencia = PlayerPrefs.GetFloat("Resistence");
//         characterToUpdate.recuperacionEn = PlayerPrefs.GetFloat("RecovEne");
//         characterToUpdate.enemiesKilled = PlayerPrefs.GetFloat("EnemiesKilled");
//         characterToUpdate.damageDealt = PlayerPrefs.GetFloat("DañoCont");
//         characterToUpdate.coinsTaken = PlayerPrefs.GetFloat("ContMoney");
//         characterToUpdate.idPartida = 7;

//         string jsonData = JsonUtility.ToJson(characterToUpdate);

//         StartCoroutine(UpdatePersonaje(jsonData));
//     }

//     IEnumerator UpdatePersonaje(string jsonData)
//     {
//         using (UnityWebRequest www = UnityWebRequest.Put(url + updatePersonajeEP, jsonData))
//         {
//             www.method = "PUT";
//             www.SetRequestHeader("Content-Type", "application/json");
//             yield return www.SendWebRequest();

//             if (www.result == UnityWebRequest.Result.Success) {
//                 Debug.Log("Response: " + www.downloadHandler.text);
//                 if (errorText != null) errorText.text = "Se han actualizado los datos correctamente";
//             } else {
//                 Debug.Log("Error: " + www.error);
//                 if (errorText != null) errorText.text = "Error: " + www.error;
//             }
//         }
//     }

// }
