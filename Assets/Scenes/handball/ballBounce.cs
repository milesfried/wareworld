using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    public Transform aimTarget;
    public Transform ball; 
    public Transform court;
    float speed = 3f;
    float force = 10;
    public static bool hitting;
    float distanceThreshold = 2f;


    void Start()
    {
            GameObject handball = GameObject.Find("Handball");
            GameObject handballCourt = GameObject.Find("Court");
            court = handballCourt.transform;
            if(handball != null)
            {
                ball = handball.transform;
                Debug.Log("Handball is in scene.");
            } else {
                Debug.LogError("Handball is not in scene.");
            }

    }

    void Update(){

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (h != 0 || v != 0){
            transform.Translate( new Vector3(h, 0, v) * speed * Time.deltaTime);
        }

        float distance = Vector3.Distance(transform.position, ball.position);

        if (distance <= distanceThreshold){
            // Debug.Log("Ball is hittable.");

            if (Input.GetKeyDown(KeyCode.Space)){
                hitting = true;
                Debug.Log("Ball is hit.");
                BallHit();
            }else if (Input.GetKeyUp(KeyCode.Space)){
                hitting = false;
                Debug.Log("Ball is missed.");
            }
        }
        


        // if (hitting){
        //     // aimTarget.Translate( new Vector3(h, 0, 0) * speed * Time.deltaTime);
        // }
    }

    // private void OnTriggerEnter(Collider other){
    //     if(other.CompareTag("Handball"))
    //     {
    //         Vector3 dir = aimTarget.position - transform.position;
    //         other.GetComponent<Rigidbody>().velocity = dir.normalized * force + new Vector3(0, 13, 0);
    //     }
    // }

    private void BallHit(){
            Vector3 dir = aimTarget.position - transform.position;
            ball.GetComponent<Rigidbody>().velocity = dir.normalized * force + new Vector3(0, 13, 0);
    }
}