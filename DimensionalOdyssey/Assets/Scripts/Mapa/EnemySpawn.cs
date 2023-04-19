using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemySpawn : MonoBehaviour
{
    // Start is called before the first frame update
    // void Start()
    // {

    // }

    // // Update is called once per frame
    // void Update()
    // {

    // }

    public int cantidadEnemigos;
    public GameObject enemigo;

    public void GenerarEnemigos()
    {
        for (int i = 0; i < cantidadEnemigos; i++)
        {
            GenerarEnemigo();
        }
    }

    void GenerarEnemigo()
    {
        Tilemap cuarto = gameObject.GetComponent<Tilemap>();

        float xMax = cuarto.cellBounds.xMax - 2;
        float yMax = cuarto.cellBounds.yMax - 2;

        float randomPosX = Random.Range(transform.position.x - xMax, transform.position.x + xMax);
        float randomPosY = Random.Range(transform.position.y - yMax, transform.position.y + yMax);

        Instantiate(enemigo, new Vector2(randomPosX, randomPosY), transform.rotation);
    }
}
