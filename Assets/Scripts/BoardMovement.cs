using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardMovement : MonoBehaviour {
    Vector3 playerPos;
    Vector3 startPos;
    public Transform destination;

    //we create arrays for the hazards and blocks
    //using square brackets after the type [] to indicate an array
    GameObject[] hazards;
    GameObject[] blocks;

    //we declare a public textmesh which we assign in the inspector
    //this will display messages for the player
    public TextMesh playerMessage;

    // Use this for initialization
    void Start () {
    	//assign the playerPos to whatever he position is of this gameobjects transform position
        playerPos = transform.position;

        //set the start position to be the same since this runs once at the beginning
        startPos = playerPos;

        //using this method, it will search every gameobject in our scene based on the tag in parentheses
        //this was, we dont have to return to the script when we want to add more hazards or blocks
        //we just need to make sure we tag them correctly
        hazards = GameObject.FindGameObjectsWithTag("Hazard");
        blocks = GameObject.FindGameObjectsWithTag("Block");

    }
	
	// Update is called once per frame
	void Update () {
		//create a vector3 to store any changes in our position
        Vector3 newPos = playerPos;

        //4 directional board movement
        if (Input.GetKeyDown(KeyCode.W))
        {
        	//if the player presses the w key, update the newpos to reflect the playerPos plus one unit forward
            newPos = playerPos + transform.forward;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
        	//if the player presses the s key, update the newpos to reflect the playerPos plus one unit backward (written as -forward since unity doesnt have backward)
            newPos = playerPos - transform.forward;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
        	//do the same for right
            newPos = playerPos + transform.right;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
        	//and left
            newPos = playerPos - transform.right;
        }

        //create a boolean that will keep track of whether our new position is already a block
        bool inABlock = false;

        //we use this loop to check our potential new position against each block
        for (int i = 0; i < blocks.Length; i++)
        {	
        	//check only if the x and z are the same for this particular block in our loop
        	//the square brackets are used to refer to arrays
        	//we put the position in the array we want to refer to inside the square brackets
        	//so the first time around in this loop, we will check blocks[0], the second time blocks[1], etc.
            if (newPos.x == blocks[i].transform.position.x &&
                newPos.z == blocks[i].transform.position.z)
            {
                //if the above is true, you are in a block
                //make inABlock true, so we know you are in a block
                inABlock = true;
            }
        }
        //once our loop is done checking the potential new position against each block
        //as long as we were not in any blocks, inABlock will be false
        //if that is the case, we can update the player to the new position
        if (!inABlock) {
        	playerPos = newPos;
        }


       //we use a loop to check each hazard in the array 
       for (int i = 0; i < hazards.Length; i++){
       		//if the players x and z position are the same as the current hazard we are checking...
            if (playerPos.x == hazards[i].transform.position.x &&
                    playerPos.z == hazards[i].transform.position.z)
            {
            	//then reset the player to the start position
                playerPos = startPos;
                //and update our text property of our textmesh
                playerMessage.text = "u suk lulz";
            }
        }

        //update the transform position of the gameobject this is attached to reflect our playerPos
        transform.position = playerPos;
    }
}
