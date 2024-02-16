using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonsUI : MonoBehaviour
{
    public void newGameButton()
    {
        SceneManager.LoadScene("MapMode", LoadSceneMode.Single);
    }
    public void loadGameButton()
    {
        SceneManager.LoadScene("MergeMode", LoadSceneMode.Single);
    }
    public void settingsButton()
    {
        
    }
    public void quitButton()
    {
        Application.Quit();
    }
}
