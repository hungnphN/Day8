using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public float spawnRadius = 5f;
    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnInterval); 
    }
    void SpawnEnemy()
    {
        Vector2 randomPos = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;
        Instantiate(enemyPrefab, randomPos, Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
