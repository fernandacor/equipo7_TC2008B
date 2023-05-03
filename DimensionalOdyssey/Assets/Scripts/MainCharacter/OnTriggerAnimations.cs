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

    [SerializeField] private AudioSource muerteSFX; // Espacio para efecto de sonido

    void Start()
    {
        // Se buscan los elementos
        animator = GetComponent<Animator>(); // animador
        characterStats = GetComponent<CharacterStats>(); // script de stats del jugador
        trajeInicial = GameObject.FindGameObjectWithTag("Traje"); // traje inicial

        gameManager = GameManager.instance; // game manager
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Si el jugador choca con el objeto "Traje", se activa la animación de cambio de outfit, y se destruye el traje
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
        // Si la salud del jugador es igual o menor a cero, se activa la animación y el sonido de muerte
        if (characterStats.currentHealth <= 0)
        {
            animator.SetBool("Death", true);
            gameManager.SetGameState(GameState.Death);
            muerteSFX.Play();
        }
        else
        {
            gameManager.SetGameState(GameState.Playing); // Si el jugador sigue vivo, el juego sigue corriendo
        }
    }
}
