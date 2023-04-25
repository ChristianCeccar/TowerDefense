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
    public int enemiesToSpawn = 30;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void SpawnEnemy(int enemiesToSpawn)
    {
        if (enemiesToSpawn > 0)
        {
            currentEnemy = Instantiate(enemyPrefab, startPosition.position, Quaternion.identity, transform);
        }
    }
}
