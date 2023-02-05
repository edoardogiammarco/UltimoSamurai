using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public Vector3 spawnPosition;
    public float minSpawnTime = 30f;
    public float maxSpawnTime = 60f;
    private GameObject player;
    private Player playerScript;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerScript = player.GetComponent<Player>();
        StartCoroutine(SpawnCoin());
    }

    private IEnumerator SpawnCoin()
    {
        while (playerScript.isPlayerAlive == true)
        {
            float randomTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(randomTime);

            Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
        }
    }
}