using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockButton : MonoBehaviour
{
    public GameObject LockPanel;
    public GameObject LockBtn;

    private bool isUnlocked = false; //해금여부

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void viewLockInfo()
    {
        LockPanel.SetActive(true);
    }
    public void quitLockInfo()
    {
        LockPanel.SetActive(false);
    }
}
