using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiamondUI : MonoBehaviour
{
    public TMP_Text diamondText;
    // Start is called before the first frame update
    void Start()
    {
        PlayerData.instance.test_EMJ();
        SetDiamondText();
    }
    private void SetDiamondText()
    {
        diamondText.SetText(PlayerData.instance.jewel.ToString());
    }
    // Update is called once per frame
    void Update()
    {
        SetDiamondText();
    }
}
