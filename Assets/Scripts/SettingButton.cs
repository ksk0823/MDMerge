using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SettingButton : MonoBehaviour
{
    public GameObject SettingPanel;

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

    }

    public void quitSettingMenu() {
        SettingPanel.SetActive(false);
    }
}
