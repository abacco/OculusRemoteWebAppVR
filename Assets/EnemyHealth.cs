using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Slider healthSlider;

    public delegate void DeathAction();
    public event DeathAction OnDeath;

    public GameObject coinPrefab; // Reference to the Coin prefab


    private void Start()
    {
        currentHealth = maxHealth;

        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Trigger the death event
        OnDeath?.Invoke();
        SpawnCoinWithProbability();
        Destroy(gameObject);
    }

    private void SpawnCoinWithProbability()
    {
        float spawnProbability = 0.5f;
        float randomValue = Random.value; // Generate a random value between 0 and 1

        if (randomValue <= spawnProbability)
        {
            // Spawn a coin
            Instantiate(coinPrefab, transform.position, Quaternion.identity);
        }
    }
}
