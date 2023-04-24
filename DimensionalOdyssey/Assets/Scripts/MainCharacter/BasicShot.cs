using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BasicShot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 20f;
    private float shotAngle = 0f;
    private GameObject player;
    private CharacterStats characterStats;
    private PlayerInput playerInput;
    private Vector2 mousePos;
    private Camera cam;

    void Awake()
    {
        player = transform.parent.gameObject;
        characterStats = player.GetComponent<CharacterStats>();
        playerInput = player.GetComponent<PlayerInput>();
    }
}
