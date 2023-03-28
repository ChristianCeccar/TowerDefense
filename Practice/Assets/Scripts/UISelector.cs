using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class UISelector : MonoBehaviour
{
    public GameObject turretPrefab;
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
        if (GameManager.Instance.gold >= Globals.baseTurretPrice)
        {
            GameManager.Instance.gold -= Globals.baseTurretPrice;
            GameManager.Instance.uiController.SetGoldText("Current Gold:", GameManager.Instance.gold);
            Debug.Log("Turret Pressed");
            currentTurret = Instantiate(turretPrefab, Input.mousePosition, Quaternion.identity);
            var currentTurretBase = currentTurret.GetComponent<BaseTurret>();
            currentTurretBase.isSelected = true;
            currentTurretBase.GetComponentInChildren<SphereCollider>().radius = currentTurretBase.radius * 1.6f;
            currentTurretBase.DrawCircle(currentTurret, currentTurretBase.radius, 0.1f);
        }
        else
        {
            Debug.Log("you do not have enough money to buy this turret");
        }
    }
}
