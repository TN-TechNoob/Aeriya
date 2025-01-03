using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_V2 : MonoBehaviour
{
    public LevelLoader levelLoader;
    public PlayerHealth playerHealth;
    public Vector2 direction;
    public Animator animator;
    public GameObject player;
    public float speed;
    public float distance;
    public int maxHealth;
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
        CalculateDistance();
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
        levelLoader.LoadHall();
    }

    void CalculateDistance()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        direction = player.transform.position - transform.position;
        direction.Normalize();
    }

    public void Chase()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
