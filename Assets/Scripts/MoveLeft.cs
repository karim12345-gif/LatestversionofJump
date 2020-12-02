using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30;
    private float leftBound = -15;
    private controlles playerControllerScript; // we are getting refeerence to the cotnrolles class
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<controlles>();  //Gameobject is the class , and we find the player from the hericacrhy , and then we get the script that was attached to the player 
                                                                                        // its also like a reference as well 

    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false)  // if the game over == to false , then the obstacle will keep on moving to the left 
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed); // this will make the obstacle move left using the speed and the vector 3.left where x= -1
        }

        if (transform.position.x< leftBound && gameObject.CompareTag("Obstacle")) // we had to use the tag game object , beucase with out we will deleate the backgorund as well 
        {
            Destroy(gameObject);

        }

    }
}
