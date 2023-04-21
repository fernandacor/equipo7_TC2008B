using UnityEngine;

public class CharacterStats : MonoBehaviour
{
     public HealthBar healthBar;
     public int maxHealth = 100;
     public int currentHealth;

     public ManaBar manaBar;
     public int maxMana = 100;
     public int currentMana;
     public int recuperacionMana;

     public Stats resistencia;
     public Stats velocidadMovimiento;
     public Stats velocidadDisparo;
     public Stats robodeVida;

     public Animator animator;

    void Start()
    {
          //Health Bar
         currentHealth = maxHealth;
         healthBar.SetMaxHealth(maxHealth);
         
         //Mana Bar
         currentMana = maxMana;
         manaBar.SetMaxEnergy(maxMana);
    }

     void TakeDamage(int damage)
     {
           currentHealth -= damage;
           healthBar.SetHealth(currentHealth);

           if (currentHealth <= 0)
           {
               Destroy(gameObject, 2);
           }
     }

     void LoseEnergy(int lostEnergy)
     {
          currentMana -= lostEnergy;
          manaBar.SetEnergy(currentMana);
     }

     void RecoverEnergy(int recoverEnergy)
     {
          currentMana += recoverEnergy;
          manaBar.SetEnergy(currentMana);

     }

     void Update()
     {
          // if (Input.GetKeyDown(KeyCode.T))
          // {
          //      TakeDamage(10);
          // }

          if (Input.GetKeyDown(KeyCode.Y))
          {
               LoseEnergy(10);
          }

          if (Input.GetKeyDown(KeyCode.U))
          {
               RecoverEnergy(10);
          }

          animator.SetFloat("Health", currentHealth);
     }

     void OnTriggerEnter2D(Collider2D collision)
     {
         if (collision.CompareTag("Enemy") || collision.CompareTag("Enemys Bullet"))
         {
             TakeDamage(10);
         }
     }
}

