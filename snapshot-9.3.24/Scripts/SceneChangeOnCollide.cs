using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeOnCollide : MonoBehaviour 
{
    [SerializeField]
    int nextSceneID;


    //Allows editing of next scene through inspector for more wide applications
    void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.gameObject.tag == "Player") {
            SceneManager.LoadScene(nextSceneID);
        }
    }
}
