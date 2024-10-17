using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using UnityEngine;

public class Handball : MonoBehaviour
{
    Vector3 initialPos;
    private int bounceCount = 0;
    private bool returning = false;
    bool test;
    bool serving;


    private void Start()
    {
        initialPos = transform.position;
        serving = false;
    }

    private void Update()
    {
        test = BallBounce.hitting;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Court"))
        {
            bounceCount++;
            Debug.Log("Bounces: " + bounceCount);
        }

        if(collision.transform.CompareTag("Ground"))
        {
            ResetBall();
        }

        if(collision.transform.CompareTag("Wall") && bounceCount != 1)
        {
            bounceCount = 0;
        }

        if(bounceCount >= 2 && returning == false)
        {
            ResetBall();
        }

        if(test == true)
        {
            bounceCount = 0;
            BallBounce.hitting = false;
        }
    }

    private void ResetBall()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.position = initialPos;
        bounceCount = 0;
        returning = false;
    }
}