using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int waveCount = 10;
    public float waveDelay = 2f;

    private int currentWave = 0;
    private bool waveInProgress = false;
    private int activeEnemies = 0;

    public Text waveText;

    private void Start()
    {
        StartNextWave();
    }

    private void StartNextWave()
    {
        currentWave++;
        activeEnemies = waveCount;
        waveInProgress = true;

        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        for (int i = 0; i < waveCount; i++)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void Update()
    {
        if (waveInProgress)
        {
            UpdateWaveText();
            CheckWaveCompletion();
        }
    }

    private void CheckWaveCompletion()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            if (enemy.activeSelf)
            {
                // There is still an active enemy, so the wave is not yet complete
                return;
            }
        }

        // All enemies defeated, wave complete
        waveInProgress = false;

        if (currentWave < waveCount)
        {
            // Start the next wave after a delay
            StartCoroutine(NextWaveDelay());
        }
        else
        {
            // All waves completed, perform end-of-game logic
            Debug.Log("All waves completed!");
        }
    }

    private IEnumerator NextWaveDelay()
    {
        yield return new WaitForSeconds(waveDelay);
        StartNextWave();
    }

    private void UpdateWaveText()
    {
        if (waveText != null)
        {
            waveText.text = "Wave: " + (currentWave + 1) + "/10";
        }
    }





    //public GameObject enemyPrefab;
    //public Transform spawnPoint;
    //public int spawnCount = 2;
    //public int wavesCount = 10;
    //public float timeBetweenWaves = 10f;
    //public string nextSceneName;
    //public Text waveText; // Reference to the Text component

    //private int currentWave = 0;
    //private int spawnedEnemies = 0;
    //private int killedEnemies = 0;
    //private bool isSpawning = false;

    //private void Start()
    //{
    //    // Set the initial wave text
    //    UpdateWaveText();

    //    // Start spawning waves
    //    StartCoroutine(SpawnWaves());
    //}

    //private void Update()
    //{
    //    if (isSpawning)
    //    {
    //        // Check if all waves have been completed
    //        if (currentWave >= wavesCount)
    //        {
    //            // Change to the next scene when all waves are completed
    //            SceneManager.LoadScene(nextSceneName);
    //            return;
    //        }
    //    }
    //}

    //private IEnumerator SpawnWaves()
    //{
    //    isSpawning = true;

    //    while (currentWave < wavesCount)
    //    {
    //        // Spawn enemies for the current wave
    //        for (int i = 0; i < spawnCount; i++)
    //        {
    //            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position + new Vector3(i * 2f, 0f, 0f), Quaternion.identity);
    //            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
    //            enemyHealth.OnDeath += OnEnemyDeath; // Add an action to handle enemy death
    //            spawnedEnemies++;
    //        }



    //        yield return new WaitForSeconds(timeBetweenWaves);

    //        // Check if all enemies have been killed in the current wave
    //        if (killedEnemies >= spawnCount)
    //        {
    //            // Move to the next wave
    //            spawnedEnemies = 0;
    //            killedEnemies = 0;
    //            currentWave++;
    //            UpdateWaveText();
    //        }
    //    }

    //    isSpawning = false;
    //}

    //private void OnEnemyDeath()
    //{
    //    killedEnemies++;
    //}

    //private void UpdateWaveText()
    //{
    //    if (waveText != null)
    //    {
    //        waveText.text = "Wave: " + (currentWave + 1) + "/10";
    //    }
    //}
}
