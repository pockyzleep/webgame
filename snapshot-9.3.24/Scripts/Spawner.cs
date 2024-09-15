using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject[] enemyList;

    private GameObject spawnedEnemy;


    //Sample Test Location
    [SerializeField]
    private Transform[] locationList;

    [SerializeField]
    private int maxAmountsOfEnemy;

    private int pickEnemy;
    private int randomSpot;
    private bool collisionDetected;
    private int totalEnemy = 0;

    void Start()
    {
          
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            collisionDetected = true;
        
            StartCoroutine(SpawnEnemy());
        }
  
    }
    IEnumerator SpawnEnemy()
    {
        while (collisionDetected == true && totalEnemy < maxAmountsOfEnemy)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));

            pickEnemy = Random.Range(0, enemyList.Length);
            randomSpot = Random.Range(0, locationList.Length);

            spawnedEnemy = Instantiate(enemyList[pickEnemy], locationList[randomSpot].position, Quaternion.identity);
            totalEnemy++;
           
        }
    }
}
