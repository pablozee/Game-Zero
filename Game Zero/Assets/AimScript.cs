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
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        chest = animator.GetBoneTransform(HumanBodyBones.Chest);
        controller = GetComponent<ThirdPersonMovement>();
        
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
        if (controller.isAiming && !controller.isRunning)
        {
            chest.LookAt(playerLookAtObject);
        }
    }

    public void ResetYRotation()
    {
        yRotation = transform.eulerAngles.y;
    }
}
