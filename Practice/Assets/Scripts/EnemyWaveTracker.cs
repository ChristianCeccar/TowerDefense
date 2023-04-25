using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveTracker : MonoBehaviour
{
    // put this on your enemy prefabs. You could just copy the on destroy onto a pre-existing script if you want.
    void OnDestroy()
    {
        if (GameObject.FindGameObjectWithTag("WaveManager") != null)
        {
            GameObject.FindGameObjectWithTag("WaveManager").GetComponent<WaveManager>().spawnedEnemies.Remove(gameObject);
        }

    }
}