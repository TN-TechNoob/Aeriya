using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    public int maxStrength = 100;
    int currentHealth;
<<<<<<< Updated upstream
=======
    public HealthBar_V2 healthbar;
>>>>>>> Stashed changes
    int currentStrength;

    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    public void AddHealth(int amount)
    {
        currentHealth += amount;

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }
    public void AddStrength(int amount)
    {
        currentStrength += amount;

        currentStrength = Mathf.Clamp(currentStrength, 0, maxStrength);
    }

    public bool isDead => currentHealth <= 0; 

    public void Revive()
    {
        if (isDead)
        {
            currentHealth = maxHealth / 3; 
           
        }
    }

    public void AddHealth(int amount)
    {
        currentHealth += amount;

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }
    public void AddStrength(int amount)
    {
        currentStrength += amount;

        currentStrength = Mathf.Clamp(currentStrength, 0, maxStrength);
    }

    public bool isDead => currentHealth <= 0; 

    public void Revive()
    {
        if (isDead)
        {
            currentHealth = maxHealth / 3; 
           
        }
    }

    // Start is called before the first frame update
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
        // play die animation
        // Destroy(gameObject);
    }
}
