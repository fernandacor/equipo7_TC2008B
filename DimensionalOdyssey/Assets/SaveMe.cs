using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveMe : MonoBehaviour
{
    // Update is called once per frame
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Debug.Log(gameObject.scene.name);
    }
}
