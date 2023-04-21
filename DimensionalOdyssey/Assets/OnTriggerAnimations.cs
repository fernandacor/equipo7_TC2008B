using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerAnimations : MonoBehaviour
{
    private Animator animator;
    //CambioOutfit
    public bool TrajePuesto;
    public GameObject traje;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        TrajePuesto = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Traje")
        {
            // Destroy(traje, 2);
            animator.SetBool("CambioOutfit", true);
            animator.SetBool("TrajePuesto", true);
            Debug.Log("Pirueta");
            // TrajePuesto = true;
            // Debug.Log("TrajePuesto = true");
        }
    }

    // void Update()
    // {
    //     if (TrajePuesto == true)
    //     {
    //         animator.SetBool("TrajePuesto", true);
    //         animator.SetBool("CambioOutfit", false);
    //         Debug.Log("TrajePuesto");
    //     }
    // }
}
