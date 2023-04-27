using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenuScript : MonoBehaviour
{
public void PlayGame()
{
    SceneManager.LoadScene("Laboratory");
}

public void QuitGame()
{
    Debug.Log("QUIT!");
    Application.Quit();
}

public AudioMixer audioMixer;

public void SetVolume (float volume)
{
    audioMixer.SetFloat("volume", volume);
}
}
