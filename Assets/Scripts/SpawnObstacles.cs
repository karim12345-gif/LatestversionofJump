using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public GameObject obstaclesPrefab; // were we can insert the obstacle prefab 
    private Vector3 spawnPos = new Vector3(20, 0, 0); // obstacel postion 20 left of the x-axis 
    private float starDelay = 1.0f;
    private float timeRepate = 2;
    private controlles playerControllersScript;
    

    // Start is called before the first frame update
    void Start()
    {
        playerControllersScript = GameObject.Find("Player").GetComponent<controlles>();

        InvokeRepeating("spwanObstacles", starDelay, timeRepate); // will spawn objects on a timer  

    }

    // Update is called once per frame
    void Update()
    {

    }
    void spwanObstacles()
    {
        if(playerControllersScript.gameOver == false) // if game is still not over then its false , we keeo creating objects  or !gameover
        {
            Instantiate(obstaclesPrefab, spawnPos, obstaclesPrefab.transform.rotation); // will create clones of the object prefab obnstacles prefab
        }
        
    }
}
