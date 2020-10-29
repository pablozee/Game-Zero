using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampPosition : MonoBehaviour
{
    public GameObject player;

    public bool isBehindPlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (transform.position.z >= player.transform.position.z)
        // {
        //     transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z);
        // }

        // Vector3 toPlayer = (transform.position - player.transform.position).normalized;

        // if (Vector3.Dot(toPlayer, -transform.forward) < 0)
        // {
        //     Debug.Log("Target behind player");
        //     transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z);
        // }

        // Vector3 directionToTarget = (transform.position - player.transform.position).normalized;
        // float angle = Vector3.Angle(-player.transform.forward, directionToTarget);
        // if (angle > 90 || angle < -90) 
        // {
        //     Debug.Log("Target behind player");
        //     isBehindPlayer = true;
        // } else 
        // {
        //     isBehindPlayer = false;
        // }
    }
}
