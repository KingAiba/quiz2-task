using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefabs;

    //public float spawnRangeX;
    //public float spawnRangeZ;
    public Transform[] spawnPoints; 

    public int maxEnemy = 15;
    //public int curEnemySpawned = 0;
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

    public Vector3 GetRandomSpawnPoint()
    {
        int selectedSpawnPoint = Random.Range(0, spawnPoints.Length);
        return spawnPoints[selectedSpawnPoint].position;
    }



    public void SpawnWave()
    {
        if (enemyCount == 0)
        {
            for (int i = 0; i < enemyPerWave; i++)
            {
                Instantiate(enemyPrefabs, GetRandomSpawnPoint(), enemyPrefabs.transform.rotation);

            }
        }
    }

    IEnumerator LevelTimer()
    {
        yield return new WaitForSeconds(Timer);
    }
}
