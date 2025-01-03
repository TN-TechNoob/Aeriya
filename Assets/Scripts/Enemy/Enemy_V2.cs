using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_V2 : MonoBehaviour
{
    public PlayerHealth playerHealth;
    private Vector2 direction;
    public Animator animator;
    public SpriteRenderer sprite;
    public GameObject player;
    public float speed;
    private float distance;
    public float attackRange;
    public bool isAttacking;
    public bool isAttack_V1;
    public float attackCoolDown = 0.5f;
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

        if (distance > attackRange && !isAttacking)
        {
            Chase();
        }
        else if (distance <= attackRange && !isAttacking)
        {
            attackCoolDown -= Time.deltaTime;
            Debug.Log(distance + " " + isAttacking + " " + isAttack_V1);
            speed = 1.5f;
            int attaackSelect = Random.Range(1, 3);
            if (!isAttack_V1)
            {
                Debug.Log(attaackSelect);
                if (attaackSelect == 1 && attackCoolDown <= 0)
                {
                    animator.SetTrigger("Attack_V1");
                }
                else if (attaackSelect == 2 && attackCoolDown <= 0)
                {
                    animator.SetTrigger("Attack_V2");
                    attackCoolDown = 0.5f;
                }
            }
            else
            {   
                animator.SetTrigger("Attack_V3");
                attackCoolDown = 0.5f;
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
        if (distance <= attackRange)
        {
            player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
        }
    }

    public void BoostAndAttackPlayer()
    {
        if (distance > 4)
        {
            speed = speed * 2;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= (int)Mathf.Round(damage * (playerHealth.buffTime + 1.5f));

        healthbar.Sethealth(currentHealth);

        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
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
