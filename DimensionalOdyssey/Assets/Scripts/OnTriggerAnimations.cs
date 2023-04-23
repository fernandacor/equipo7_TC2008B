using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerAnimations : MonoBehaviour
{
    private Animator animator;
    //CambioOutfit
    public bool TrajePuesto;
    public GameObject traje;

    void Start()
    {
        animator = GetComponent<Animator>();
        TrajePuesto = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Traje")
        {
            animator.SetBool("CambioOutfit", true);
        }
    }
}
