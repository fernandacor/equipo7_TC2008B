using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

// Script que genera enemigos en posiciones random dentro de un cuarto

public class EnemySpawn : MonoBehaviour
{
    // Cantidad de enemigos y objeto del enemigo que se quiere generar
    public int cantidadEnemigos;
    public GameObject enemigo;

    public void GenerarEnemigos()
    {
        // Se llama la funcion GenerarEnemigo en base a la cantidad de enemigos
        for (int i = 0; i < cantidadEnemigos; i++)
        {
            GenerarEnemigo();
        }
    }

    void GenerarEnemigo()
    {
        // Se obtiene el tamaño del cuarto y se genera un enemigo en una posición random dentro del cuarto
        Tilemap cuarto = gameObject.GetComponent<Tilemap>();

        float xMax = cuarto.cellBounds.xMax - 2;
        float yMax = cuarto.cellBounds.yMax - 2;

        float randomPosX = Random.Range(transform.position.x - xMax, transform.position.x + xMax);
        float randomPosY = Random.Range(transform.position.y - yMax, transform.position.y + yMax);

        Instantiate(enemigo, new Vector2(randomPosX, randomPosY), transform.rotation);
    }
}
