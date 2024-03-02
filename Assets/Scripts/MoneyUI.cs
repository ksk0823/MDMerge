using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    public TMP_Text moneyText;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerData.instance.isFirstPlay)
        {
            PlayerData.instance.test_EMJ();
            PlayerData.instance.isFirstPlay = false;
        }
        
        SetMoneyText();
    }
    private void SetMoneyText()
    {
        moneyText.SetText(PlayerData.instance.money.ToString());
    }
    // Update is called once per frame
    void Update()
    {
        SetMoneyText();
    }
}
