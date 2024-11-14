using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int health;
    public int attack;
    public float attackRange = 2.0f; // Attack range radius
    public float attackCooldown = 0.5f; // Seconds between attacks
    public Animator animator; // Reference to the player's animator


    private float lastAttackTime = 0.0f; // Time of the last attack

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= lastAttackTime + attackCooldown)
        {
            lastAttackTime = Time.time; // Update last attack time

            // Detect enemies in attack range
            Collider[] colliders = Physics.OverlapSphere(transform.position, attackRange);
            foreach (Collider collider in colliders)
            {
                if (collider.tag == "Enemy") // Check for enemy tag
                {
                    // Apply damage to the enemy
                    collider.GetComponent<AttributesManager>().TakeDamage(attack);

                    // Visualize attack feedback
                    animator.SetTrigger("Attack"); // Trigger attack animation
                    // Play particle effects or other visual cues
                }
            }
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
    }

    public void DealDamage(GameObject target)
    {
        var atm = target.GetComponent<AttributesManager>();
        if (atm != null)
        {
            atm.TakeDamage(attack);
        }
    }
}
