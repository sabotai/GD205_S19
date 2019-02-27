using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMove : MonoBehaviour {

    Rigidbody myRb;
	// Use this for initialization
	void Start () {
        myRb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        //if the space bar is being newly pressed 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //add force to our rigidbody
            //in the direction (0,1,0) (up)
            //multiplied times a force amount
            myRb.AddForce(Vector3.up * 999f);
        }
	}
}
