using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    public int waveNumber = 1;
    public int enemiesAlive = 0;
    public GameObject[] spawnPoints;
    public int enemiesPerWave = 5;

    private void Start()
    {
        StartCoroutine(GenerateWave());
    }

    private IEnumerator GenerateWave()
    {
        for (int i = 0; i < enemiesPerWave; i++)
        {
            GameObject enemyPrefab = Resources.Load<GameObject>("Base_Enemy");
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            GameObject enemy = Instantiate(enemyPrefab, spawnPoints[spawnPointIndex].transform.position, Quaternion.identity);
            //if you want to use it need to change "Enemy" to class, more complicated
            //enemy.GetComponent<Enemy>().Die += OnEnemyDeath;
            enemiesAlive++;
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void OnEnemyDeath()
    {
        enemiesAlive--;
        if (enemiesAlive <= 0)
        {
            StartCoroutine(StartNextWave());
        }
    }

    private IEnumerator StartNextWave()
    {
        waveNumber++;
        enemiesPerWave += 2;
        yield return new WaitForSeconds(3.0f);
        StartCoroutine(GenerateWave());
    }

    public WaveSystem getWaveSystem(){
        return this;
    }
}