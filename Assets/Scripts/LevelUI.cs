using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUI : MonoBehaviour
{
    public TMP_Text levelText;
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
}