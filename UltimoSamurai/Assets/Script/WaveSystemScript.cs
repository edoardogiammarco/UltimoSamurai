using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSystemScript : MonoBehaviour
{
    
    /**** Map Boundaries****/
    public const int mappaMinX = 77;
    public const int mappaMaxX = 186;    
    public const int mappaMinY = 0;
    public const int mappaMaxY = 110;
    
    public GameObject enemyPrefab;
    private Animator animator;
    private int waveCount = 1;
    private int enemyCountOnMap;
    private int killedEnemies = 0;              //enemies killed in current wave
    private int totalKilledEnemies = 0;        
    private int waveEnemies = 1;
    private bool enemiesInMap;


    // Start is called before the first frame update
    private void Start()
    {   
        animator = GetComponent<Animator>();
        enemiesInMap = false;
        Debug.Log("Spawning wave 1");
        StartCoroutine(BeginWave());
    }

    private void Update()
    {
        areEnemiesInMap();
    }

    private IEnumerator BeginWave()
    {
            yield return new WaitForSeconds(5);
            
            // Adding more enemies for next wave
            waveEnemies = waveCount;

            for (int i=0; i < waveEnemies; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(Random.Range(0.5f, 3f));
                Debug.Log("Enemy spawned in wave " + waveCount);
            }
            Debug.Log("Wave number " + waveCount + " finished spawning");
    }

    public void areEnemiesInMap() {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");

        foreach (GameObject enemy in enemies)
        {
            if (enemy.transform.position.x >= mappaMinX && enemy.transform.position.x <= mappaMaxX &&
                enemy.transform.position.y >= mappaMinY && enemy.transform.position.y <= mappaMaxY)
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

    public void SpawnEnemy(){
        Vector3 spawnPos = new Vector3(Random.Range(mappaMinX, mappaMaxX), Random.Range(mappaMinY, mappaMaxY), 0);
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        enemyCountOnMap++;
        Debug.Log("Enemy spawned, enemyCountOnMap="+ enemyCountOnMap);
    }

    public void EnemyKilled(){
        totalKilledEnemies++;
        killedEnemies++;
        Debug.Log("Wave enemies killed:"+ killedEnemies + "/" + waveEnemies + "\n" + 
                  "Total enemy killed:"+ totalKilledEnemies);
        if(enemiesInMap && (killedEnemies == enemyCountOnMap))
        {
            animator.SetTrigger("WaveComplete");
            // Reset variables
            Debug.Log("Reset variables");
            enemiesInMap = false;
            killedEnemies = 0;
            enemyCountOnMap = 0;


            // Begin new wave
            waveCount++;
            Debug.Log("Spawning wave number " + waveCount);
            StartCoroutine(BeginWave());
        }
    }

}
