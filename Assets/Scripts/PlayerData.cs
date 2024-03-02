using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private static PlayerData Instance;
    public static PlayerData instance
    {
        set
        {
            if (Instance == null)
                Instance = value;
        }
        get { return Instance; }
    }

    private void Awake()
    {
        if (Instance != this && Instance != null)
        {
            Destroy(this);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void test_EMJ()
    {
        level = 1;
        energy = 0;
        money = 0;
        jewel = 0;
        playerName = "����";
        groupName = "Ŭ���ҳ��";
        exp = 0;
        orderCnt = 0;
    }


    public int energy;
    public int money;
    public int jewel;
    public string playerName;
    public string groupName;
    public int level;
    public int exp;
    public int orderCnt; //���� order����
    public int lockNum;
    public bool isFirstPlay = true; // ù �÷��� ����
    public bool[] generators; //������ �ر� ����
    public bool[] mapUnlocks; // �� �ر� ����
    public List<MaterialItemData> inventory; //�÷��� ���� ���� ����
}
