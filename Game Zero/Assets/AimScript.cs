using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimScript : MonoBehaviour
{
    public Transform playerLookAtObject;

    // public Transform selfRotationCheck;

    public Vector3 offset;

    public float yRotation; 

    Animator animator;
    Transform chest;

    ThirdPersonMovement controller;

    ClampPosition clampScript;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        chest = animator.GetBoneTransform(HumanBodyBones.Chest);
        controller = GetComponent<ThirdPersonMovement>();
        clampScript = playerLookAtObject.GetComponent<ClampPosition>();
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        // float yRotation = Mathf.Clamp(playerLookAtObject.rotation.eulerAngles.y, -90, 90);
        // float yRotation = Mathf.Clamp(selfRotationCheck.transform.rotation.eulerAngles.y, 90f, 270f);
        // yRotation = selfRotationCheck.transform.rotation.eulerAngles.y;
        // if (yRotation > 70f && yRotation < 135f)
        // {
        //     yRotation = 70f;
        // } 
        // if (yRotation < 290f && yRotation >= 135f)
        // {
        //     yRotation = 290f;
        // }
        // Debug.Log(yRotation);
        // // Quaternion.Euler(playerLookAtObject.eulerAngles.x, yRotation, playerLookAtObject.eulerAngles.z)
        // chest.SetPositionAndRotation(chest.transform.position, Quaternion.Euler(playerLookAtObject.eulerAngles.x, yRotation, playerLookAtObject.eulerAngles.z));
        // if (playerLookAtObject.rotation.eulerAngles.y < 90 && playerLookAtObject.rotation.eulerAngles.y > -90)    
        // {
        // }
        // clampScript.isBehindPlayer != true
        if (controller.isAiming && !controller.isRunning)
        {
            // chest.LookAt(playerLookAtObject);
            
            // if (chest.rotation.eulerAngles.y == 90 && clam)
            Vector3 direction = (playerLookAtObject.position - transform.position).normalized;
            // float directionX;
            // float directionZ = Mathf.Clamp(direction.z, -1f, 1f);
            // Debug.Log(direction);
            // if (direction.x > 1f)
            // {
            //     directionX = 1f;
            // }   else if (direction.x < -1f)
            // { 
            //     directionX = -1f;
            // } else 
            // {
            //     directionX = direction.x;
            // }

            // Vector3 newDirection = new Vector3(directionX, direction.y, directionZ);
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            if (lookRotation.eulerAngles.y > 90f && lookRotation.eulerAngles.y < 270f)
            {
                chest.SetPositionAndRotation(chest.transform.position, lookRotation);
            }
            if (lookRotation.eulerAngles.y > 0f && lookRotation.eulerAngles.y <=90)
            {
                chest.SetPositionAndRotation(chest.transform.position, Quaternion.Euler(lookRotation.eulerAngles.x, 90f, lookRotation.eulerAngles.z));
            }
            if (lookRotation.eulerAngles.y >= 270f && lookRotation.eulerAngles.y < 360f)
            {
                chest.SetPositionAndRotation(chest.transform.position, Quaternion.Euler(lookRotation.eulerAngles.x, 270f, lookRotation.eulerAngles.z));
            }

        }
    }

    public void ResetYRotation()
    {
        yRotation = transform.eulerAngles.y;
    }
}
