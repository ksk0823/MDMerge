using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerButton : MonoBehaviour
{
    public GameObject PowerPanel;
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

    }

    public void quitButton()
    {

    }

    public void quitPowerMenu()
    {
        PowerPanel.SetActive(false);
    }
}
