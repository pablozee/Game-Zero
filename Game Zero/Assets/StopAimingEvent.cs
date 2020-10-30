using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAimingEvent : MonoBehaviour
{
    public ThirdPersonMovement controller;
    void ToggleIsAiming()
    {
        controller.isAiming = false;
    }

}
