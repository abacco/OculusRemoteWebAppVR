using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{

    EnemyHealth enemyHealth; // enemy is this gameObject

    private void Start()
    {
        enemyHealth = gameObject.GetComponent<EnemyHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Hit TRIGGER");
            GameManager.instance.playerHealth -= 2;
        }
        else if (collision.gameObject.CompareTag("Weapon"))
        {
            Debug.Log("Weapon Hit TRIGGER");
            enemyHealth.TakeDamage(2);
        }
        if (collision.gameObject.CompareTag("Coin"))
        {
            Coin coin = collision.gameObject.GetComponent<Coin>();
            if (coin != null)
            {
                // Handle coin pickup (e.g., increment player's coin count, play a sound effect, etc.)
                coin.Pickup();
            }
        }
    }
}
