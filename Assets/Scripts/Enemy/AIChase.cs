using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class AIChase : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /* 
        distance = Vector3.Distance(transform.position, player.transform.position);
        Vector3 direction = player.transform.position - transform.position;
        direction.Normalize();
        */
        // float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

        // transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        // transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }

    void FixedUpdate()
    {
        Vector3 direction = new Vector3(
            player.transform.position.x - transform.position.x,
            0,
            player.transform.position.z - transform.position.z
        );
        direction.Normalize();

        Vector3 newPosition = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);

        newPosition.y = transform.position.y; // Keep the same Y position

        transform.position = newPosition;
    }
}
