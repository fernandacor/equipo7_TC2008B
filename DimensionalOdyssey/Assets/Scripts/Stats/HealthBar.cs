using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Script para el comportamiento de la barra de salud/vida

public class HealthBar : MonoBehaviour
{
    // Elementos que conforman la barra
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    // Funciones para definir la barra con la salud/vida actual
    public void SetHealth(float health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
    
    // Funciones para definir la barra con la salud/vida máxima
    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

}