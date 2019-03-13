using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMove : MonoBehaviour {

    Rigidbody myRb;
    public float multiplier = 10f;
    int cylindersEaten = 0;
    public int eatThresh = 3;
	// Use this for initialization
	void Start () {
        myRb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        //if the space bar is being newly pressed 
        if (Input.GetKey(KeyCode.W))
        {
            //add force to our rigidbody
            //in the direction (0,1,0) (up)
            //multiplied times a force amount
            myRb.AddForce(new Vector3(0f,0f,1f) * multiplier);
        }
        if (Input.GetKey(KeyCode.S))
        {
            myRb.AddForce(new Vector3(0f,0f,-1f) * multiplier);
        }
        if (Input.GetKey(KeyCode.A))
        {
            //add force to our rigidbody
            //in the direction (0,1,0) (up)
            //multiplied times a force amount
            myRb.AddForce(new Vector3(-1f, 0f, 0f) * multiplier);
        }
        if (Input.GetKey(KeyCode.D))
        {
            //add force to our rigidbody
            //in the direction (0,1,0) (up)
            //multiplied times a force amount
            myRb.AddForce(new Vector3(1f, 0f, 0f) * multiplier);
        }

    }

    void OnCollisionEnter(Collision col)
    {
        //we compare the transform of the thing that collided with us to the predator
        if (col.gameObject.CompareTag("Prey"))
        {
            //if it is the same, do something

            //add to our count of cylindersEaten
            cylindersEaten++;

            //destroy the prey
            Destroy(col.gameObject);
        }

        //if the tag is Predator
        if (col.gameObject.CompareTag("Predator"))
        {
            //then check if we have eaten enough prey
            if (cylindersEaten < eatThresh) //if we havent...
            {
                //destroy the gameObject that this script is attached to (the player)
                Destroy(gameObject);
            }
        }
    }
}
