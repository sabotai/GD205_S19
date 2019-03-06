using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreyBehavior : MonoBehaviour {

    Rigidbody preyRB; //store our rigidbody info to manipulate it
    public Transform pred;//store our pred transform... public so we can assign it in the inspector
    public float forceAmt;//how much force in a given direction to run away from the predator
    // Use this for initialization
    void Start()
    {
        preyRB = GetComponent<Rigidbody>();//assign our rigidbody using GetComponent ... it assumes the same one as this script is attached to
    }
    // Update is called once per frame
    void Update()
    {
        //by calculating the direction, we know which way to send the predator
        //transform.position (prey) - pred.position give us the direction to travel away from the predator
        //Vector3.Normalize will convert this distance into a direction e.g., a distance of (2, 1, 0) is a direction of (1, 0.5, 0) 
        //all values in directions are between -1 and 1, so up is (0,1,0) meaning not left or right, up on the x and not forward or backward
        //left and down would be (-1, -1, 0), meaning left, down, and neither fwd nor bwd

        Vector3 predDirection = Vector3.Normalize(transform.position - pred.position);


        //we use the add force function/method of rigidbody
        //to add force in the direction to move away from the predator and multiply by an amount of force
 
        preyRB.AddForce(predDirection * forceAmt);
    }

    //OnCollisionEnter will run every time a collision happens (when our rigidbody hits a collider)
    //The information about the collision is stored in the Collision we are creating here (col)
    //it's a bit like a collision report that documents all the information about the collision
    void OnCollisionEnter(Collision col)
    {
        //we compare the transform of the thing that collided with us to the predator
        if (col.transform == pred){
            //if it is the same, do something
            Debug.Log("you hit me and you are a predator");

        }
    }

}
