using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_V2 : MonoBehaviour
{
    public Animator animator;
    public GameObject player;
    public float speed;
    private float distance;
    public bool isAttacking;
    public int attackDamage = 20;
    public int maxHealth = 100;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        CalculateDistance();

        if (distance > 2 && !isAttacking)
        {
            Chase();
        }
        else
        {
            if (!isAttacking)
            {
                animator.SetTrigger("Attack");
            }
        }
    }

    public void AttackPlayer()
    {
        if (distance <= 2)
        {
            player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died");

        animator.SetBool("isDead", true);
        
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

    void CalculateDistance()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
    }

    void Chase()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
