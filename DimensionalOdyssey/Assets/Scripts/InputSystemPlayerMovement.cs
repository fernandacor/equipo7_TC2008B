using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystemPlayerMovement : MonoBehaviour
{
    private PlayerMovement input;
    private Vector2 movimiento;
    private Rigidbody2D playerRB;
    public float velocidadMovimiento;
    public Animator animator;

    // Awake is called to initialize input system
    private void Awake()
    {
        input = new PlayerMovement();
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void OnEnable()
    {
        input.Enable();
        input.Player.Movement.performed += OnMovementPerformed;
        input.Player.Movement.canceled += OnMovementCanceled;
    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.Movement.performed -= OnMovementPerformed;
        input.Player.Movement.canceled -= OnMovementCanceled;
    }

    void Update()
    {
        movimiento.x = Input.GetAxisRaw("Horizontal");
        movimiento.y = Input.GetAxisRaw("Vertical");
        movimiento = movimiento.normalized;

        animator.SetFloat("Horizontal", movimiento.x);
        animator.SetFloat("Vertical", movimiento.y);
        animator.SetFloat("Speed", movimiento.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        playerRB.MovePosition(playerRB.position + movimiento * velocidadMovimiento * Time.fixedDeltaTime);
        Debug.Log("movimiento");
    }

    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        movimiento = value.ReadValue<Vector2>();
    }

    private void OnMovementCanceled(InputAction.CallbackContext value)
    {
        movimiento = Vector2.zero;
    }
}
