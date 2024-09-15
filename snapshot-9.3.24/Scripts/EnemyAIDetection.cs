using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIDetection : MonoBehaviour
{
    public bool PlayerDetection {  get; private set; }
    public Vector2 DirectionToPlayer { get; private set; }

    //set the range of when the enemy will detect the player once they get within detection range.
    [SerializeField]
    private float playerDistanceAwareness;

    private Transform player;
    
    
    private void Awake()
    {
        player = FindObjectOfType<PlayerController>().transform;
    }

    
    void Update()
    {
        //Once every frame, the distance of the enemy to the player is calculated and the vector is normalized to get the direction to the player
        //As the player moves around, the enemy will continues to calculate the distance and approach the player as long as they are within detection range.
        Vector2 enemyToPlayerVector = player.position - transform.position;
        DirectionToPlayer = enemyToPlayerVector.normalized;

        if(enemyToPlayerVector.magnitude <= playerDistanceAwareness)
        {
            PlayerDetection = true;
        }
        else
        {
            PlayerDetection = false;
        }
    }
}
