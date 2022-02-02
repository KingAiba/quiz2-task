using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefabs;

    public float spawnRangeX;
    public float spawnRangeZ;

    public int maxEnemy = 15;
    public int curEnemySpawned = 0;
    public int enemyPerWave = 5;

    public int enemyCount;

    public float Timer = 60;
    public int Lost = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LevelTimer());
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        SpawnWave();
    }

    public Vector3 GenerateSpawnPoint()
    {
        return new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, Random.Range(-spawnRangeZ, spawnRangeZ));
    }



    public void SpawnWave()
    {
        if (enemyCount == 0 && curEnemySpawned != maxEnemy)
        {
            for (int i = 0; i < enemyPerWave; i++)
            {
                Instantiate(enemyPrefabs, GenerateSpawnPoint(), enemyPrefabs.transform.rotation);

            }
            curEnemySpawned += enemyPerWave;
        }
    }

    IEnumerator LevelTimer()
    {
        yield return new WaitForSeconds(Timer);
        if(curEnemySpawned != maxEnemy)
        {
            Lost = 1;
        }
        else
        {
            Lost = -1;
        }
    }
}
