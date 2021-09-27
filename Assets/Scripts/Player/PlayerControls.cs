using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {
    
    public Controls controls;
    
    public float currentSpeed = 0.1f, runSpeed = 4, rotation, rotationSpeed = 2, gravity = -9, velocityY, terminalMove = -25f;

    Vector2 inputs;

    Vector3 move;

    CharacterController controller;

    bool run = true, jump;

    bool jumping;
    float jumpSpeed, jumpHeight = 0.75f;
    Vector3 jumpDirection;

    void Start() {
        controller = this.GetComponent<CharacterController>();
    }

    void Update() {
        
        GetInputs();

        Vector3 characterRotation = transform.eulerAngles + new Vector3(0, rotation * rotationSpeed);
        transform.eulerAngles = characterRotation;

        float speed = currentSpeed;
    
        Vector2 inputNormalized = inputs;

        if (run) {
            speed *= runSpeed;

            if (inputNormalized.y < 0) {
                speed = speed / 2;
            }
        }

        if (jump && controller.isGrounded) {
            Jump();
        }

        if (!controller.isGrounded && velocityY > terminalMove) {
            velocityY += gravity * Time.deltaTime;
        }

        move = (transform.forward * inputNormalized.y + transform.right * inputNormalized.x + Vector3.up * velocityY) * speed;
        controller.Move(move * Time.deltaTime);

        if (controller.isGrounded) {
            if (jumping) 
                jumping = false;

            velocityY = 0;
        }
    }

    void Jump() {
        if (!jumping) {
            jumping = true;
        }

        jumpDirection = (transform.forward * inputs.y + transform.right * inputs.x).normalized;
        jumpSpeed = currentSpeed;

        velocityY = Mathf.Sqrt(-gravity * jumpHeight);
    }

    void GetInputs() {
        
        if (Input.GetKey(controls.forwards)) {
            inputs.y = 1;
        }

        if (Input.GetKey(controls.backwards)) {
            if (Input.GetKey(controls.forwards)) {
                inputs.y = 0;
            } else {
                inputs.y = -1;
            }
        }

        if (!Input.GetKey(controls.forwards) && !Input.GetKey(controls.backwards)) {
            inputs.y = 0;
        }
        
        

        // strafe 

        if (Input.GetKey(controls.strafeRight)) {
            inputs.x = 1;
        }

        if (Input.GetKey(controls.strafeLeft)) {
            if (Input.GetKey(controls.strafeRight)) {
                inputs.x = 0;
            } else {
                inputs.x = -1;
            }
        }

        if (!Input.GetKey(controls.strafeLeft) && !Input.GetKey(controls.strafeRight)) {
            inputs.x = 0;
        }
        
        
        // rotate
        
        if (Input.GetKey(controls.rotateRight)) {
            rotation = 2;
        }

        if (Input.GetKey(controls.rotateLeft)) {
            if (Input.GetKey(controls.rotateRight)) {
                rotation = 0;
            } else {
                rotation = -2;
            }
        }

        if (!Input.GetKey(controls.rotateLeft) && !Input.GetKey(controls.rotateRight)) {
            rotation = 0;
        }


        // run

        if (Input.GetKeyDown(controls.walkRun)) {
            run = !run;
        }

        // jump 

        jump = Input.GetKey(controls.jump);
    }
}
