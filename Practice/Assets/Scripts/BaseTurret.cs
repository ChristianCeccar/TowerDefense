using System.Collections.Generic;
using TMPro;
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
    public Material lineMat;
    public float radius;
    public LayerMask ignoredLayers;
    private GameObject selectedTurret;
    List<GameObject> currentCollisions = new List<GameObject>();

    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DisableAll();
        }

        if (Input.GetKeyDown(KeyCode.Delete))
        {
            SellTurret();
        }

        if (isSelected == false)
        {
            SelectedTurret();

            if (fireCountdown <= 0f)
            {
                Fire();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }
    }

    public void FindTargetsWithRange(Transform target)
    {
        currentTagret = target;
    }

    public void DrawCircle(GameObject container, float radius, float lineWidth)
    {
        var segments = 360;
        var line = container.AddComponent<LineRenderer>();
        line.useWorldSpace = false;
        line.startWidth = lineWidth;
        line.endWidth = lineWidth;
        line.positionCount = segments + 1;
        line.material = lineMat;

        var pointCount = segments + 1; // add extra point to make startpoint and endpoint the same to close the circle
        var points = new Vector3[pointCount];

        for (int i = 0; i < pointCount; i++)
        {
            var rad = Mathf.Deg2Rad * (i * 360f / segments);
            points[i] = new Vector3(Mathf.Sin(rad) * radius, 0, Mathf.Cos(rad) * radius);
        }

        line.SetPositions(points);
    }

    public void DisableRange(GameObject objectToIgnore)
    {
        var allTurrets = FindObjectsOfType<TurretController>();

        foreach (var turret in allTurrets)
        {
            if (turret.transform != objectToIgnore.transform)
            {
                var line = turret.GetComponent<LineRenderer>();
                line.enabled = false;
            }
        }
    }

    public void DisableAll()
    {
        var allTurrets = FindObjectsOfType<TurretController>();

        foreach (var turret in allTurrets)
        {
            var line = turret.GetComponent<LineRenderer>();
            line.enabled = false;
        }

        GameManager.Instance.uiController.statsPanel.SetActive(false);
    }

    public void SelectedTurret()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 100f, ~ignoredLayers))
            {
                if (raycastHit.transform == gameObject.transform)
                {
                    selectedTurret = raycastHit.transform.gameObject;

                    DisableRange(selectedTurret);
                    var turret = selectedTurret.GetComponent<TurretController>();

                    Debug.Log("Damage " + turret.damage + " range " + turret.radius + " attack speed " + turret.fireRate);

                    Debug.Log(raycastHit.transform);
                    //Our custom method. 
                    var line = raycastHit.transform.GetComponent<LineRenderer>();

                    line.enabled = !line.enabled;

                    GameManager.Instance.uiController.SetCurrentTurretStatsUI(damage, radius, fireRate, line.enabled, false);
                }
            }
        }
    }

    public void RotateTowardsEnemy()
    {
        if (currentTagret != null)
        {
            Vector3 targetDirection = currentTagret.position - turretBall.transform.position;

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

    public void SellTurret()
    {
        if (selectedTurret != null)
        {
            Debug.Log("Selected turret " + selectedTurret);
            //Destroy(selectedTurret);
        }
    }

    public void PlacementCheck(Collider other)
    {
        if (other.transform.CompareTag("Map") && Input.GetMouseButton(0))
        {
            //placed on ground
            isSelected = false;
            GameManager.Instance.uiController.isBought = false;
            //GameManager.Instance.uiController.statsPanel.gameObject.SetActive(false);
            //GameManager.Instance.uiController.buyButton.SetActive(false);
            Debug.Log("Can be placed");
        }
    }
}
