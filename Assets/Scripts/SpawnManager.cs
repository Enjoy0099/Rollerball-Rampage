using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] enemyPrefab;
    public GameObject[] powerUpPrefab;

    private float spawnRange = 9f;

    public int enemyCount;
    public int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        SpawnPowerUp();
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnPowerUp();
            SpawnEnemyWave(waveNumber);
        }
            
    }

    void SpawnPowerUp()
    {
        int randomPowerUp = Random.Range(0, powerUpPrefab.Length);
        Vector3 Pos = GenerateSpawnPosition() + new Vector3(0f, -0.1f, 0f);
        Instantiate(powerUpPrefab[randomPowerUp], Pos, powerUpPrefab[randomPowerUp].transform.rotation);
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            int random = Random.Range(0, enemyPrefab.Length);
            Instantiate(enemyPrefab[random], GenerateSpawnPosition(), Quaternion.identity);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0.1f, spawnPosZ);

        return randomPos;
    }
}
