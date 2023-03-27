using UnityEngine;

public class TurretController : BaseTurret
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RotateTowardsEnemy();
    }

    private void OnTriggerStay(Collider other)
    {
        PlacementCheck(other);
    }
}
