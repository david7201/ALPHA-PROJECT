using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class MediumWaveManager : MonoBehaviour
{
    public GameObject mediumMonsterPrefab; 
    public GameObject powerUpPrefab; 
    public YouWinManager youWinManager;

    public int initialMonstersToSpawn = 3; 
    public int totalWaves = 5; 
    public float spawnInterval = 2f; 
    private float waveDelay = 5f; 

    private float screenMinX = -11f;
    private float screenMaxX = 14f;
    private float spawnY = 3f;
    private int currentWave = 0;

    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        while (currentWave < totalWaves)
        {
            currentWave++;
            int monstersToSpawnThisWave = initialMonstersToSpawn + currentWave - 1;

            for (int i = 0; i < monstersToSpawnThisWave; i++)
            {
                SpawnMonster();
                yield return new WaitForSeconds(spawnInterval);
            }

            if (powerUpPrefab != null && currentWave % 2 == 0)
            {
                DropPowerUp();
            }

            yield return new WaitForSeconds(waveDelay);
        }

        Debug.Log("Finished Spawning Waves");
        youWinManager.ShowYouWinScreen(true);
    }

    private void SpawnMonster()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(screenMinX, screenMaxX), spawnY, 0f);
        GameObject monster = Instantiate(mediumMonsterPrefab, spawnPosition, Quaternion.identity);
        monster.GetComponent<Monster>().InitializeHealth(2); 
    }

    private void DropPowerUp()
    {
        Vector3 dropPosition = new Vector3(Random.Range(screenMinX, screenMaxX), spawnY, 0f);
        Instantiate(powerUpPrefab, dropPosition, Quaternion.identity);
    }
}
