using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredatorBehavior : MonoBehaviour {

    Rigidbody predRB; //store our rigidbody info to manipulate it
    public Transform prey; //store our prey transform... public so we can assign it in the inspector
    public float forceAmt; //how much force in a given direction to seek the prey

	// Use this for initialization
	void Start () {
        predRB = GetComponent<Rigidbody>(); //assign our rigidbody using GetComponent ... it assumes the same one as this script is attached to
	}
	
	// Update is called once per frame
	void Update () {
		//by calculating the direction, we know which way to send the predator
		//prey.position - transform.position (predator) give us the distance to travel to meet the prey
		//Vector3.Normalize will convert this distance into a direction e.g., a distance of (2, 1, 0) is a direction of (1, 0.5, 0) 
		//all values in directions are between -1 and 1, so up is (0,1,0) meaning not left or right, up on the x and not forward or backward
		//left and down would be (-1, -1, 0), meaning left, down, and neither fwd nor bwd
        Vector3 preyDirection = Vector3.Normalize(prey.position - transform.position);

        //we use the add force function/method of rigidbody
        //to add force in the direction of the prey and multiply by an amount of force
        predRB.AddForce(preyDirection * forceAmt);
	}
}
