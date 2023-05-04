using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{

    private CharacterStats characterStats;

    void Awake()
    {
        characterStats = GameObject.Find("Player").GetComponent<CharacterStats>();
    }

    private void Update()
    {
        if (characterStats.currentHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
