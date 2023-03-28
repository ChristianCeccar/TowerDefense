using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlayButtonPress()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void OptionsButtonPress()
    {
        Debug.Log("Options button Pressed");
    }

    public void QuitButtonPress()
    {
        Debug.Log("Quit button Pressed");
    }
}
