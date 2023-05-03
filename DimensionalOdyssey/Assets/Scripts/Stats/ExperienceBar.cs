using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Script para el comportamiento de la barra de experiencia

public class ExperienceBar : MonoBehaviour
{
    // Elementos que conforman la barra
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    // Funciones para definir la barra con la experiencia actual
    public void SetExp(float exp)
    {
        slider.value = exp;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    // Funciones para definir la barra con la experiencia máxima
    public void SetMaxExp(float exp)
    {
        slider.maxValue = exp;
        slider.value = exp;

        fill.color = gradient.Evaluate(1f);
    }

}