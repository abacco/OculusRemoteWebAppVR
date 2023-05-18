using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    //public Transform target;
    public float speed; //= Random.Range(1f, 10f);
    public float stoppingDistance = 0.1f;

    private void Update()
    {
        speed = Random.Range(1f, 10f);
        // Calculate the direction towards the target position
        Vector3 direction = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;

        // Check if the enemy has reached the target position
        if (direction.magnitude <= stoppingDistance)
        {
            // Enemy has reached the target, stop moving
            return;
        }

        // Normalize the direction vector to get a consistent speed
        // direction.Normalize();

        // Move the enemy towards the target position
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
