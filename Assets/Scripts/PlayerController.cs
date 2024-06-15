using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 moveInput = Vector2.zero;
    private Vector3 movementDirection = Vector3.zero;

    private TopDownController controller;
    private Rigidbody playerRigidbody;

    private void Awake()
    {
        controller = GetComponent<TopDownController>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        controller.OnMoveEvent += Move;
    }

    private void Move(Vector2 direction)
    {
        movementDirection = transform.forward * direction.y + transform.right * direction.x;
        movementDirection *= 5;

        movementDirection.y = playerRigidbody.velocity.y;
    }

    private void FixedUpdate()
    {
        ApplyMovement(movementDirection);
    }

    private void ApplyMovement(Vector3 direction)
    {
        playerRigidbody.velocity = direction;
    }
}
