using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonsUI : MonoBehaviour
{
    public GameObject waitPanel;
    public void newGameButton()
    {
        SceneManager.LoadScene("MapMode", LoadSceneMode.Single);
    }
    public void loadGameButton()
    {
        waitPanel.SetActive(true);
    }
    public void settingsButton()
    {
        waitPanel.SetActive(true);
    }
    public void quitButton()
    {
        Application.Quit();
    }
}
