using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private Transform startPosition;
    [SerializeField]
    private GameObject enemy;

    public List<GameObject> targets = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 4f, 4f);
    }

    private void SpawnEnemy()
    {
        targets.Add(Instantiate(enemy, startPosition.position, Quaternion.identity, transform));
    }
}
