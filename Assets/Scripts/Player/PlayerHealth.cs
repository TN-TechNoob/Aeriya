using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameObject[] buffindicators;
    int buffTime = 0;
    public PlayerCtrl playerCtrl;
    public LevelLoader levelLoader;
    public Animator animator;
    public int maxHealth = 100;
    public int maxStrength = 100;
    int currentHealth;
    public HealthBar_V2 healthbar;
    int currentStrength;
    public float damageReduce;

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

    public void TakeDamage(float damage)
    {
        if (playerCtrl.isShielding == true)
        {
            if (playerCtrl.perfectReduceTime > 0)
            {
                damageReduce = 1f;
                if (buffTime < 3)
                {
                    buffTime ++;
                    BuffIndicatorEnable();
                }
                animator.SetTrigger("PerfectShield");
                animator.SetBool("IsShielding", false);
            }
            else
            {
                damageReduce = 0.3f;
                animator.SetTrigger("Hurt");
            }
        }
        else
        {
            damageReduce = 0f;
            animator.SetTrigger("Hurt");
        }
        currentHealth -= (int)Mathf.Round(damage * (1 - damageReduce));

        healthbar.Sethealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void BuffIndicatorEnable()
    {
        if (buffTime == 1)
        {
            
        }
        Debug.Log(buffTime);
    }

    void Die()
    {
        levelLoader.LoadStartMenu();
        // play die animation
        // Destroy(gameObject);
    }
}
