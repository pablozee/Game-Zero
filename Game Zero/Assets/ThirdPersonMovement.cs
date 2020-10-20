using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public float speed = 6f;
    public float gravity = -9.81f;
    public float jumpHeight = 4f;

    //to smooth player turn speed
    public float turnSmoothTime = 0.1f;

    float turnSmoothVelocity;

    Vector3 velocity;

    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0) 
        {
            velocity.y = -2f;
        }

        // x axis
        float horizontal = Input.GetAxisRaw("Horizontal");
         
        // z axis
        float vertical = Input.GetAxisRaw("Vertical");

        //.normalized prevents us from going faster if two keys are pressed at once
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

                  
        if (direction.magnitude >= 0.1f)
        {

            //set run animation boolean to true
            //finds the angle we need to turn to face our new direction, add 180 to account for players initial rotation
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.transform.eulerAngles.y + 180;

            // same as target angle but doesn't include the plus 180, this is to ensure we move the same direction as the camera 
            float targetMoveAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
            
            //smooth between current y angle and target angle. Requires a reference to a variable to hold current smooth velocity 
            float smoothedAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, smoothedAngle, 0f);

            //create new move direction by multiplying rotation by Vector3.forward
            Vector3 moveDir = Quaternion.Euler(0f, targetMoveAngle, 0f) * Vector3.forward;

            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

         if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }
}
