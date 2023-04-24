using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apuntador : MonoBehaviour
{

    private Camera cam;
    private Vector2 mousePos;

    void Start()
    {
        cam = GameObject.Find("Main Camera").gameObject.GetComponent<Camera>();

        // Oculta el cursor del mouse
        Cursor.visible = false;

    }

    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x, mousePos.y, 0f);
    }

    void OnApplicationFocus(bool hasFocus)
    {
        // Oculta el cursor del mouse cuando la aplicación está en foco
        Cursor.visible = false;
    }

    void OnApplicationPause(bool pauseStatus)
    {
        // Oculta el cursor del mouse cuando la aplicación está pausada
        Cursor.visible = false;
    }

    void OnDisable()
    {
        // Vuelve a mostrar el cursor del mouse cuando el script es desactivado
        Cursor.visible = true;
    }

}

