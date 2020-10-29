using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampPosition : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z >= player.transform.position.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z);
        }
    }
}
