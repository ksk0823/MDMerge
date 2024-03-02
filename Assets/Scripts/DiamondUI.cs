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
        if (PlayerData.instance.isFirstPlay)
        {
            PlayerData.instance.test_EMJ();
            PlayerData.instance.isFirstPlay = false;
        }
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
