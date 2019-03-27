using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float boomAmt; //variable to change how much force to add **DEFAULTS TO ZERO (NO FORCE)**

    void Update()
    {
        //we declare a new ray called laser
        //and assign it using the ScreenPointToRay method of our main camera
        //it will take the screen point inside the parentheses and convert it into a ray
        //so in this case, it will take the mouse position from the screen
        //and cast it into our scene
        Ray laser = Camera.main.ScreenPointToRay(Input.mousePosition);

        //we store the information about anything our ray hits in the raycasthit we are calling hit
        RaycastHit hit = new RaycastHit();

        //there is a debug function that will draw our ray in our scene view
        Debug.DrawRay(laser.origin, laser.direction, Color.green);

        //if (we cast our ray and it hits something), do the following...
        //it will store our hit information in hit
        if (Physics.Raycast(laser, out hit, 10000f) && Input.GetMouseButton(0)) //(which ray, which raycasthit, how far to send it)
        {
            if (hit.rigidbody) //if the thing we hit has a rigidbody
            {
                //then add force to the rigidbody in a random 3D direction
                //and multiply it by an amount
                hit.rigidbody.AddForce(Random.insideUnitSphere * boomAmt);
            }
            //send a message to the console telling us the name of whatever we hit
            Debug.Log("you hit something ... " + hit.transform.gameObject.name);
        }

    }
}
