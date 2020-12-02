using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos; // our start postin needs to be vector3 
    private float repeatWidth;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position; // the actaul staring positon , current postion of the object 
        // by the way , transfrom.potion is for the current postion  , so the startpos is for the start of the current postion 

        repeatWidth = GetComponent<BoxCollider>().size.x / 2; //so we baically have to get the getcomponent to get the collider that we attachted to the background image 
        // then we already know the size on the background if u check in the inspector, its 112.8 , so we get the size of the vector 3 (x) and then we divide it by two.
    }

    // Update is called once per frame
    void Update()
    { if(transform.position.x < startPos.x - repeatWidth) // if the current postion is less than the startpos , reaptWidth is the width of the background  
            //, so we are comapring the the current postion if its less than the startpostion and a little offet , then we will reset the entrie postion of our object
        {
            transform.position = startPos;

        }
        
    }
}
