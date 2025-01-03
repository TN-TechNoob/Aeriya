using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack_Boss1 : MonoBehaviour
{
    public Enemy_V2 enemy_V2;
    public Animator animator;
    public GameObject player;
    private float distance;
    public float attackRange;
    public bool isAttacking;
    public bool isAttack_V1;
    public float attackCoolDown;
    private float attackCD;
    public int attackDamage;

    // Start is called before the first frame update
    void Start()
    {
        attackCD = attackCoolDown;
    }

    void Update()
    {
        if (enemy_V2.distance > attackRange && !isAttacking)
        {
            enemy_V2.Chase();
        }
        else if (distance <= attackRange && !isAttacking)
        {
            AttackPlayerCheck();
        }
    }

    public void AttackPlayerCheck()
    {
        attackCD -= Time.deltaTime;
        Debug.Log(distance + " " + isAttacking + " " + isAttack_V1);
        enemy_V2.speed = 1.5f;
        int attaackSelect = Random.Range(1, 3);
        if (!isAttack_V1)
        {
            Debug.Log(attaackSelect);
            if (attaackSelect == 1 && attackCD <= 0)
            {
                animator.SetTrigger("Attack_V1");
                attackCD = attackCoolDown;
            }
            else if (attaackSelect == 2 && attackCD <= 0)
            {
                animator.SetTrigger("Attack_V2");
                attackCD = attackCoolDown;
            }
        }
        else
        {   
            animator.SetTrigger("Attack_V3");
            attackCD = attackCoolDown;
        }
    }

    public void AttackPlayer()
    {
        if (distance <= attackRange)
        {
            player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
        }
    }

    public void BoostAndAttackPlayer()
    {
        if (distance > 4)
        {
            enemy_V2.speed = enemy_V2.speed * 2;
        }
    }
}
