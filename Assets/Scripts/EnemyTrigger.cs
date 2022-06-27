using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{

    Transform enemyParent;
    EnemyController enemy;


    void Awake()
    {
        enemyParent = transform.parent;
        enemy = enemyParent.GetComponentInChildren<EnemyController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null && enemy.canAttack)
        {
            Debug.Log("Player is attacking");
            enemy.Attack(player);
        }
    }
}
