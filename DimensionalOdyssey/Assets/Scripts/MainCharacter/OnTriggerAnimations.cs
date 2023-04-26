using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerAnimations : MonoBehaviour
{
    private Animator animator;
    private CharacterStats characterStats;

    void Start()
    {
        animator = GetComponent<Animator>();
        characterStats = GetComponent<CharacterStats>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Traje")
        {
            animator.SetBool("CambioOutfit", true);
        }

        if(collision.gameObject.tag == "Pistola")
        {
            animator.SetBool("Pistola", true);
        }

        if(collision.gameObject.tag == "Escopeta")
        {
            animator.SetBool("Escopeta", true);
        }

        if(collision.gameObject.tag == "Metralleta")
        {
            animator.SetBool("Metralleta", true);
        }
    }

    void Update()
    {
        if (characterStats.currentHealth <= 0)
        {
            animator.SetBool("Death", true);
        }
    }
}
