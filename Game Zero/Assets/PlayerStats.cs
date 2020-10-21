using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth = 10;
    public float playerScore = 0;

    float currentHealth;
    float currentScore;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
           TakeDamage(1); 
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            AddScore(1);
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

    }

    public void AddScore(float amount)
    {
        
        currentScore += amount;
    }
}
