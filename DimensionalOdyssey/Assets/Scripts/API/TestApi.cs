using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking; 
using TMPro;

[System.Serializable]
public class User
{
    public string username;
    public string contrasena;
    public string correo;
    public string nombre;
    public string apellido;
}

public class Personaje
{
    public int idPersonaje;
    public int energia;
    public int xp;
    public int idArma;
    public int idPartida;
    public int velocidadMov;
    public int velocidadDis;
    public int vida;
    public int resistencia;
    public int recuperacionEn;
    public int roboVida; 
}

public class UserList
{
    public List<User> usuarios;
}

public class PersonajeList
{
    public List<Personaje> personajes;
}

public class TestApi: MonoBehaviour
{
    [SerializeField] string url;
    [SerializeField] string getUsersEP;
    [SerializeField] TMP_Text errorText;
    [SerializeField] TMP_InputField usernameInput;
    [SerializeField] TMP_InputField passwordInput;
    [SerializeField] TMP_InputField emailInput;
    [SerializeField] TMP_InputField nameInput;
    [SerializeField] TMP_InputField lastNameInput;
    [SerializeField] Button addButton;
    [SerializeField] Button getUsersButton;

    public UserList allUsers;
    public PersonajeList allPersonajes;

    void Start()
    {
        addButton.onClick.AddListener(InsertNewUser);
        getUsersButton.onClick.AddListener(QueryUsers);
    }

    public void QueryUsers()
    {
        StartCoroutine(GetUsers());
    }

    public void InsertNewUser()
    {
        User newUser = new User();
        newUser.username = usernameInput.text;
        newUser.contrasena = passwordInput.text;
        newUser.correo = emailInput.text;
        newUser.nombre = nameInput.text;
        newUser.apellido = lastNameInput.text;

        string jsonData = JsonUtility.ToJson(newUser);

        StartCoroutine(AddUser(jsonData));
    }

    IEnumerator GetUsers()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url + getUsersEP))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success) {
                Debug.Log("Response: " + www.downloadHandler.text);
                string jsonString = "{\"usuarios\":" + www.downloadHandler.text + "}";
                Debug.Log(jsonString);
                allUsers = JsonUtility.FromJson<UserList>(jsonString);
                DisplayUsers();
            } else {
                Debug.Log("Error: " + www.error);
                if (errorText != null) errorText.text = "Error: " + www.error;
            }
        }
    }

    IEnumerator AddUser(string jsonData)
    {
        using (UnityWebRequest www = UnityWebRequest.Put(url + getUsersEP, jsonData))
        {
            www.method = "POST";
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success) {
                Debug.Log("Response: " + www.downloadHandler.text);
                if (errorText != null) errorText.text = "Se han insertado los datos correctamente";
            } else {
                Debug.Log("Error: " + www.error);
                if (errorText != null) errorText.text = "Error: " + www.error;
            }
        }
    }

    IEnumerator UpdatePersonaje(int characterId, string jsonData)
    {
        using (UnityWebRequest www = UnityWebRequest.Put(url + "/" + characterId, jsonData))
        {
            www.method = "PUT";
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success) {
                Debug.Log("Response: " + www.downloadHandler.text);
                if (errorText != null) errorText.text = "Los datos del personaje se han actualizado correctamente";
            } else {
                Debug.Log("Error: " + www.error);
                if (errorText != null) errorText.text = "Error: " + www.error;
            }
        }
    }

    void DisplayUsers()
    {
        int x = 1;
        Debug.Log("Displaying users" + allUsers);
        errorText.text = "Usuarios: " + allUsers.usuarios.Count + "\n";
        for(int i = 0; i < allUsers.usuarios.Count; i++)
        {
            errorText.text += x + "-." + allUsers.usuarios[i].username + "\t";
            x++;
        }
    }
}
