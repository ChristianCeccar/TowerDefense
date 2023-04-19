using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject optionsMenu;
    private bool isOptionsMenuEnabled = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlayButtonPress()
    {
        SceneManager.LoadScene("Level Select");
    }

    public void OptionsButtonPress()
    {
        Debug.Log("Options button Pressed");
        isOptionsMenuEnabled = !isOptionsMenuEnabled;
        optionsMenu.SetActive(isOptionsMenuEnabled);
    }

    public void QuitButtonPress()
    {
        Debug.Log("Exit button pressed");
        Application.Quit();
    }

    public void BackbuttonPress()
    {
        isOptionsMenuEnabled = !isOptionsMenuEnabled;
        optionsMenu.SetActive(isOptionsMenuEnabled);
    }
}
