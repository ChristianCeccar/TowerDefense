using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void MainMenuButton()
    {
        Debug.Log("Main Menu button pressed");
        SceneManager.LoadScene("MainMenu");
    }

    public void LevelSelectButton()
    {
        Debug.Log("Main Menu button pressed");
        SceneManager.LoadScene("Level Select");
    }

    public void ExitGameButton()
    {
        Debug.Log("Exit button pressed");
        Application.Quit();
    }
}
