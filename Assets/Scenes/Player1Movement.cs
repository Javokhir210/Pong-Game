using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Movement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private GameObject ball;

    private Rigidbody2D rbody;
    private Vector2 playerMove;

    private void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Player1Control();
    }

    private void Player1Control()
    {
        // Change the axis name to "Player1Vertical"
        float verticalInput = Input.GetAxisRaw("Player1Vertical");

        // Adjust the player's movement based on key input
        playerMove = new Vector2(0, verticalInput);
    }

    private void FixedUpdate()
    {
        rbody.velocity = playerMove * movementSpeed;
    }
}