using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack_Boss2 : MonoBehaviour
{
    public Enemy_V2 enemy_V2;
    public Animator animator;
    public GameObject player;
    public GameObject flyingSword;
    public Transform swordSpawnPoint;
    private float distance;
    public float attackRange;
    public bool isAttacking;
    public float attackCoolDown;
    private float attackCD;
    public float swordAttackCoolDown;
    private float swordAttackCD;
    public int attackDamage;

    // Start is called before the first frame update
    void Start()
    {
        swordAttackCD = swordAttackCoolDown;
        attackCD = attackCoolDown;
    }

    void Update()
    {
        if (enemy_V2.distance > attackRange && !isAttacking)
        {
            swordAttackCD -= Time.deltaTime;
            enemy_V2.Chase();
            attackCD = attackCoolDown;
            if (swordAttackCD <= 0)
            {
                Shoot();
            }
        }
        else if (distance <= attackRange && !isAttacking)
        {
            attackCD -= Time.deltaTime;
            AttackPlayerCheck();
        }
    }

    public void AttackPlayerCheck()
    {
        Debug.Log(distance + " " + isAttacking);
        enemy_V2.speed = 2f;
        int attaackSelect = Random.Range(1, 4);
        Debug.Log(attaackSelect);
        if (attaackSelect == 1 && attackCD <= 0)
        {
            animator.SetTrigger("Attack_V1");
        }
        else if (attaackSelect == 2 && attackCD <= 0)
        {
            animator.SetTrigger("Attack_V2");
        }
    }

    void Shoot()
    {
        Instantiate(flyingSword, swordSpawnPoint.position, Quaternion.identity);
        swordAttackCD = swordAttackCoolDown;
    }

    public void AttackPlayer()
    {
        attackCD = attackCoolDown;
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
