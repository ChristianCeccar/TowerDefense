using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class EnemyController : MonoBehaviour
{
    public List<Transform> target;
    public float speed;
    private int current;
    [HideInInspector]
    public int health;
    public int startingHealth;
    public int damage;
    public PathCreator path;
    float distanceTravelled;

    void Start() 
    {
        health = startingHealth;

        path = FindObjectOfType<PathCreator>();

        //target = new List<Transform>();

        //foreach (var wayPoint in FindObjectsOfType<EndPoint>())
        //{
        //    target.Add(wayPoint.transform);
        //}
    }

    void Update()
    {
        distanceTravelled += speed * Time.deltaTime;

        transform.position = path.path.GetPointAtDistance(distanceTravelled);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) 
        {
            GameManager.Instance.EnemyKilled(5);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EndPoint"))
        {
            Destroy(gameObject);
            GameManager.Instance.TakeDamage(damage);
        }
    }
}
