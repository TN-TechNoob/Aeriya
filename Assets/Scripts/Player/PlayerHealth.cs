using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
  //  public int maxStrength = 100;
    int currentHealth;
    public HealthBar_V2 healthBarUI;
    int currentStrength;
    public Image frontHealthBar;  // 顯示當前血量的圖片（前景）
    public Image backHealthBar;   // 顯示最大血量的圖片（背景）

    void Start()
    {
        currentHealth = maxHealth;
        if (healthBarUI != null)
        {
            healthBarUI.SetMaxHealth(maxHealth); 
        }
        UpdateHealthUI();
    }

    public void UpdateHealthUI()
    {
        
        float healthFraction = (float)currentHealth / maxHealth;
        frontHealthBar.fillAmount = healthFraction;  // 更新前景
        backHealthBar.fillAmount = 1f;               // 背景血條
    }

    public void AddHealth(int amount)
    {
        
        float amountToAdd = maxHealth * 0.2f;
        currentHealth += (int)amountToAdd;
        if (healthBarUI != null)
        {
            healthBarUI.Sethealth(currentHealth);  
        }
        UpdateHealthUI();
    }
   // public void AddStrength(int amount)
  //  {
   //     currentStrength += amount;

  //      currentStrength = Mathf.Clamp(currentStrength, 0, maxStrength);
  //  }

    public bool isDead => currentHealth <= 0; 

    public void Revive()
    {
        if (isDead)
        {
            float amountToAdd = maxHealth * 1/3;
            currentHealth += (int)amountToAdd;
            if (healthBarUI != null)
            {
                healthBarUI.Sethealth(currentHealth);
            }
            UpdateHealthUI();

        }
        if (healthBarUI != null)
        {
            healthBarUI.Sethealth(currentHealth);  // 確保更新 UI
        }
    }

 
    // Start is called before the first frame update
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBarUI.Sethealth(currentHealth);

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
