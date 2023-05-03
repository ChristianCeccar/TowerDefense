using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI playerHealthText;
    public TextMeshProUGUI playerGoldText;
    public TextMeshProUGUI currentWaveText;
    public TextMeshProUGUI timeBetweenWavesText;

    public TextMeshProUGUI damageText;
    public TextMeshProUGUI rangeText;
    public TextMeshProUGUI attackspeedText;
    public GameObject statsPanel;
    public GameObject buyButton;
    public bool isBought = false;

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

    public void SetTimeWaveText(string text, int seconds)
    {
        timeBetweenWavesText.text = text + " " + seconds;
    }

    public void SetGoldText(string text, int health)
    {
        playerGoldText.text = text + " " + health;
    }

    public void SetWave(string text, int wave)
    {
        currentWaveText.text = text + ": " + wave;
    }

    public void SetCurrentTurretStatsUI(int damage, float range, float fireRate, bool selected, bool isBuying)
    {
        statsPanel.SetActive(selected);
        buyButton.SetActive(isBuying);
        attackspeedText.text = "Turret fire rate: " + fireRate.ToString();
        rangeText.text = "Turret range: " + range.ToString();
        damageText.text = "Turret damage: " + damage.ToString();
    }

    public void IsBoughtTurret()
    {
        isBought = !isBought;
    }
}
