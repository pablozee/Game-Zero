using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookAt : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);

        // float yRotation = Mathf.Clamp(transform.rotation.eulerAngles.y, -90f, 90f);
        // transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, yRotation, transform.rotation.eulerAngles.z);
        // if (transform.rotation.y > -90f && transform.rotation.y < 90f)
        // {
        //     transform.LookAt(target);
        // }

        // if (transform.rotation.y > 90f)
        // {
        //     transform.rotation = Quaternion.Euler(transform.eulerAngles.x, 90f, transform.eulerAngles.z);
        // }
        // if (transform.rotation.y < -90f)
        // {
        //     transform.rotation = Quaternion.Euler(transform.eulerAngles.x, -90f, transform.eulerAngles.z);
        // }
    }
}
