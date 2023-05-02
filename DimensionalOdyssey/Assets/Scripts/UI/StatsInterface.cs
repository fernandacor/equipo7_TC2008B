// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using TMP_Text;

// public class StatsInterface : MonoBehaviour
// {
//     public CharacterStats characterStats;
//     [SerializeField] public TMP_Text velocidad;
//     [SerialiceField] public TMP_Text vida;

//     // public Slider slider;
//     // public Gradient gradient;
//     // public Image fill;


//     public void Start()
//     {
//         characterStats = player.GetComponent<CharacterStats>();
//         velocidad = GameObject.FindGameObjectWithTag("Velocidad").GetComponent<TMP_Text>();
//         vida = GameObject.FindGameObjectWithTag("Vida").GetComponent<TMP_Text>();

//         //velocidad, vida, mana, daño hecho, resistencia , velocidad de ataque, regeneración de mana
//         // enemigos matados, daño infligido, 
//     }

//     public void Update()
//     {
//         velocidad.text = characterStats.velocidadMovimiento.ToString();
//         vida.text = characterStats.maxHealth.ToString();


//     }

//     public void SetCurrentStat(float stat)
//     {
//         slider.value = stat;
//         fill.color = gradient.Evaluate(slider.normalizedValue);
//     }
    
//     public void SetMaxStat(float stat)
//     {
//         slider.maxValue = stat;
//         slider.value = stat;

//         fill.color = gradient.Evaluate(1f);
//     }
// }
