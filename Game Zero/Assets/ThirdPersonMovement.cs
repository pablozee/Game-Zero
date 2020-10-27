using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;

    public Transform landingCheck;

    public Transform aimLookAt;

    public float speed = 6f;
    public float gravity = -9.81f;
    public float jumpHeight = 4f;

    //to smooth player turn speed
    public float turnSmoothTime = 0.1f;

    public float shootRotateSpeed = 6.3f;

    public Animator animator;

    public GameObject shootOrigin;

    float turnSmoothVelocity;

    float turnShootSmoothVelocity;

    float faceAngle;

    Vector3 velocity;

    Vector3 faceDirection;

    Ray cameraAim;

    bool isGrounded;
    bool isAiming = false;
    bool isRunning = false;

    bool isLanding = false;

    bool shootRotation = false;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0) 
        {
            velocity.y = -4f;
        }

        isLanding = Physics.CheckSphere(landingCheck.position, groundDistance, groundMask);

        if (isLanding && !isGrounded && velocity.y < 0)
        {
            animator.SetTrigger("land");
        }

        // x axis
        float horizontal = Input.GetAxisRaw("Horizontal");
         
        // z axis
        float vertical = Input.GetAxisRaw("Vertical");

        //.normalized prevents us from going faster if two keys are pressed at once
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (Input.GetKeyDown(KeyCode.LeftShift) && isRunning == false)
        {
            isAiming = !isAiming;
            if (animator.GetInteger("isIdle") == 1)
            {
                animator.SetInteger("isIdle", 0);
            }
             if (animator.GetInteger("isRunning") == 1)
            {
                animator.SetInteger("isRunning", 0);
            }
            animator.SetBool("isAiming", !animator.GetBool("isAiming"));
        }

         if (Input.GetMouseButtonDown(0) && isAiming) 
        {
            animator.SetTrigger("shoot");
        }

        if (isGrounded && velocity.y < 0f && direction.magnitude < 0.1f)
        {
            isRunning = false;
            animator.SetInteger("isRunning", 0);

            if (isAiming == false)
            {
                animator.SetInteger("isIdle", 1);
            }
        }

        // code to rotate when aiming
        // if (isAiming && direction.magnitude < 0.1f)
        // {
        // float targetAngle = cam.eulerAngles.y + 180;
        //     float smoothedAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        //     transform.rotation = Quaternion.Euler(0f, smoothedAngle, 0f);
        // }  


        if (direction.magnitude >= 0.1f)
        {
            isRunning = true;

            if (animator.GetInteger("isRunning") == 0)
            {   
                animator.SetInteger("isIdle", 0);
                animator.SetInteger("isRunning", 1);
            }

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

            if (animator.GetInteger("isIdle") == 1)
            {
                animator.SetInteger("isIdle", 0);
            }
             if (animator.GetInteger("isRunning") == 1)
            {
                animator.SetInteger("isRunning", 0);
            }
            animator.SetTrigger("jump");

        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }

    private void FixedUpdate() 
    {
        if (isAiming)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();     
            }
        }
    }


    void Shoot()
    {
        RaycastHit hit;

        RaycastHit cameraHit;
        
        cameraAim = Camera.main.ScreenPointToRay(Input.mousePosition);

        Quaternion rotationDirection = Quaternion.LookRotation(new Vector3 (-cameraAim.direction.x, 0f, -cameraAim.direction.z), Vector3.up);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotationDirection, 0.75f);
        
        if (Physics.Raycast(cameraAim, out cameraHit, Mathf.Infinity))
        {
            
            faceAngle = Vector3.Angle(transform.forward, cameraAim.direction);
            
            if (Physics.Raycast(shootOrigin.transform.position, (cameraHit.transform.position - shootOrigin.transform.position).normalized, out hit, Mathf.Infinity))
            {
                
                Debug.DrawLine(shootOrigin.transform.position, (cameraHit.transform.position - shootOrigin.transform.position).normalized, Color.red, 4f);
                if (hit.collider.tag == "Enemy")
                {
                    Debug.Log("Hit Enemy");
                    hit.collider.GetComponent<EnemyStats>().TakeDamage(10);
                } 
            } else 
            {
                Debug.DrawLine(shootOrigin.transform.position, (cameraHit.transform.position - shootOrigin.transform.position).normalized, Color.red, 4f);
                Debug.Log("Ray didn't hit");
            }
        }
    }
}
