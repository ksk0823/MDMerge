using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FirstPlayDialog : MonoBehaviour
{
    
    public class dialogObject
    {
        public string dname;
        public string dialog;
        public int imgID;

        public dialogObject(string name, string dialog, int imgID)
        {
            this.dname = name;
            this.dialog = dialog;
            this.imgID = imgID;
        }
    }
    public GameObject canvas;
    public static FirstPlayDialog Instance;
    public GameObject dialogPanel;
    public GameObject boojang;
    public TMP_Text dname;
    public TMP_Text dialog;
    public Sprite[] imgs;
    int index = 0;
    dialogObject[] arr;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        dialogPanel.SetActive(false);
    }

    public void viewdialogPanel()
    {
        dialogPanel.SetActive (true);
        inputDialogObjects();
        setDialog();
    }

    void inputDialogObjects()
    {
        string playerName = PlayerData.instance.playerName;
        string groupName = PlayerData.instance.groupName;

        List<dialogObject> list = new List<dialogObject>();
        list.Add(new dialogObject(playerName, "(������ ���� ù ��� ���̴�.)", 2));
        list.Add(new dialogObject(playerName, "(�󷷶׶� �������θ�Ʈ��� ���� ����ϰ� �ƴ�.)", 2));
        list.Add(new dialogObject(playerName, "(�󷷶׶� �������θ�Ʈ���... �̸����� �ұ�������)", 2));
        list.Add(new dialogObject(playerName, "(�ܿ� ���� ù ������ ��ŭ ������ �ϰ� �ʹ�!)", 2));
        list.Add(new dialogObject(playerName, "(...��� ������ �� 1�ð��� ���� �ʾҴµ�...)", 2));
        list.Add(new dialogObject(playerName, "...��?", 2));
        list.Add(new dialogObject("�����", groupName + "�� �ܼ�Ʈ ��ȹ�̶� ��� �þ��ּ���.", 0));
        list.Add(new dialogObject(playerName, "�����?! �� ���� �Ի��ߴµ���??", 0));
        list.Add(new dialogObject(playerName, "(ȸ��� ��� ù������ ���� ū ��ź�� �������ȴ�.)", 0));
        list.Add(new dialogObject(playerName, "(" + groupName + "�� �󷷶׶� �������θ�Ʈ���� ������ �� ���� 2�⵵ ä ���� ���� ���� ���̵� �׷��̴�.)", 0));
        list.Add(new dialogObject(playerName, "(������ �̸��� �� �˷����� ���� �׷������� �Ƿ��� ������ ������ �˰� �ִ�.)", 0));
        list.Add(new dialogObject(playerName, "(ȫ���� �� �ϸ� �и� ������ ���̶�� �����Ѵ�. �׷��� ȫ���� �ſ� �߿��� ��Ȳ�ε�...)", 0));
        list.Add(new dialogObject(playerName, "(�� �߿��� ���� ������?! �Ի����� �Ϸ�ۿ� �ȵ� ������?!)", 0));
        list.Add(new dialogObject(playerName, "(�� ������ �ϱ��� �ʾƼ� ����Բ� ������ �ǹ�������� ���ƿ��� ���� ���Ҵ�.)", 0));
        list.Add(new dialogObject("�����", "������ " + groupName +"�� �ܼ�Ʈ ��ȹ���� ����� ��� " + playerName + " ����� �ð� �� �̴ϴ�.", 1));
        list.Add(new dialogObject("�����", "�� �� �� �ְ���? ����", 1));
        list.Add(new dialogObject(playerName, "(�� �ؾ���... ����)", 1));
        list.Add(new dialogObject("�����", "�켱 MD �ν����� �� MD ��ǰ����� �������� �����ϰ� �� ������", 0));
        list.Add(new dialogObject("�����", "�� ������ �ܼ�Ʈ ������ �ø��鼭 ������ MD ǰ��鵵 �ø��� �� �̴ϴ�.", 0));
        list.Add(new dialogObject("�����", "������ ������ ������ �������� 1�� �Һ�ǰ�", 0));
        list.Add(new dialogObject("�����", "�Һ��� �������� ȸ�� �� �������� ������ ��ǰ��� ���� ���� �ϴ� �����ϼ���.", 0));
        list.Add(new dialogObject("�����", "�׷��� �ܼ�Ʈ � �������Դϴ�!", 1));
        list.Add(new dialogObject(playerName, "��... ������...!!��", 1));
        arr = list.ToArray();

    }

    public void setDialog() 
    {
        if (index == arr.Length)
        {
            PlayerData.instance.isFirstPlay = false;
            dialogPanel.SetActive(false);
            Destroy(canvas);
            return;
        }

        dname.SetText(arr[index].dname);
        dialog.SetText(arr[index].dialog);
        if (arr[index].imgID == 2)
        {
            boojang.SetActive(false);
        }
        else 
        {
            boojang.SetActive(true);
            Image img = boojang.GetComponent<Image>();
            img.sprite = imgs[arr[index].imgID];
        }
        index++;
    }
}
