using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredatorBehavior : MonoBehaviour {

    Rigidbody predRB;
    public Transform prey;
    public float forceAmt;

	// Use this for initialization
	void Start () {
        predRB = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 preyDirection = Vector3.Normalize(prey.position - transform.position);
        predRB.AddForce(preyDirection * forceAmt);
	}
}
