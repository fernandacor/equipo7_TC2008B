using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Script para el comportamiento de la barra de maná/energía

public class ManaBar : MonoBehaviour
{
    // Elementos que conforman la barra
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    // Funciones para definir la barra con la maná/energía actual
    public void SetEnergy(float mana)
    {
        slider.value = mana;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    // Funciones para definir la barra con la maná/energía máxima
    public void SetMaxEnergy(float mana)
    {
        slider.maxValue = mana;
        slider.value = mana;

        fill.color = gradient.Evaluate(1f);
    }
}
