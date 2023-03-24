using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : BaseTurret
{
    private EnemySpawner enemies;

    // Start is called before the first frame update
    void Start()
    {
        enemies = FindObjectOfType<EnemySpawner>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (enemies.targets != null)
        {
            if (enemies.targets.Count > 0)
            {
                RotateTowardsEnemy(enemies.targets[0].transform);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        PlacementCheck(other);
    }
}
