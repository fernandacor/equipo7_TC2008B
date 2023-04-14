using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoCamara : MonoBehaviour
{
    public float followSpeed = 2f;
    public Transform objectToFollow;
    public float yOffset = 1f;


    void Update()
    {
        Vector3 newPos = new Vector3(objectToFollow.position.x, objectToFollow.position.y + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
    }

}
