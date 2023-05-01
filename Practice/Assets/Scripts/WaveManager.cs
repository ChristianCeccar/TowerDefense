using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public UIController uiController;
    public List<Enemy> enemies = new List<Enemy>();
    public int currWave;
    private int waveValue;
    public List<GameObject> enemiesToSpawn = new List<GameObject>();

    public Transform[] spawnLocation;
    public int spawnIndex;

    public int waveDuration;
    private float waveTimer;
    private float spawnInterval;
    private float spawnTimer;

    public List<GameObject> spawnedEnemies = new List<GameObject>();

    public float timer = 5f;
    public int seconds;

    // Start is called before the first frame update
    void Start()
    {
        //GenerateWave();
        uiController.SetWave("Current Wave ", currWave);
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        // turn seconds in float to int
        seconds = (int)(timer % 60);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        WaveSetup();
    }

    public void WaveSetup()
    {
        if (seconds <= 0)
        {
            uiController.timeBetweenWavesText.gameObject.SetActive(false);

            if (spawnTimer <= 0)
            {
                //spawn an enemy
                if (enemiesToSpawn.Count > 0)
                {
                    GameObject enemy = (GameObject)Instantiate(enemiesToSpawn[0], spawnLocation[spawnIndex].position, Quaternion.identity); // spawn first enemy in our list
                    enemiesToSpawn.RemoveAt(0); // and remove it
                    spawnedEnemies.Add(enemy);
                    spawnTimer = spawnInterval;

                    if (spawnIndex + 1 <= spawnLocation.Length - 1)
                    {
                        spawnIndex++;
                    }
                    else
                    {
                        spawnIndex = 0;
                    }
                }
                else
                {
                    waveTimer = 0; // if no enemies remain, end wave
                }
            }
            else
            {
                spawnTimer -= Time.fixedDeltaTime;
                waveTimer -= Time.fixedDeltaTime;
            }

            if (waveTimer <= 0 && spawnedEnemies.Count <= 0)
            {
                currWave++;
                timer = 5;
                uiController.SetWave("Current Wave ", currWave);
                GenerateWave();
            }
        }
        else
        {
            uiController.timeBetweenWavesText.gameObject.SetActive(true);
            uiController.SetTimeWaveText("Wave Starts in: ", seconds);
        }
    }

    public void GenerateWave()
    {
        waveValue = currWave * 10;
        GenerateEnemies();
      
        if (enemiesToSpawn.Count > 0)
        {
            if(waveDuration/enemiesToSpawn.Count >= 0.5f)
            {
                spawnInterval = waveDuration / enemiesToSpawn.Count; // interval between spawns. t/enemies
            }
            else
            {
                spawnInterval = 0.5f; // default to 0.25f 
            }
        }
        waveTimer = waveDuration; // wave duration is read only
    }

    public void GenerateEnemies()
    {
        // Create a temporary list of enemies to generate
        // 
        // in a loop grab a random enemy 
        // see if we can afford it
        // if we can, add it to our list, and deduct the cost.

        // repeat... 

        //  -> if we have no points left, leave the loop

        List<GameObject> generatedEnemies = new List<GameObject>();
        while (waveValue > 0 || generatedEnemies.Count < 50)
        {
            int randEnemyId = Random.Range(0, enemies.Count);
            int randEnemyCost = enemies[randEnemyId].cost;
            
            if (waveValue - randEnemyCost >= 0)
            {
                generatedEnemies.Add(enemies[randEnemyId].enemyPrefab);
                waveValue -= randEnemyCost;
            }
            else if (waveValue <= 0)
            {
                break;
            }
        }
        enemiesToSpawn.Clear();
        enemiesToSpawn = generatedEnemies;
    }

}

[System.Serializable]
public class Enemy
{
    public GameObject enemyPrefab;
    public int cost;
}