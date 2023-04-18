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

    // * Generar las canastas constántemente
    // void Start()
    // {
    //     InvokeRepeating("GenerateBasket", 0f, spawnRate);
    // }

    // // * Mover las canastas y borrarlas cuando salgan del área de juego
    // void Update()
    // {
    //     BasketInstances = GameObject.FindGameObjectsWithTag("Basket");

    //     foreach (GameObject BasketInstance in BasketInstances)
    //     {
    //         // Mover las canastas
    //         if (!Ball.isGameOver)
    //             BasketInstance.transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);

    //         // Destruir las canastas cuando salgan del área de juego
    //         if (BasketInstance.transform.position.y < -20)
    //             Destroy(BasketInstance);
    //     }

    // }

    // // * Generar las canastas
    // void GenerateBasket()
    // {
    //     if (!Ball.isGameOver)
    //     {
    //         float xBasketPosition = Random.Range(-right, right);

    //         GameObject BasketInstance = Instantiate(
    //           Basket,
    //           new Vector3(xBasketPosition, transform.position.y),
    //           transform.rotation
    //         );
    //     }
    // }
}
