using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public GameObject player;
    public float speed;
    public float strength, delay;
    public int maxHealth;
    private int currentHealth;
    public LayerMask playerLayers;
    public int attackDamage;
    private Rigidbody rb;
    private SpriteRenderer spriteRenderer;
    private float nextAttackTime = 0;
    public float attackCooldown, attackRange;


    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            animator.SetBool("IsAttacking", false);
            Attack();
            nextAttackTime = Time.time + attackCooldown;
        }

        spriteRenderer.flipX = player.transform.position.x < transform.position.x;

    }

    void FixedUpdate()
    {
        if (Vector2.Distance (player.transform.position, transform.position) < 1000f )
        {
            Vector2 direction = player.transform.position - transform.position;

            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    void Attack()
    {
        Collider[] hitPlayer = Physics.OverlapSphere(attackPoint.position, attackRange, playerLayers);

        foreach (Collider player in hitPlayer)
        {
            animator.SetBool("IsAttacking", true);
            player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
        }
        Debug.Log("Test");
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
            animator.SetTrigger("IsDead");
        }
    }
    
    public void Die()
    {
        Destroy(gameObject);
        /*StartCoroutine(DropCoins());*/
    }

    /*
    IEnumerator DropCoins()
    {
        for (int i = 0; i < numberOfCoinsToDrop; i++)
        {
            Vector3 randomPoint = Random.insideUnitSphere * dropRadius;

            Vector3 randomCoinPosition = new Vector3(
            transform.position.x + randomPoint.x,
            coin.transform.position.y,
            transform.position.z + randomPoint.z
            );

            Instantiate(coin, randomCoinPosition, coin.transform.rotation);

            yield return new WaitForSeconds(dropDelay);
        }

        Destroy(gameObject);
    }
    */

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
