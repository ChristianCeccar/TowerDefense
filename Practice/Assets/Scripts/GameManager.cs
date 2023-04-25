using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int playerHealth;

    public int gold;

    public UIController uiController;
    public WaveManager enemySpawner;

    private static GameManager _instance;

    public int enemiesKilled;

    public bool gamePaused = false;

    public GameObject pauseMenu;

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
        ResumeGame();

        uiController.SetText("Current Health:", playerHealth);
        uiController.SetGoldText("Current Gold:", gold);

        if(gamePaused == true)
        {
            gamePaused = false;
        }
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if(gamePaused == false)
            {
                gamePaused = !gamePaused;
                pauseMenu.SetActive(gamePaused);
                PauseGame();
            }
            else
            {
                gamePaused = !gamePaused;
                pauseMenu.SetActive(gamePaused);
                ResumeGame();
            }
        }
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

    void PauseGame()
    {
        Time.timeScale = 0;

    }

    void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void EnemyKilled(int moneyIncrease)
    {
        enemiesKilled++;
        enemySpawner.spawnedEnemies.RemoveAt(0);
        gold += moneyIncrease;
        uiController.SetGoldText("Current Gold:", gold);
        //Debug.Log("Current gold:" + " " + gold);
    }
}
