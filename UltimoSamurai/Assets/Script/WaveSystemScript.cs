using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystemScript : MonoBehaviour
{
    public GameObject enemyPrefab;
    private int waveCount = 1;
    private int enemyCountOnMap;
    private int killedEnemies = 0;              //enemies killed in current wave
    private int totalKilledEnemies = 0;
    private int waveEnemies = 1;
    private bool enemiesInMap;

    // Start is called before the first frame update
    private void Start()
    {
        enemiesInMap = false;
        StartCoroutine(BeginWave());
    }

    private void Update()
    {
        areEnemiesInMap();
    }

    private IEnumerator BeginWave()
    {
            yield return new WaitForSeconds(5);

            for (int i=0; i < waveEnemies; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(Random.Range(0.5f, 3f));
            }
            Debug.Log("Wave number " + waveCount + " spawned");
            // Adding more enemies for next wave
            waveEnemies = waveCount*2;
    }

    public void areEnemiesInMap() {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");

        foreach (GameObject enemy in enemies)
        {
            if (enemy.transform.position.x >= 0 && enemy.transform.position.x <= 40 &&
                enemy.transform.position.y >= 0 && enemy.transform.position.y <= 30)
            {
                enemiesInMap = true;
                break;
            }
        }

        if (enemiesInMap)
        {
            //Debug.Log("There are Base_Enemy game objects in the current map.");
        }
        else
        {
           // Debug.Log("There are no Base_Enemy game objects in the current map.");
        }
    }

    public void SpawnEnemy()
    {
        Vector3 spawnPos = new Vector3(Random.Range(0, 40), Random.Range(0, 30), 0);
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        enemyCountOnMap++;
        Debug.Log("Enemy spawned,   enemyCountOnMap="+ enemyCountOnMap);
    }

    public void EnemyKilled()
    {
        
        totalKilledEnemies++;
        killedEnemies++;
        Debug.Log("Enemy killed in wave:"+ killedEnemies + "Total enemy killed:"+ totalKilledEnemies);
        if(enemiesInMap && (killedEnemies == enemyCountOnMap))
        {
            // Reset variables
            Debug.Log("Reset variables");
            enemiesInMap = false;
            killedEnemies = 0;
            enemyCountOnMap = 0;


            // Begin new wave
            waveCount++;
            StartCoroutine(BeginWave());
        }
    }
}
/*
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

public class Wave
{
    public string waveName;
    public int noOfEnemies;
    public GameObject[] typeOfEnemies;
    public float spawnInterval;
}

public class WaveSpawnner : MonoBehaviour

{

    public Wave[] waves;
    public Animator animator;
    public Text waveName;
    private Wave currentWave;
    private int currentWaveNumber;
    private float nextSpawnTime;
    private bool canSpawn = true;
    private bool canAnimate = false;

    

    private void Update()

    {
        currentWave = waves[currentWaveNumber];
        SpawnWave();
        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (totalEnemies.Length == 0  )
        {
            if ( currentWaveNumber + 1 != waves.Length )
            {
                if ( canAnimate )
                {
                    waveName.text = waves[currentWaveNumber + 1].waveName;
                    animator.SetTrigger("WaveComplete");
                    canAnimate = false;
                }
            } else {
                Debug.Log("GameFinish");
            }
        }
    }

    void SpawnNextWave()
    {
        currentWaveNumber++;
        canSpawn = true;
    }

    void SpawnWave()
    {
        if (canSpawn && nextSpawnTime < Time.time)
        {
            GameObject randomEnemy = currentWave.typeOfEnemies[Random.Range(0, currentWave.typeOfEnemies.Length)];
            Vector3 randomPosition = new Vector3(Random.Range(0, 40), 0, Random.Range(0, 30));
            Instantiate(randomEnemy, randomPosition, Quaternion.identity);
            currentWave.noOfEnemies--;
            nextSpawnTime = Time.time + currentWave.spawnInterval;

            if (currentWave.noOfEnemies == 0)
            {
                canSpawn = false;
                canAnimate = true;
            }
        }
    }
}*/