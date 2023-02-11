using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftX : MonoBehaviour
{
    // speed for background and money and bomb
    public float speed;
    // for use PlayerController class'es variables and methods
    private PlayerControllerX playerControllerScript;
    // left limit for objects
    private float leftBound = -10;

    // Start is called before the first frame update
    void Start()
    {
        // to give Player object's PlayerController component to playerControllerScript
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
    }

    // Update is called once per frame
    void Update()
    {
        // If game is not over, move to the left
        if (!playerControllerScript.gameOver)
        {
            // move left
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }

        // If object goes off screen that is NOT the background, destroy it
        if (transform.position.x < leftBound && !gameObject.CompareTag("Background"))
        {
            Destroy(gameObject);
        }

    }
}
