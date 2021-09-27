using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic : MonoBehaviour
{

    public float speed;
    void Start()
    {

    }

    void Update() 
    {
        if (Input.GetKey(KeyCode.W)) 
        {
            print("move to forward");
            transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * speed * 2.5f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            print("move to backward");
            transform.position += transform.TransformDirection(Vector3.back) * Time.deltaTime * speed * 2.5f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            print("move to strafe left");
            transform.position += transform.TransformDirection(Vector3.left) * Time.deltaTime * speed * 2.5f;
        }
        
        if (Input.GetKey(KeyCode.D)) 
        {
            print("move to strafe right");
            transform.position += transform.TransformDirection(Vector3.right) * Time.deltaTime * speed * 2.5f;
        }
    }
}