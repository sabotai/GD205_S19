using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardMovement : MonoBehaviour {
    Vector3 playerPos;
    public Transform destination;
    public Transform hazard;

    // Use this for initialization
    void Start () {
        playerPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
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

        if (playerPos.x == destination.position.x && 
            playerPos.z == destination.position.z){
            playerPos += transform.up;
        }

        if (playerPos.x == hazard.position.x &&
            playerPos.z == hazard.position.z)
        {
            playerPos -= transform.up;
        }
        transform.position = playerPos;
    }
}
