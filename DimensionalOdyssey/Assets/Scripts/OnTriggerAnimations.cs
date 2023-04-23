using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerAnimations : MonoBehaviour
{
    private Animator animator;
    public CharacterStats characterStats;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Traje")
        {
            animator.SetBool("CambioOutfit", true);
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
