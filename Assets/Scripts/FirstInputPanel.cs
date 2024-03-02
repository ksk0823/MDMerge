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
        // 입력된 플레이어 이름과 팀 이름 가져오기
        playerName = playerNameInput.text.Trim();
        groupName = groupNameInput.text.Trim();

        // 입력된 플레이어 이름과 팀 이름의 유효성 검사
        if (IsValidPlayerInput(playerName) && IsValidGroupInput(groupName))
        {
            // 조건 충족 시 다음 단계로 넘어가는 작업 수행
            Debug.Log("플레이어 이름: " + playerName);
            Debug.Log("팀 이름: " + groupName);

            // 다음 단계로 넘어가는 코드를 여기에 추가
            PlayerData.instance.playerName = playerName;
            PlayerData.instance.groupName = groupName;
            FirstPlayDialog.Instance.viewdialogPanel();
            quitPanel();
        }
        else
        {
            viewWarnigPanel();
            Debug.Log("플레이어 이름과 팀 이름은 1글자 이상, 5글자 이내이어야 합니다.");
        }
    }

    // 입력된 문자열이 유효한지 검사하는 메서드
    private bool IsValidPlayerInput(string input)
    {
        // 공백이거나 입력 길이가 5자를 초과하지 않는지 검사
        return !string.IsNullOrWhiteSpace(input) && input.Length <= 5 && IsHangul(input);
    }

    private bool IsValidGroupInput(string input)
    {
        // 공백이거나 입력 길이가 5자를 초과하지 않는지 검사
        return !string.IsNullOrWhiteSpace(input) && input.Length <= 10 && IsHangul(input);
    }

    // 한글 여부를 확인하는 메서드
    private bool IsHangul(string input)
    {
        foreach (char c in input)
        {
            // 한글 유니코드 범위: 가(0xAC00) ~ 힣(0xD7A3)
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
