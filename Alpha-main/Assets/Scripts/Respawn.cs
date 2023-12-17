using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject easyMonsterPrefab;
    public GameObject mediumMonsterPrefab;
    public GameObject hardMonsterPrefab;
    public GameObject powerUpPrefab; 
    public YouWinManager youWinManager;

    public int initialMonstersToSpawn = 3;
    public float spawnInterval = 2f;
    private float screenMinX = -11f;
    private float screenMaxX = 14f;
    private float spawnY = 3f; 
    private int currentWave = 0;
    private float minSpawnDistance = 2f; 

    private List<Vector3> spawnedPositions = new List<Vector3>();

    public enum Difficulty { Easy, Medium, Hard }
    public Difficulty gameDifficulty; 
    private void Start()
    {
        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
{
    currentWave++;
    spawnedPositions.Clear(); 

    int monstersToSpawn = initialMonstersToSpawn;
    if (gameDifficulty == Difficulty.Hard)
    {
        monstersToSpawn += currentWave - 1;
    }

    for (int i = 0; i < monstersToSpawn; i++)
    {
        SpawnMonster();
        yield return new WaitForSeconds(0.1f); 
    }

    yield return new WaitUntil(() => GameObject.FindGameObjectsWithTag("Monster").Length == 0);

    if (currentWave % 2 == 0)
    {
        DropPowerUp();
    }

    if (gameDifficulty != Difficulty.Hard && currentWave >= 5)
    {
        Debug.Log("Finished Spawning Monsters");
        youWinManager.ShowYouWinScreen(true);
    }
    else
    {
        yield return new WaitForSeconds(2f); 
        StartCoroutine(SpawnWave());
    }
}


    private void SpawnMonster()
{
    GameObject prefabToSpawn = easyMonsterPrefab; 
    int healthToSet = 1; 
    switch (gameDifficulty)
    {
        case Difficulty.Easy:
            prefabToSpawn = easyMonsterPrefab;
            healthToSet = 1;
            break;
        case Difficulty.Medium:
            prefabToSpawn = mediumMonsterPrefab;
            healthToSet = 2; 
            break;
        case Difficulty.Hard:
            prefabToSpawn = hardMonsterPrefab;
            healthToSet = 3; 
            break;
    }

    Vector3 spawnPosition = GetRandomSpawnPosition();
    GameObject spawnedMonster = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

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
