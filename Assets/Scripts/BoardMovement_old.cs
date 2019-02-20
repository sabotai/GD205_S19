using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardMovement_old : MonoBehaviour {
    Vector3 playerPos;
    public Transform destination;
    public Transform hazard;

    // Use this for initialization
    void Start () {
        playerPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        //4 directional board movement
        if (Input.GetKeyDown(KeyCode.W))
        {
            playerPos += transform.forward;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            playerPos -= transform.forward;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            playerPos += transform.right;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            playerPos -= transform.right;
        }

        //check if the players x and z position is the same as the destination
        if (playerPos.x == destination.position.x && 
            playerPos.z == destination.position.z){
            playerPos += transform.up;
        }
        //check if player x/z same as hazard
        if (playerPos.x == hazard.position.x &&
            playerPos.z == hazard.position.z)
        {
            playerPos -= transform.up;
        }

        //update the position of the gameobject this is attached to
        transform.position = playerPos;
    }
}
