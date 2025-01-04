using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlySword : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float force;
    public SpriteRenderer sprite;
    private float flyTime = 0.5f;
    private float distance;
    private Vector2 playerPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerPos = player.transform.position;
        Vector3 direction = player.transform.position - transform.position;

        if (direction.x > 0)
        {
            sprite.flipX = false;
        }
        else
        {
            sprite.flipX = true;
        }

        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
    }

    // Update is called once per frame
    void Update()
    {
        CalculateDistance();
        flyTime -= Time.deltaTime;
        if (Vector2.Distance(transform.position, playerPos) <= 1)
        {
            rb.velocity = Vector2.zero;
        }
        if (flyTime <= -0.6f)
        {
            Destroy(gameObject);
        }
    }

    public void AttackPlayer()
    {
        if (distance <= 1)
        {
            player.GetComponent<PlayerHealth>().TakeDamage(50);
        }
    }

    void CalculateDistance()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
    }
}
