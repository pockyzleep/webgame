using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePopUp : MonoBehaviour
{
    public Vector2 TextVelocity;
    public Rigidbody2D popUpText;
    public float DamagePopUpLifetime = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        //Destroy Pop Up Damage after some seconds
        popUpText.velocity = TextVelocity;
        Destroy(gameObject, DamagePopUpLifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
