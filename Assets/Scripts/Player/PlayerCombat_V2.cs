using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat_V2 : MonoBehaviour
{
    private PlayerCtrl playerCtrl;
    private Animator animator;
    public LayerMask enemyLayers;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int attackDamage = 20;

    public float attackRate = 1.2f;
    float nextAttackTime = 0f; 


    void Awake()
    {
        playerCtrl = GetComponentInParent<PlayerCtrl>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                animator.SetTrigger("IsAttacking");
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    public void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy_V2>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}