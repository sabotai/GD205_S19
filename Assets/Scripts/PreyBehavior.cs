using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreyBehavior : MonoBehaviour {

    Rigidbody preyRB;
    public Transform pred;
    public float forceAmt;
    // Use this for initialization
    void Start()
    {
        preyRB = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 predDirection = Vector3.Normalize(transform.position - pred.position);
        preyRB.AddForce(predDirection * forceAmt);
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.transform == pred){
            Debug.Log("you hit me and you are a predator");

        }
    }

}
