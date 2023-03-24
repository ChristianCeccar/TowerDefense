using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class UISelector : MonoBehaviour
{
    public GameObject turretPrefab;
    private bool isSelected = false;
    GameObject currentTurret;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currentTurret != null)
        {
            if (currentTurret.GetComponent<BaseTurret>().isSelected)
            {
                Vector3 mousePos = Input.mousePosition;
                currentTurret.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 8.8f));
            }
        }
    }

    public void OnTurretClicked()
    {
        Debug.Log("Turret Pressed");
        currentTurret = Instantiate(turretPrefab, Input.mousePosition, Quaternion.identity);
        currentTurret.GetComponent<BaseTurret>().isSelected = true;
    }
}
