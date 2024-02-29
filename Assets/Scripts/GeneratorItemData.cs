using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorItemData : MonoBehaviour
{
    public int id;
    public bool available = false; // �ر� ���� (��� ���� ����)
    public List<MaterialItemData> materialsData = new List<MaterialItemData>();
    public int canUseLevel;
    public int unlockMoney;
    public int unlockJewel;
    public bool isClickable;  //�뱤�� & ���ڱ����� �ƴ���

    // Ȯ��
    public float[] prob;
}
