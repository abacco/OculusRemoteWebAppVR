using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Debug.Log("Coin collision");
            Coin coin = collision.gameObject.GetComponent<Coin>();
            if (coin != null)
            {
                // Handle coin pickup (e.g., increment player's coin count, play a sound effect, etc.)
                coin.Pickup();
                Destroy(coin);
            }
        }
    }
}
