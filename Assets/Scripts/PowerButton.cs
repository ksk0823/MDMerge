using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerButton : MonoBehaviour
{
    public GameObject PowerPanel;
    public GameObject WaitPanel;
    public GameObject QuitPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void viewPowerMenu()
    {
        PowerPanel.SetActive(true);
    }

    public void saveButton()
    {
        WaitPanel.SetActive(true);
    }

    public void quitButton()
    {
        QuitPanel.SetActive(true);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void quitPowerMenu()
    {
        PowerPanel.SetActive(false);
    }
}
