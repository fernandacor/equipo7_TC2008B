using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    //Script para el comportamiento de la barra de maná/energía
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetEnergy(float mana)
    {
        slider.value = mana;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void SetMaxEnergy(float mana)
    {
        slider.maxValue = mana;
        slider.value = mana;

        fill.color = gradient.Evaluate(1f);
    }
}
