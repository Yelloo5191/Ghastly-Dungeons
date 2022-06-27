using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyController : MonoBehaviour
{
    public AIPath aiPath;

    bool attacking = false;

    float timeBetweenAttacks = 2f;
    float attackTimer = 0f;
    public bool canAttack = true;

    Animator animator;

    float health = 3;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(aiPath.desiredVelocity.x > 0.01f) 
        {
            animator.SetFloat("Move X", .5f);
        }
        if(aiPath.desiredVelocity.x < -0.01f)
        {
            animator.SetFloat("Move X", -.5f);
        }
        if(aiPath.desiredVelocity.y > 0.01f)
        {
            animator.SetFloat("Move Y", .5f);
        }
        if(aiPath.desiredVelocity.y < -0.01f)
        {
            animator.SetFloat("Move Y", -.5f);
        }


        if (!canAttack) {
            attackTimer += Time.deltaTime;
            if (attackTimer >= timeBetweenAttacks) {
                canAttack = true;
                attackTimer = 0;
            }
        }
    }

    public void Attack(PlayerController player)
    {
        attacking = true;
        canAttack = false;
        animator.SetTrigger("Attack");
        player.TakeDamage(1);
        StopAttacking();
    }

    void StopAttacking()
    {
        attacking = false;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    } 

    void Die()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }
}
