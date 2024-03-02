using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FirstInputPanel : MonoBehaviour
{
    public TMP_InputField playerNameInput;
    public TMP_InputField groupNameInput;
    public GameObject inputPanel;
    public GameObject warnigPanel;
    private string playerName = null;
    private string groupName = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InputNames()
    {
        // ÀÔ·ÂµÈ ÇÃ·¹ÀÌ¾î ÀÌ¸§°ú ÆÀ ÀÌ¸§ °¡Á®¿À±â
        playerName = playerNameInput.text.Trim();
        groupName = groupNameInput.text.Trim();

        // ÀÔ·ÂµÈ ÇÃ·¹ÀÌ¾î ÀÌ¸§°ú ÆÀ ÀÌ¸§ÀÇ À¯È¿¼º °Ë»ç
        if (IsValidPlayerInput(playerName) && IsValidGroupInput(groupName))
        {
            // Á¶°Ç ÃæÁ· ½Ã ´ÙÀ½ ´Ü°è·Î ³Ñ¾î°¡´Â ÀÛ¾÷ ¼öÇà
            Debug.Log("ÇÃ·¹ÀÌ¾î ÀÌ¸§: " + playerName);
            Debug.Log("ÆÀ ÀÌ¸§: " + groupName);

            // ´ÙÀ½ ´Ü°è·Î ³Ñ¾î°¡´Â ÄÚµå¸¦ ¿©±â¿¡ Ãß°¡
            PlayerData.instance.playerName = playerName;
            PlayerData.instance.groupName = groupName;
            FirstPlayDialog.Instance.viewdialogPanel();
            quitPanel();
        }
        else
        {
            viewWarnigPanel();
            Debug.Log("ÇÃ·¹ÀÌ¾î ÀÌ¸§°ú ÆÀ ÀÌ¸§Àº 1±ÛÀÚ ÀÌ»ó, 5±ÛÀÚ ÀÌ³»ÀÌ¾î¾ß ÇÕ´Ï´Ù.");
        }
    }

    // ÀÔ·ÂµÈ ¹®ÀÚ¿­ÀÌ À¯È¿ÇÑÁö °Ë»çÇÏ´Â ¸Ş¼­µå
    private bool IsValidPlayerInput(string input)
    {
        // °ø¹éÀÌ°Å³ª ÀÔ·Â ±æÀÌ°¡ 5ÀÚ¸¦ ÃÊ°úÇÏÁö ¾Ê´ÂÁö °Ë»ç
        return !string.IsNullOrWhiteSpace(input) && input.Length <= 5 && IsHangul(input);
    }

    private bool IsValidGroupInput(string input)
    {
        // °ø¹éÀÌ°Å³ª ÀÔ·Â ±æÀÌ°¡ 5ÀÚ¸¦ ÃÊ°úÇÏÁö ¾Ê´ÂÁö °Ë»ç
        return !string.IsNullOrWhiteSpace(input) && input.Length <= 10 && IsHangul(input);
    }

    // ÇÑ±Û ¿©ºÎ¸¦ È®ÀÎÇÏ´Â ¸Ş¼­µå
    private bool IsHangul(string input)
    {
        foreach (char c in input)
        {
            // ÇÑ±Û À¯´ÏÄÚµå ¹üÀ§: °¡(0xAC00) ~ ÆR(0xD7A3)
            if (c < 0xAC00 || c > 0xD7A3)
            {
                return false;
            }
        }
        return true;
    }

    public void quitPanel()
    {
        inputPanel.SetActive(false);
    }

    public void viewWarnigPanel()
    {
        warnigPanel.SetActive(true);
    }
}
