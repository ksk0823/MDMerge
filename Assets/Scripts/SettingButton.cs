using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SettingButton : MonoBehaviour
{
    public GameObject SettingPanel;
    public GameObject waitUpdatePanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void viewSettingMenu() {
        SettingPanel.SetActive(true);
    }

    public void soundButton() {
        waitUpdatePanel.SetActive(true);
    }

    public void quitSoundButton()
    {
        waitUpdatePanel.SetActive(false);
    }

    public void quitSettingMenu() {
        SettingPanel.SetActive(false);
    }
}
