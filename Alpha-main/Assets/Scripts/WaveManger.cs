using System.Collections;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject monsterPrefab; // Assign the monster prefab in the inspector
    public float timeBetweenWaves = 10f; // Time in seconds between waves
    private int currentWaveNumber = 0;

    void Start()
    {
        if (DifficultyManager.instance.infiniteWaves)
        {
            StartCoroutine(SpawnWaves());
        }
    }

    private IEnumerator SpawnWaves()
    {
        while (true) // Loop forever for infinite waves
        {
            currentWaveNumber++;
            for (int i = 0; i < currentWaveNumber; i++)
            {
                Instantiate(monsterPrefab, GetSpawnPosition(), Quaternion.identity);
                yield return new WaitForSeconds(1f); // Wait before spawning the next monster
            }
            yield return new WaitForSeconds(timeBetweenWaves); // Wait before starting the next wave
        }
    }

    private Vector3 GetSpawnPosition()
    {
        // Calculate and return a spawn position for the monster
        // This should be replaced with your game's spawn logic
        return new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
    }
}
