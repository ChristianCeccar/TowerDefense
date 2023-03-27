using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private Transform startPosition;
    [SerializeField]
    private GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 2f, 2f);
    }

    private void SpawnEnemy()
    {
        Instantiate(enemy, startPosition.position, Quaternion.identity, transform);
    }
}
