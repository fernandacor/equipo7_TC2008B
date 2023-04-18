using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script to move an object in a sine wave
// by: Fernanda Cantú Ortega A01782232 10/03/2023

public class MovimientoSineEnemigos : MonoBehaviour
{
    [SerializeField] float amplitude;
    [SerializeField] float speed;
    Vector3 initialPosition;
    Vector3 offset;
    float angle;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        angle += speed * Time.deltaTime;
        offset = new Vector3(Mathf.Sin(angle) * amplitude, 0, 0);
        transform.position = initialPosition + offset;
    }
}