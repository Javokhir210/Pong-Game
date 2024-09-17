using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float initilSpeed = 10;
    [SerializeField] private float speedIncrease = 0.2f;
    [SerializeField] private Text Player1Score;
    [SerializeField] private Text player2Score;

    private int hitCounter;
    private Rigidbody2D rbody;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>(); 
        Invoke("StartBall", 2f);
   
    }

    private void FixedUpdate(){
        rbody.velocity = Vector2.ClampMagnitude(rbody.velocity, initilSpeed + speedIncrease*hitCounter);
    }

    private void StartBall(){
        rbody.velocity = new Vector2(-1, 0) * (initilSpeed + speedIncrease*hitCounter);
    }

    private void ResetBall(){
        rbody.velocity = new Vector2(0,0);
        transform.position = new Vector2(0,0);
        hitCounter = 0;
        Invoke("StartBall", 2f);
    }
    
    private void PlayerBounce(Transform myObject){
        hitCounter++;
        Vector2 ballPos = transform.position;
        Vector2 playerPos = myObject.position;

        float xDirection, yDirection;

        if(transform.position.x > 0){
            xDirection = -1;
        } else {
            xDirection = 1;
        }

        yDirection = (ballPos.y - playerPos.y)/myObject.GetComponent<Collider2D>().bounds.size.y;
        if(yDirection == 0){
            yDirection = 0.25f;
        }
        rbody.velocity = new Vector2(xDirection, yDirection)*(initilSpeed + (speedIncrease*hitCounter));
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.name == "Player1" || collision.gameObject.name == "Player2"){
            PlayerBounce(collision.transform);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if(transform.position.x > 0){
            ResetBall();
            Player1Score.text = (int.Parse(Player1Score.text) +1 ).ToString();
        } else if(transform.position.x < 0){
            ResetBall();
            player2Score.text = (int.Parse(player2Score.text) +1 ).ToString();

        }
    }


}