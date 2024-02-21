using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnergyUI : MonoBehaviour
{
    public TMP_Text energyText;
    // Start is called before the first frame update
    void Start()
    {
        PlayerData.instance.test_EMJ();
        SetEnergyText();
    }
    private void SetEnergyText()
    {
        energyText.SetText(PlayerData.instance.energy.ToString());
    }
    // Update is called once per frame
    void Update()
    {
        SetEnergyText();
    }
}
