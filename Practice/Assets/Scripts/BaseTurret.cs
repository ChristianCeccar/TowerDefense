using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTurret : MonoBehaviour
{
    public GameObject turretBall;
    public bool isSelected = false;
    public float rotateSpeed;
    private float fireCountdown;
    public int damage;
    public float fireRate;
    public GameObject projectile;
    public Transform firePoint;
    private Transform currentTagret;

    private void Update()
    {
        if (fireCountdown <= 0f)
        {
            Fire();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    public void RotateTowardsEnemy(Transform target)
    {
        if (target != null)
        {
            currentTagret = target;

            Vector3 targetDirection = target.position - turretBall.transform.position;

            // The step size is equal to speed times frame time.
            float singleStep = rotateSpeed * Time.fixedDeltaTime;

            // Rotate the forward vector towards the target direction by one step
            Vector3 newDirection = Vector3.RotateTowards(turretBall.transform.forward, targetDirection, singleStep, 0.0f);

            // Calculate a rotation a step closer to the target and applies rotation to this object
            turretBall.transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }

    public void Fire()
    {
        if (currentTagret != null)
        {
            GameObject pro = Instantiate(projectile, firePoint.position, Quaternion.identity);
            Projectile ball = pro.GetComponent<Projectile>();
            ball.damage = damage;

            if (ball != null)
            {
                ball.Seek(currentTagret);
            }
        }
    }

    public void PlacementCheck(Collider other)
    {
        if (other.transform.CompareTag("Ground") && Input.GetMouseButton(0))
        {
            //placed on ground
            isSelected = false;
            Debug.Log("Can be placed");
        }
    }
}
