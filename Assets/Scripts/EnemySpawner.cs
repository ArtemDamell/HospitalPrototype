using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject EnemyPrefab;

    [SerializeField]
    int spawnCount = 10;

    [SerializeField]
    float timeBetweenNextSpawn = 2f;

    GameObject[] SpawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        // Get all spawn points
        SpawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
    }

    // Create new courutine method
    /// <summary>
    /// Spawns a number of enemies at random spawn points, and doubles the spawn count each time the loop ends.
    /// </summary>
    /// <returns>
    /// An IEnumerator object.
    /// </returns>
    IEnumerator SpawnZombie()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            var spawnPoint = Random.Range(0, SpawnPoints.Length); // <-- Get a random number

            Instantiate(EnemyPrefab, SpawnPoints[spawnPoint].transform.position, Quaternion.identity); // <-- Instantiate enemy

            yield return new WaitForSeconds(timeBetweenNextSpawn); // <-- Wait 2 seconds and continue the cycle
        }

        spawnCount *= 2; // <-- when the loop ends, multiply the counter by 2
    }

    // Create start courutine public method for another scripts
    // Call the method when player enter to the Rise trigger
    /// <summary>
    /// Starts a coroutine to spawn zombies.
    /// </summary>
    public void StartSpawnZombie()
    {
        StartCoroutine(nameof(SpawnZombie));
    }
}
