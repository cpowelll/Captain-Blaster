using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
          //Because the bullet doesn't exist until the game is running
          // we must find the Game Manager a different way
          gameManager = GameObject.FindObjectOfType<GameManager>();

          Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();
          rigidBody.velocity = new Vector2(0f, speed);
    }

    void OnCollisionEnter2D(Collision2D other){
      Destroy(other.gameObject); //Destroy the Meteor
      gameManager.AddScore();
      Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
