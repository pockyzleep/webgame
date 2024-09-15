using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyDamagePlayer : MonoBehaviour
{
    [SerializeField]
    public int damageTowardPlayer = 0;

    [SerializeField]
    private float knockbackForce = 100f;

    private PlayerHealth playerHealth;

    public GameObject DamagePopUpPrefab;

    public EnemyAIDetection enemyAIDetection;

    private Rigidbody2D playerRb;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
           
            //find player health script each time enemy collides with player and deal damage
            if (playerHealth == null)
            {
                playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            }
            playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
         

            //when player gets damaged, damage pop up will show at the position of the player's position.
            GameObject damagePopUp = Instantiate(DamagePopUpPrefab, collision.transform.position, Quaternion.identity);
            //pop up text shows specific damage being dealt.
            damagePopUp.GetComponentInChildren<TMP_Text>().text = damageTowardPlayer.ToString();

            playerHealth.TakeDamage(damageTowardPlayer);
            playerHealth.UpdateHealth();

            // Apply knockback using the direction from EnemyAIDetection
            //The knockback direction is based on the opposite direction of where the enemy is approaching the player
            Vector2 knockbackDireciton = enemyAIDetection.DirectionToPlayer;
            
            //Apply knockback to player by calling the function in playercontroller
            //the direction of where the player will be moved to will multiply with the value of knockbackForce that can be changed within Unity.
            collision.gameObject.GetComponent<PlayerController>().ApplyKnockback(knockbackDireciton * knockbackForce);


        }
    }
}
