using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private Transform startPosition;
    [SerializeField]
    private GameObject enemyPrefab;

    GameObject currentEnemy;

    private int currentWave = 1;
    public int enemiesToSpawn = 30;
    private int currentEnemiesSpawned = 0;
    private int enemyHealthModifier = 2;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (currentEnemiesSpawned <= enemiesToSpawn)
        {
            currentEnemiesSpawned++;
            currentEnemy = Instantiate(enemyPrefab, startPosition.position, Quaternion.identity, transform);
            yield return new WaitForSeconds(2f);
        }
        //if(currentEnemiesSpawned >= enemiesToSpawn)
        //{
        //    StopCoroutine(SpawnEnemy());
        //}
    }

    public void UpdateWaveIndex()
    {
        if(GameManager.Instance.enemiesKilled == enemiesToSpawn)
        {
            currentWave++;
            enemiesToSpawn = 0;
            currentEnemiesSpawned = 0;
            GameManager.Instance.enemiesKilled = 0;
            var enemy = currentEnemy.GetComponent<EnemyController>();
            enemy.health *= enemyHealthModifier;
            Debug.Log("Wave Over current wave " + currentWave);
            StartCoroutine(SpawnEnemy());
        }
    }
}
