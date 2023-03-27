using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeTargetFinder : MonoBehaviour
{
    private BaseTurret turret;

    // Start is called before the first frame update
    void Start()
    {
        turret = GetComponentInParent<BaseTurret>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            turret.FindTargetsWithRange(other.transform);
        }
    }
}
