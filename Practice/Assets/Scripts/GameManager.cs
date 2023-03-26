using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int playerHealth;

    public int gold;

    public UIController uiController;

    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        uiController.SetText("Current Health:", playerHealth);
        uiController.SetGoldText("Current Gold:", gold);
    }

    public void TakeDamage(int damage)
    {
        playerHealth -= damage;

        uiController.SetText("Current Health:", playerHealth);

        if (playerHealth <= 0) 
        {
            Debug.Log("GameOver");
        }
    }

    public void EnemyKilled(int moneyIncrease)
    {
        gold += moneyIncrease;
        uiController.SetGoldText("Current Gold:", gold);
        Debug.Log("Current gold:" + " " + gold);
    }
}
