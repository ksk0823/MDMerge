using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUI : MonoBehaviour
{
    public TMP_Text levelText;
    public GameObject PlayerPanel;
    public TMP_Text playerText;
    // Start is called before the first frame update
    void Start()
    {
        PlayerData.instance.test_EMJ();
        SetLevelText();
    }
    private void SetLevelText()
    {
        levelText.SetText(PlayerData.instance.level.ToString());
    }
    // Update is called once per frame
    void Update()
    {
        SetLevelText();
    }
    public void viewPlayerPanel()
    {
        PlayerPanel.SetActive(true);
        setPlayerText();
    }

    public void quitPlayerPanel()
    {
        PlayerPanel.SetActive(false);
    }

    public void setPlayerText()
    {
        int tempExp = PlayerData.instance.exp;
        int templevel = PlayerData.instance.level;
        int tempFullExp = templevel * 100;
        int tempPercent = (int)(((double)tempExp / (double)tempFullExp) * 100.00);
        playerText.SetText("Level: " +PlayerData.instance.level.ToString()
            + "\nExp: " + tempExp.ToString() + "/" + tempFullExp +" (" + tempPercent +"%)"
            + "\nPlayer Name: " + PlayerData.instance.playerName
            +"\nGroup Name: " + PlayerData.instance.groupName);

    }
}
