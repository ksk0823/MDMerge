using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyUI : MonoBehaviour
{
    public TMP_Text moneyText;
    // Start is called before the first frame update
    void Start()
    {
        PlayerData.instance.test_EMJ();
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
