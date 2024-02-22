using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnergyUI : MonoBehaviour
{
    // private PlayerData playerData;

    public TextMeshProUGUI energyText;
    // Start is called before the first frame update
    void Start()
    {
        PlayerData.instance.test_EMJ();
        energyText = GetComponent<TextMeshProUGUI>();
        SetEnergyText();
    }
    private void SetEnergyText()
    {
        energyText.text = PlayerData.instance.energy.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        SetEnergyText();
    }
}
