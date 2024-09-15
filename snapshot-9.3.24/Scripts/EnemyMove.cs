using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    //set the movement speed of the enemy
    [SerializeField]
    private float speed;

    //Set the rotation speed of the enemy to point in the direction of the player
    [SerializeField]
    private float rotationSpeed;

    private Rigidbody2D rigidbody;
    private EnemyAIDetection enemyAIDetection;
    private Vector2 targetDirection;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        enemyAIDetection = GetComponent<EnemyAIDetection>();
    }
    private void FixedUpdate()
    {
        UpdateTargetDirection();// Update the direciton towards the player
        RotateTowardsTarget(); //Rotate the enemy to face the target direction.
        SetVelocity(); //Set the velocity of the enemy to move towards the player
    }
    private void UpdateTargetDirection() //Updates the target direction based on player detection
    {
        //if the player is detected, set the target direction towards the player, else set target direction to zero
        if (enemyAIDetection.PlayerDetection)
        {
            targetDirection = enemyAIDetection.DirectionToPlayer;
        }
        else
        {
            targetDirection = Vector2.zero;
        }
    }

    private void RotateTowardsTarget()
    {   //If there is no target direction then do nothing.
        if (targetDirection == Vector2.zero)
        {
            return;
        }
        //Calculate the target rotation based on the target direction
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, targetDirection);
        //Smootly rotate towards the target rotation
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        
        //Apply the rotation to RigidBody2D
        rigidbody.SetRotation(rotation);
    }

    private void SetVelocity()
    {
        //If there is not target direciton, stops the enemy's movement
        if(targetDirection == Vector2.zero)
        {
            rigidbody.velocity = Vector2.zero;
        }
        else
        {
            //Else move the enemy forward in the direction it is facing.
            rigidbody.velocity = transform.up * speed;
        }
    }
}
