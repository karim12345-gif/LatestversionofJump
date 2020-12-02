using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlles : MonoBehaviour
{
    private Rigidbody playerRib;
    private Animator playerAnimoter;  // getting a reference to the animtor (jummp and run ) 
    public ParticleSystem explosionPartcile; // the explaosion partcile system anaimtion , once we attach it , it will work perfectly 
    public ParticleSystem dirtPartcileEffect;// once we attach the Dirt it will work 
    private AudioSource playerAudio; // the audios attached to the player
    public AudioClip jumpSound;
    public AudioClip crashSound; 
    public float jumpForce = 10;
    public float gravityModifer; // this will be modifed from the outside depending on the players mass 
    public bool isOnGround = true;
    public bool gameOver = true;
    // Start is called before the first frame update
    void Start()
    {
        playerRib = GetComponent<Rigidbody>(); // we wanna get the rigidbody , because it deals with pyhsics and gravity better than transofrm
                                               //using get compent is like a reference , unlike transform


        playerAnimoter = GetComponent<Animator>(); // refrerence for the animator 

        // aduio 
        playerAudio = GetComponent<AudioSource>();

        

        // we wanna controll the gravity , so the jump can look real
        Physics.gravity *= gravityModifer;  // this will controll the gravity like we want to 

    }

    // Update is called once per frame
    void Update()
    {
        //Player cannot double-jump
        if (Input.GetKey(KeyCode.Space) && isOnGround && !gameOver) // gameover is true in controlles , but if the game isnt over then do this 
        {
            playerRib.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // this will be * by  y which is equal to 1 automatically 
            //, 10 didnt work was to weak to notice the jump
            isOnGround = false; // so we set it to false , because once u hit the space bar , you are not on the ground anymore , which is flase 
                                // so the whole statment is not True , therefore , the player cant jump agian or make a double jump like before 

            // to stop the Dirt partcile from playing we have to stop it if the player is not on the ground 
            dirtPartcileEffect.Stop(); // will stop it 

            playerAnimoter.SetTrigger("Jump_trig"); // this is a trigger so when the player presses on the space bar , the aniamtion of the jump would work 

            playerAudio.PlayOneShot(jumpSound,1.0f); // audio will play once the player is not having collision with the ground and is on the air 
            
        }
    }

    private void OnCollisionEnter(Collision collision) // when ever the player enters collison with the groun , becuas it has its own collider 
                                                       // now we can set our isOnGround to True 
    {
        if (collision.gameObject.CompareTag("Ground"))  // comparing the tag Ground that we made and attached to ground 
        {
            isOnGround = true;// if u go to the inspector for the player , u will see isonground box checked , thats beacuse its with collsion with
                              // the ground that has a collider 


            // partcile Dirt effect 
            dirtPartcileEffect.Play(); // so once we attach it in the inspector it will work 

        }
        else if (collision.gameObject.CompareTag("Obstacle")) // gameobject here is the player , beacuse we attached the script to it in the inspector 

        {
            gameOver = true;   // its true becuase its game over , or the player which is the game object already hit the obstacle here so we say game over 
            Debug.Log("Game Over");
            playerAnimoter.SetBool("Death_b", true); // seting death to if the game is over 
            playerAnimoter.SetInteger("DeathType_int", 2);  // choosing which death i want ( which animation is my fav)
            explosionPartcile.Play(); // so this explosionPartcile referee to the parcile that we will attach in the inspector 
            dirtPartcileEffect.Stop();// we have to put it here because , if he dies they have to stop so the gameplay can  look real 
            playerAudio.PlayOneShot(crashSound,1.0f); // audio playes when the player hits the obstacle infront of him , the 1.0f is for the full volume 
           
        }
    }
}
