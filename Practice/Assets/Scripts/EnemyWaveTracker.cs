using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveTracker : MonoBehaviour
{
    void OnDestroy()
    {
        if (GameObject.FindGameObjectWithTag("WaveManager") != null)
        {
            GameObject.FindGameObjectWithTag("WaveManager").GetComponent<WaveManager>().spawnedEnemies.Remove(gameObject);
        }

    }
}