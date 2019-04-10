using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherAnim : MonoBehaviour
{
    Animator myAnim;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        myAnim.SetInteger("state", 0);
        if (Input.GetKey(KeyCode.W))
        {
            myAnim.SetInteger("state", 1);
        }

    }
}
