using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookButton : MonoBehaviour
{
    public GameObject BookPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void viewBookMenu()
    {
        BookPanel.SetActive(true);
    }

    public void quitBookMenu()
    {
        BookPanel.SetActive(false);
    }
}
