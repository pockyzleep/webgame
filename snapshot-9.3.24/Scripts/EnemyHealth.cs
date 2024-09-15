using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    int health = 0;
    [SerializeField]
    int maxHealth = 50;

    void Start() {
        health = maxHealth;
    }

    public void TakeDamage(int damageAmount) {
        health -= damageAmount;

        if (health <= 0) {
            // destroy the enemy 
            Destroy(gameObject);
        }
    }
}
