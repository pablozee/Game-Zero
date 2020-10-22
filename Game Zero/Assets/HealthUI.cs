using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public PlayerStats playerStats;
    Text playerHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth.text = "Health: " + playerStats.currentHealth.ToString();
    }
}
