using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{
    public AIPath aiPath;

    bool attacking = false;

    float timeBetweenAttacks = 2f;
    float attackTimer = 0f;
    bool canAttack = true;

    Animator animator;

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        if (player != null && attacking)
        {
            // player.TakeDamage(1);
            StopAttacking();
        }
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(aiPath.desiredVelocity.x > 0.01f) 
        {
            animator.SetFloat("Move X", 1);
        }
        else if(aiPath.desiredVelocity.x < -0.01f)
        {
            animator.SetFloat("Move X", -1);
        }
        else if(aiPath.desiredVelocity.y > 0.01f)
        {
            animator.SetFloat("Move Y", 1);
        }
        else if(aiPath.desiredVelocity.y < -0.01f)
        {
            animator.SetFloat("Move Y", -1);
        }

        if(aiPath.reachedEndOfPath && canAttack)
        {
            Attack();
        }

        if (!canAttack) {
            attackTimer += Time.deltaTime;
            if (attackTimer >= timeBetweenAttacks) {
                canAttack = true;
                attackTimer = 0;
            }
        }
    }

    void Attack()
    {
        attacking = true;
        canAttack = false;
        animator.SetTrigger("Attack");
    }

    void StopAttacking()
    {
        attacking = false;
    }
}
