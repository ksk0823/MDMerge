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
        // �Էµ� �÷��̾� �̸��� �� �̸� ��������
        playerName = playerNameInput.text.Trim();
        groupName = groupNameInput.text.Trim();

        // �Էµ� �÷��̾� �̸��� �� �̸��� ��ȿ�� �˻�
        if (IsValidPlayerInput(playerName) && IsValidGroupInput(groupName))
        {
            // ���� ���� �� ���� �ܰ�� �Ѿ�� �۾� ����
            Debug.Log("�÷��̾� �̸�: " + playerName);
            Debug.Log("�� �̸�: " + groupName);

            // ���� �ܰ�� �Ѿ�� �ڵ带 ���⿡ �߰�
            PlayerData.instance.playerName = playerName;
            PlayerData.instance.groupName = groupName;
            FirstPlayDialog.Instance.viewdialogPanel();
            quitPanel();
        }
        else
        {
            viewWarnigPanel();
            Debug.Log("�÷��̾� �̸��� �� �̸��� 1���� �̻�, 5���� �̳��̾�� �մϴ�.");
        }
    }

    // �Էµ� ���ڿ��� ��ȿ���� �˻��ϴ� �޼���
    private bool IsValidPlayerInput(string input)
    {
        // �����̰ų� �Է� ���̰� 5�ڸ� �ʰ����� �ʴ��� �˻�
        return !string.IsNullOrWhiteSpace(input) && input.Length <= 5 && IsHangul(input);
    }

    private bool IsValidGroupInput(string input)
    {
        // �����̰ų� �Է� ���̰� 5�ڸ� �ʰ����� �ʴ��� �˻�
        return !string.IsNullOrWhiteSpace(input) && input.Length <= 10 && IsHangul(input);
    }

    // �ѱ� ���θ� Ȯ���ϴ� �޼���
    private bool IsHangul(string input)
    {
        foreach (char c in input)
        {
            // �ѱ� �����ڵ� ����: ��(0xAC00) ~ �R(0xD7A3)
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
