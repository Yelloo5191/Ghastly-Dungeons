using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyController : MonoBehaviour
{
    public AIPath aiPath;

    GameManager gameManager;


    float timeBetweenAttacks = 2f;
    float attackTimer = 0f;
    public bool canAttack = true;

    Animator animator;

    float health = 3;

    void Start()
    {
        animator = GetComponent<Animator>();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
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
        canAttack = false;
        animator.SetTrigger("Attack");
        player.TakeDamage(1);
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
        for (int i = 0; i < gameManager.enemies.Length; i++)
        {
            if (gameManager.enemies[i] == gameObject.transform.parent.gameObject)
            {
                gameManager.enemies[i] = null;
            }
        }

        bool allDead = true;
        // set one inactive enemy in the list to be the new active enemy
        for (int i = 0; i < gameManager.enemies.Length; i++)
        {
            if (gameManager.enemies[i] != null)
            {
                allDead = false;
                if (!gameManager.enemies[i].activeSelf) {
                    Debug.Log("Enemy: " + gameManager.enemies[i] + " Active: " + gameManager.enemies[i].activeSelf);
                    gameManager.enemies[i].SetActive(true);
                    break;
                }
            }
        }

        // if no enemies in the list are active, go to the next level
        if (allDead)
        {
            gameManager.NextLevel();
        }


        Destroy(gameObject.transform.parent.gameObject);
    }
}
