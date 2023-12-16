using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class MonsterSpawner : MonoBehaviour
{
    // Prefabs for different difficulty levels
    public GameObject easyMonsterPrefab;
    public GameObject mediumMonsterPrefab;
    public GameObject hardMonsterPrefab;
    public GameObject powerUpPrefab; // Assign your power-up prefab in the inspector

    // Configuration parameters
    public int initialMonstersToSpawn = 3;
    public float spawnInterval = 2f;
    private float screenMinX = -11f;
    private float screenMaxX = 14f;
    private float spawnY = 3f; // Y position just above the screen
    private int currentWave = 0;
    private float minSpawnDistance = 2f; // Minimum distance between spawned monsters

    // Keep track of spawned positions to avoid overlapping
    private List<Vector3> spawnedPositions = new List<Vector3>();

    // Enum to represent difficulty levels
    public enum Difficulty { Easy, Medium, Hard }
    public Difficulty gameDifficulty; // Set this in the inspector for each scene

    private void Start()
    {
        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
{
    currentWave++;
    spawnedPositions.Clear(); // Clear previous positions

    int monstersToSpawn = initialMonstersToSpawn;
    // Increment the number of monsters for Hard difficulty with each wave
    if (gameDifficulty == Difficulty.Hard)
    {
        monstersToSpawn += currentWave - 1;
    }

    for (int i = 0; i < monstersToSpawn; i++)
    {
        SpawnMonster();
        yield return new WaitForSeconds(0.1f); // Small delay between each spawn
    }

    // Wait for all monsters to be destroyed before spawning the next wave
    yield return new WaitUntil(() => GameObject.FindGameObjectsWithTag("Monster").Length == 0);

    // Drop a power-up every two waves
    if (currentWave % 2 == 0)
    {
        DropPowerUp();
    }

    // If it's not Hard difficulty, check if the current wave is less than the total waves
    if (gameDifficulty != Difficulty.Hard && currentWave >= 5)
    {
        Debug.Log("Finished Spawning Monsters");
        // Game finish logic or transition to another scene could be added here
    }
    else
    {
        // For Medium and Hard, keep spawning waves continuously
        yield return new WaitForSeconds(2f); // 2-second delay before the next wave
        StartCoroutine(SpawnWave());
    }
}


    private void SpawnMonster()
{
    GameObject prefabToSpawn = easyMonsterPrefab; // Default to Easy
    int healthToSet = 1; // Default health for easy difficulty

    switch (gameDifficulty)
    {
        case Difficulty.Easy:
            prefabToSpawn = easyMonsterPrefab;
            healthToSet = 1;
            break;
        case Difficulty.Medium:
            prefabToSpawn = mediumMonsterPrefab;
            healthToSet = 2; // Monsters require two hits in medium difficulty
            break;
        case Difficulty.Hard:
            prefabToSpawn = hardMonsterPrefab;
            healthToSet = 3; // Monsters require three hits in hard difficulty
            break;
    }

    Vector3 spawnPosition = GetRandomSpawnPosition();
    GameObject spawnedMonster = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

    // Ensure that the monsterComponent variable is used within the same block it is defined
    Monster monsterComponent = spawnedMonster.GetComponent<Monster>();
    if (monsterComponent != null)
    {
        monsterComponent.InitializeHealth(healthToSet);
    }
    else
    {
        Debug.LogError("Spawned Monster does not have a Monster component.", spawnedMonster);
    }
}


    private Vector3 GetRandomSpawnPosition()
    {
        Vector3 spawnPosition;
        bool positionValid = false;
        do
        {
            float randomX = Random.Range(screenMinX, screenMaxX);
            spawnPosition = new Vector3(randomX, spawnY, 0f);

            positionValid = true;
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
