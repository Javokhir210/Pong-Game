using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play1Controller : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private bool isPlayer2;
    [SerializeField] private GameObject ball;

    private Rigidbody2D rbody;
    private Vector2 playerMove;

    private      
    void Start()
    {
        rbody  = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isPlayer2){
            ComputerControl();
        } else {
            PlayerControl();
        }
    }

    private void PlayerControl(){
        playerMove = new Vector2(0, Input.GetAxisRaw("Vertical"));
    }

    private void ComputerControl(){
        if (ball.transform.position.y > transform.position.y + 0.5f){
            playerMove = new Vector2(0,1);
        } else if (ball.transform.position.y < transform.position.y - 0.5f){
            playerMove = new Vector2(0,-1);
        } else {

        }
    }

    private void FixedUpdate(){
        rbody.velocity = playerMove * movementSpeed;
    }
}