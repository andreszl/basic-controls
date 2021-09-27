using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private float inputX;
    private float inputY;

    private Vector3 move;

    CharacterController controller;

    void Start() {
        controller = this.GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();
        move = new Vector3(inputX, 0, inputY);
        controller.Move(move);
    }

    void Move() {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
    }

    void Rotate() {

    }

    void Jump() {

    }

    void Walk() {

    }

    void Run() {

    }

}