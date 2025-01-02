using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_V2 : MonoBehaviour
{
    private Vector2 direction;
    public Animator animator;
    public SpriteRenderer sprite;
    public GameObject player;
    public float speed;
    private float distance;
    public bool isAttacking;
    public int attackDamage = 20;
    public int maxHealth = 100;
    int currentHealth;
    public HealthBar_V2 healthbar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        Flip();
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

    void Flip()
    {
        if (direction.x > 0)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
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

        healthbar.Sethealth(currentHealth);

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
        direction = player.transform.position - transform.position;
        direction.Normalize();
    }

    void Chase()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
