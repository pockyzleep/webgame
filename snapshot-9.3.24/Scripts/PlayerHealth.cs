using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int health;
    public int maxHealth = 100;

    public TextMeshProUGUI healthIndicator;
 
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        UpdateHealth();

    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
       

        if(health <= 0)
        {
            health = 0;
            //destroy the player for now, need game over screen
            Destroy(gameObject);
        }
    }

    public void UpdateHealth()
    {
        healthIndicator.text = health.ToString();
    }
}
