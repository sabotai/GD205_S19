using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MyNavAgent : MonoBehaviour
{

    NavMeshAgent nav;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //nav.destination = target.position;
    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log("your trigger hit... " + other.name);
        if (other.gameObject.CompareTag("Prey"))
        {
            nav.destination = other.transform.position;
        }
    }
}
