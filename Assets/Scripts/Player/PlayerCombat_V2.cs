using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class PlayerCombat_V2 : MonoBehaviour
{
    private PlayerCtrl playerCtrl;
    private Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;


    void Awake()
    {
        playerCtrl = GetComponentInParent<PlayerCtrl>();
        animator = GetComponent<Animator>();
    }

    public void Attack()
    {
        animator.SetTrigger("IsAttacking");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("Hit" + enemy.name);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}