using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerAnimations : MonoBehaviour
{
    // Elementos a buscar
    private Animator animator;
    private CharacterStats characterStats;
    private GameObject trajeInicial;

    void Start()
    {
        // Se buscan los elementos
        animator = GetComponent<Animator>();
        characterStats = GetComponent<CharacterStats>();
        trajeInicial = GameObject.FindGameObjectWithTag("Traje");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Si el jugador choca con el objeto "Traje", se activa la animación de cambio de outfit
        if (collision.gameObject.tag == "Traje")
        {
            Destroy(trajeInicial);
            Debug.Log("Traje destruido");
            animator.SetBool("CambioOutfit", true);
        }

        // Dependiendo de que pistola se tenga, se cambia la animación
        // if(collision.gameObject.tag == "Pistola")
        // {
        //     animator.SetBool("Pistola", true);
        // }

        // if(collision.gameObject.tag == "Escopeta")
        // {
        //     animator.SetBool("Escopeta", true);
        // }

        // if(collision.gameObject.tag == "Metralleta")
        // {
        //     animator.SetBool("Metralleta", true);
        // }
    }

    void Update()
    {
        // Si la salud del jugador es igual o menor a cero, se activa la animación de muerte
        if (characterStats.currentHealth <= 0)
        {
            animator.SetBool("Death", true);
        }
    }
}
