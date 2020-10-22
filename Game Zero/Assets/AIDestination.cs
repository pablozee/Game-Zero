using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDestination : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Enemy;

    void Update() {
        if (Vector3.Distance(this.gameObject.transform.position, Enemy.transform.position) < 2f)
        {
            float xPos = Random.Range(3, 10);
            float zPos = Random.Range(87, 97);
            gameObject.transform.position = new Vector3(xPos, 1, zPos);
            Debug.Log("Collision");


        }
    }
    void OnTriggerEnter(Collider other) {
        if (other.tag == "Enemy")
        {
            Debug.Log("Enemy collided");
            float xPos = Random.Range(3, 10);
            float zPos = Random.Range(87, 97);
            gameObject.transform.position = new Vector3(xPos, 1, zPos);
        }
        Debug.Log("Collision");
    }

    private void OnCollisionEnter(Collision other) {
        if (other.collider.tag == "Enemy")
        {
            Debug.Log("Enemy collided");
            float xPos = Random.Range(3, 10);
            float zPos = Random.Range(87, 97);
            gameObject.transform.position = new Vector3(xPos, 1, zPos);
        }
        Debug.Log("Collision");

    }
}
