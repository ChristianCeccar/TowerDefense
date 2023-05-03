using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class UISelector : MonoBehaviour
{
    public GameObject turretPrefab;
    public GameObject secondturretPrefab;
    GameObject currentTurret;
    int counter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currentTurret != null)
        {
            if (GameManager.Instance.uiController.isBought == true)
            {
                if (currentTurret.GetComponent<BaseTurret>().isSelected)
                {
                    Vector3 mousePos = Input.mousePosition;
                    currentTurret.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 8.8f));
                }
            }
        }
    }

    public void OnBaseTurretClicked()
    {
        BaseTurretIcons(Globals.baseTurretPrice, turretPrefab);
    }

    public void OnSecondTurretClicked()
    {
        BaseTurretIcons(Globals.secondTurretPrice, secondturretPrefab);
    }

    private void BaseTurretIcons(int turretPrice, GameObject turret)
    {
        if (GameManager.Instance.gamePaused == false)
        {
            if (GameManager.Instance.gold >= turretPrice)
            {
                counter++;
                GameManager.Instance.gold -= turretPrice;
                GameManager.Instance.uiController.SetGoldText("Current Gold:", GameManager.Instance.gold);
                Debug.Log("Turret Pressed");
                currentTurret = Instantiate(turret, Input.mousePosition, Quaternion.identity);
                var currentTurretBase = currentTurret.GetComponent<BaseTurret>();
                currentTurretBase.transform.name = "Turret " + counter.ToString();
                currentTurretBase.isSelected = true;
                currentTurretBase.GetComponentInChildren<SphereCollider>().radius = currentTurretBase.radius * 1.6f;
                currentTurretBase.DrawCircle(currentTurret, currentTurretBase.radius, 0.1f);
                currentTurretBase.DisableRange(currentTurret);
                GameManager.Instance.uiController.SetCurrentTurretStatsUI(currentTurretBase.damage, currentTurretBase.radius, currentTurretBase.fireRate, true, true);
            }
            else
            {
                Debug.Log("you do not have enough money to buy this turret");
            }
        }
        else
        {
            Debug.Log("you cannot buy turrets while the game is paused");
        }
    }
}
