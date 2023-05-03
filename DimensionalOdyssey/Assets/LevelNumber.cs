using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelNumber : MonoBehaviour
{
    public TMP_Text levelNumber;
    private CharacterStats characterStats;

    void Start()
    {
        characterStats = GameObject.Find("Player").GetComponent<CharacterStats>();

    }

    void Update()
    {
        levelNumber.text = (characterStats.level).ToString();
    }
}
