using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    // variable for check gameover
    public bool gameOver;

    // variable for jump 
    public float floatForce;

    // gravity
    private float gravityModifier = 2.5f;
    // variable for use rigidbody component
    private Rigidbody playerRb;

    // variables for use effects
    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    // manage audioclips variable and get audiosource component
    private AudioSource playerAudio;

    // varibles 
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public AudioClip bounceSound;

    // limit ball to jump in this variable 
    public bool isLowEnough;


    // Start is called before the first frame update
    void Start()
    {
        // give gravity
        Physics.gravity *= gravityModifier; 

        // to give audiosource component to playerAudio
        playerAudio = GetComponent<AudioSource>(); 
        // to give rigidbody component toplayerRb
        playerRb = GetComponent<Rigidbody>();

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        // While space is pressed and player is low enough, float up

        // if islowenough>15 cant jump
        if (transform.position.y > 15)
        {
            isLowEnough = false;
        }
        else
        {
            isLowEnough = true;
        }
        // jump code
        if (Input.GetKey(KeyCode.Space) && isLowEnough && !gameOver)
        {
            playerRb.AddForce(Vector3.up * floatForce);
        }
        

    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            // execute explosion effect
            explosionParticle.Play();
            // execute given sound
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            //execute firework effects
            fireworksParticle.Play();
            // execute given sound
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);
        }
        // when ball collide ground execute this code
        else if (other.gameObject.CompareTag("Ground") && !gameOver)
        {
            // jump 
            playerRb.AddForce(Vector3.up * 10, ForceMode.Impulse);
            // execute given sound
            playerAudio.PlayOneShot(bounceSound, 1.5f);

        }

    }

}
