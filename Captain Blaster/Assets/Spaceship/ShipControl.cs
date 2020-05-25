using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject bulletPrefab;
    public float speed = 10f;
    public float xLimit = 7f;
    public float yLimit = 7f;
    //public float yLimit = 4f;
    public float reloadTime = .5f;

    float elapsedTime = 0f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Keeping track of time for bullet firing
        elapsedTime += Time.deltaTime;

        //Move the player left and right
        float xInput = Input.GetAxis("Horizontal");
        transform.Translate(xInput * speed * Time.deltaTime, 0f, 0f);

        //move the player up and down
        float yInput = Input.GetAxis("Vertical");
        transform.Translate(0f, yInput * speed * Time.deltaTime, 0f);

        // Clamp the Ship's x position
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, -xLimit, xLimit);
        transform.position = position;

        // Clamp the Ship's y position
         Vector3 position2 = transform.position;
         position2.y = Mathf.Clamp(position2.y, -yLimit, yLimit);
         transform.position = position2;

        position.y = Mathf.Clamp(position.y, -yLimit, yLimit);
        transform.position = position;

        //Spacebar fires. The default InputManager settings call this "Jump"
        // Only happens if enough time has elapsed since last firing

        if(Input.GetButtonDown("Jump") && elapsedTime > reloadTime){
          //Instantiate the bullet 1.2 units in front of the player
          Vector3 spawnPos = transform.position;
          Vector3 leftSpawn = spawnPos + new Vector3(.2f, 1.2f, 0);
          Vector3 rightSpawn = spawnPos + new Vector3(-.2f, 1.2f, 0);
          Instantiate(bulletPrefab, leftSpawn, Quaternion.identity);
          Instantiate(bulletPrefab, rightSpawn, Quaternion.identity);


          elapsedTime = 0f; //reset bullet firing timer
        }

    }

    void OnTriggerEnter2D(Collider2D other){
      gameManager.PlayerDied();
      Destroy(other.gameObject);
    }
}
