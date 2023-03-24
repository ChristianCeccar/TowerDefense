using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public List<Transform> target;
    public float speed;
    private int current;
    private EnemySpawner enemies;

    void Start() 
    { 
        enemies = FindObjectOfType<EnemySpawner>();

        target = new List<Transform>();

        foreach (var wayPoint in FindObjectsOfType<EndPoint>())
        {
            target.Add(wayPoint.transform);
        }
    }

    void FixedUpdate()
    {
        if (transform.position != target[current].position)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.fixedDeltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);
        }
        else current = (current + 1) % target.Count;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EndPoint"))
        {
            Destroy(gameObject);
            enemies.targets.RemoveAt(0);
        }
    }
}
