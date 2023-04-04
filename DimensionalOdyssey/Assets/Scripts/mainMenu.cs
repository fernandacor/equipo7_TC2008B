using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("level_Lab");
    }

    public void Options()
    {
        SceneManager.LoadScene("options");
    }

    public void Credits()
    {
        SceneManager.LoadScene("credits");
    }
}
