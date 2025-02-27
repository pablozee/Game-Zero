﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public PlayerStats playerStats;
    public float maxHealth = 10;

    float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        if (currentHealth >= 0) 
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        playerStats.AddScore(10);
    }
}
