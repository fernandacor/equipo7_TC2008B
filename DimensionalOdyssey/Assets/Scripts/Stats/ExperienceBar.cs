using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{
    //Script para el comportamiento de la barra de salud/vida
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetExp(float exp)
    {
        slider.value = exp;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
    
    public void SetMaxExp(float exp)
    {
        slider.maxValue = exp;
        slider.value = exp;

        fill.color = gradient.Evaluate(1f);
    }

}