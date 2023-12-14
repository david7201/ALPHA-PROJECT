using System.Collections;
using UnityEngine;
using System.Collections.Generic;


public class MonsterSpawner : MonoBehaviour
{
    public GameObject monsterPrefab;
    public GameObject powerUpPrefab; // Assign your power-up prefab in the inspector
    public int initialMonstersToSpawn = 3;
    public float spawnInterval = 5f;
    private float screenMinX = -11f;
    private float screenMaxX = 14f;
    private float spawnY = 3f; // Y position just above the screen
    private int currentWave = 0;
    private int totalWaves = 5;
    private float minSpawnDistance = 2f; // Minimum distance between spawned monsters
    private List<Vector3> spawnedPositions = new List<Vector3>();

    private void Start()
    {
        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        currentWave++;
        spawnedPositions.Clear(); // Clear previous positions
        for (int i = 0; i < initialMonstersToSpawn; i++)
        {
            SpawnMonster();
            yield return new WaitForSeconds(0.1f); // Small delay between each spawn
        }
        
        // Wait for all monsters to be destroyed
        yield return new WaitUntil(() => GameObject.FindGameObjectsWithTag("Monster").Length == 0);

        // Increase the number of monsters for the next wave
        initialMonstersToSpawn++;

        // Drop a power-up every two waves
        if (currentWave % 2 == 0 && currentWave != totalWaves)
        {
            DropPowerUp();
        }

        // Check if we have finished all waves
        if (currentWave < totalWaves)
        {
            yield return new WaitForSeconds(spawnInterval);
            StartCoroutine(SpawnWave());
        }
        else
        {
            Debug.Log("Finished Spawning Monsters");
            // Game finish logic here
        }
    }

    private void SpawnMonster()
    {
        Vector3 spawnPosition = GetSpawnPosition();
        Instantiate(monsterPrefab, spawnPosition, Quaternion.identity);
    }

    private Vector3 GetSpawnPosition()
    {
        Vector3 spawnPosition;
        bool positionValid;
        do
        {
            positionValid = true;
            float randomX = Random.Range(screenMinX, screenMaxX);
            spawnPosition = new Vector3(randomX, spawnY, 0f);

            // Check against all previously spawned positions
            foreach (Vector3 prevPosition in spawnedPositions)
            {
                if (Vector3.Distance(prevPosition, spawnPosition) < minSpawnDistance)
                {
                    positionValid = false;
                    break;
                }
            }
        } while (!positionValid);

        spawnedPositions.Add(spawnPosition);
        return spawnPosition;
    }

    private void DropPowerUp()
    {
        float randomX = Random.Range(screenMinX, screenMaxX);
        Vector3 dropPosition = new Vector3(randomX, spawnY, 0f);
        Instantiate(powerUpPrefab, dropPosition, Quaternion.identity);
    }
    
}
