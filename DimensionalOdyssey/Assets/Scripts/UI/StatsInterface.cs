using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsInterface : MonoBehaviour
{
    public CharacterStats characterStats;
    [SerializeField] public GameObject velocidad;
    [SerializeField] public GameObject vida;

    public Slider slider;
    public Gradient gradient;
    public Image fill;


    public void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        characterStats = player.GetComponent<CharacterStats>();
        velocidad = GameObject.FindGameObjectWithTag("Velocidad").GetComponent<GameObject>();
        vida = GameObject.FindGameObjectWithTag("Vida").GetComponent<GameObject>();

        //velocidad, vida, mana, daño hecho, resistencia , velocidad de ataque, regeneración de mana
        // enemigos matados, daño infligido, 
    }

    // public void Update()
    // {
    //     velocidad = characterStats.velocidadMovimiento.ToString();
    //     vida = characterStats.maxHealth.ToString();
    // }

    // public void SetCurrentStat(float stat)
    // {
    //     slider.value = stat;
    //     fill.color = gradient.Evaluate(slider.normalizedValue);
    // }
    
    // public void SetMaxStat(float stat)
    // {
    //     slider.maxValue = stat;
    //     slider.value = stat;

    //     fill.color = gradient.Evaluate(1f);
    // }
}
