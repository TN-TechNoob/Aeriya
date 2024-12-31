using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar_V2 : MonoBehaviour
{
    private float health;
    private float maxHealth;
    private float lerpTimer;
    public float chipSpeed = 2f;
    public Image frontHealthBar;
    public Image backHealthBar;

    public void SetMaxHealth(int objectMaxHealth)
    {
        maxHealth = objectMaxHealth;
        health = maxHealth;
    }

    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();
    }

    public void Sethealth(int objectCurrentHealth)
    {
        health = objectCurrentHealth;
        lerpTimer = 0f;
    }

    public void UpdateHealthUI()
    {
        float fillF = frontHealthBar.fillAmount;
        float fillB = backHealthBar.fillAmount;
        float hFraction = health / maxHealth;
        if (fillB > hFraction)
        {
            frontHealthBar.fillAmount = hFraction;
            backHealthBar.color = new Color(1f, 1f, 1f);
            lerpTimer += Time.deltaTime;
            float percentCompelete = lerpTimer / chipSpeed;
            backHealthBar.fillAmount = Mathf.Lerp(fillB, hFraction, percentCompelete);
        }
    }
}
