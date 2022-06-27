using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    Rigidbody2D rigidbody2d;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Launch(Vector2 direction, float force)
    {
        direction.Normalize();   
        
        rigidbody2d.AddForce(direction * force);
        
        Debug.Log("direction:" + direction);
        Debug.Log("force:" + force);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // we also add a debug log to know what the projectile touch
        // Debug.Log("Projectile Collision with " + other.gameObject);
        Destroy(gameObject);
    }

}



