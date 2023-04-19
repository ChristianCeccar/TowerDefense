using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI playerHealthText;
    public TextMeshProUGUI playerGoldText;

    public TextMeshProUGUI damageText;
    public TextMeshProUGUI rangeText;
    public TextMeshProUGUI attackspeedText;
    public GameObject statsPanel;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetText(string text, int health)
    {
        playerHealthText.text = text + " " + health;
    }

    public void SetGoldText(string text, int health)
    {
        playerGoldText.text = text + " " + health;
    }

    public void SetCurrentTurretStatsUI(int damage, float range, float fireRate, bool selected)
    {
        statsPanel.SetActive(selected);
        attackspeedText.text = "Turret fire rate: " + fireRate.ToString();
        rangeText.text = "Turret range: " + range.ToString();
        damageText.text = "Turret damage: " + damage.ToString();
    }
}
