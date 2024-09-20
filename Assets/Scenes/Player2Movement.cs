using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
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
        Player2Control();
    }

    private void Player2Control()
    {
        // Change the axis name to "Player2Vertical"
        float verticalInput = Input.GetAxisRaw("Player2Vertical");

        // Adjust the player's movement based on arrow key input
        playerMove = new Vector2(0, verticalInput);
    }

    private void FixedUpdate()
    {
        rbody.velocity = playerMove * movementSpeed;
    }
}