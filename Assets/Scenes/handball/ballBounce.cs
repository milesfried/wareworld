using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballBounce : MonoBehaviour
{
    public Transform aimTarget;
    float speed = 3f;
    float force = 10;
    bool hitting;

    void Update(){

        float h = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space)){
            hitting = true;
        }else if (Input.GetKeyUp(KeyCode.Space)){
            hitting = false;
        }

        if (hitting){
            // aimTarget.Translate( new Vector3(h, 0, 0) * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Handball"))
        {
            Vector3 dir = aimTarget.position - transform.position;
            other.GetComponent<Rigidbody>().velocity = dir.normalized * force + new Vector3(0, 13, 0);
        }
    }
}