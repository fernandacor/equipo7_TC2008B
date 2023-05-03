using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{

    public CharacterStats characterStats;


    private void Update()
    {
         if (characterStats.currentHealth <= 0)
        {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
