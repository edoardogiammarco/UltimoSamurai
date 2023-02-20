using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public  GameObject  coinPrefab;
    private GameObject  player;
    public  Vector3     spawnPosition;
    private Player      playerScript;
    public float minSpawnTime = 10f;
    public float maxSpawnTime = 20f;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerScript = player.GetComponent<Player>();
        StartCoroutine(SpawnCoin());
    }

    /* this method spawn a coin on the center of the sanctuary every "random time" seconds*/
    private IEnumerator SpawnCoin()
    {
        while (playerScript.isPlayerAlive == true)
        {
            float randomTime = Random.Range(minSpawnTime, maxSpawnTime); // random time is a float between min and max spawn time
            yield return new WaitForSeconds(randomTime);

            Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
        }
    }
}