using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerAnimations : MonoBehaviour
{
    // Elementos a buscar
    private Animator animator;
    private CharacterStats characterStats;
    private GameObject trajeInicial;

    private GameManager gameManager;

    [SerializeField] private AudioSource muerteSFX;

    void Start()
    {
        // Se buscan los elementos
        animator = GetComponent<Animator>();
        characterStats = GetComponent<CharacterStats>();
        trajeInicial = GameObject.FindGameObjectWithTag("Traje");

        gameManager = GameManager.instance;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Si el jugador choca con el objeto "Traje", se activa la animación de cambio de outfit
        if (collision.gameObject.tag == "Traje")
        {
            Debug.Log("Traje encontrado");
            animator.SetBool("CambioOutfit", true);
            Debug.Log("Animación de cambio de outfit activada");
            Destroy(trajeInicial);
        }
    }

    void Update()
    {
        // Si la salud del jugador es igual o menor a cero, se activa la animación de muerte
        if (characterStats.currentHealth <= 0)
        {
            animator.SetBool("Death", true);
            gameManager.SetGameState(GameState.Death);
            muerteSFX.Play();
        }
        else{
            gameManager.SetGameState(GameState.Playing);
        }
    }
}
