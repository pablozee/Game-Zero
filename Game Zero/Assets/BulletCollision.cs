using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.transform.tag == "Enemy")
        {
            other.collider.GetComponent<EnemyStats>().TakeDamage(10);
            Destroy(gameObject);
        }
    }
}
