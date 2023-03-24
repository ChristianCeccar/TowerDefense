using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public int damage;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null) 
        { 
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distancePerFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distancePerFrame )
        {
            Debug.Log("HIT enemy " + target.name);
            target.GetComponent<EnemyController>().TakeDamage(damage);
            Destroy(gameObject);
        }

        transform.Translate(dir.normalized * distancePerFrame, Space.World);
    }
}
