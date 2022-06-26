using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);

    Rigidbody2D rb;
    public float speed = 3.0f;
    float horizontal;
    float vertical;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }
                
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

    }

    void FixedUpdate()
    {
        Vector2 position = rb.position;
        position.x = position.x + speed * horizontal * Time.fixedDeltaTime;
        position.y = position.y + speed * vertical * Time.fixedDeltaTime;

        rb.MovePosition(position);
    }



}
