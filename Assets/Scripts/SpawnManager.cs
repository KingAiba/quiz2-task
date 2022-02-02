using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefabs;

    public Transform[] spawnPoints; 

    public int maxEnemy = 15;
    public int enemyPerWave = 5;

    public int enemyCount;

    public float Timer = 60;
    public int Lost = 0;

    private GameManager gameManger;

    // Start is called before the first frame update
    void Start()
    {
        gameManger = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(LevelTimer());
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = gameManger.GetActiveEnemyCount();
        SpawnWave();
    }

    public Vector3 GetRandomSpawnPoint()
    {
        int selectedSpawnPoint = Random.Range(0, spawnPoints.Length);
        return spawnPoints[selectedSpawnPoint].position;
    }



    public void SpawnWave()
    {
        if (enemyCount < enemyPerWave)
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
