using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handball : MonoBehaviour
{
    Vector3 initialPos;

    private void Start()
    {
        initialPos = transform.position;
    }


    // Too see if ball goes out of bounds
    // private void onCollisionEnter(Collision collision)
    // {
    //     if(collision.transform.CompareTag("Out"))
    //     {
    //         GetComponent<Rigidbody>().velocity = Vector3.zero;
    //         transform.position = initialPos;
    //     }
    // }
}