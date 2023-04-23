using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    //ManaBar
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    //ManaPoints

    public void SetMaxEnergy(int energy)
    {
        //ManaBar
        slider.maxValue = energy;
        slider.value = energy;
        fill.color = gradient.Evaluate(1f);
    }

    public void SetEnergy(int energy)
    {
        //ManaBar
        slider.value = energy;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}