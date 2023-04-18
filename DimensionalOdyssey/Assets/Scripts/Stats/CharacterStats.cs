using UnityEngine;

public class CharacterStats : MonoBehaviour
{
     public int maxHealth = 100;
     public int currentHealth{ get; private set; }

    public Stats vida;
    public Stats resistencia;
    public Stats Velocidad_de_movimiento;
    public Stats Velocidad_de_disparo;
    public Stats recuperacionEnergia;
    public Stats robodeVida;

    void Awake()
    {
         currentHealth = maxHealth;
    }
}
