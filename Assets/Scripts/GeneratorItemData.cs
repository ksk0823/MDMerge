using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorItemData : MonoBehaviour
{
    public int id;
    public bool available=true; //�رݿ���(��밡�ɿ���)
    public List<MaterialItemData> materialsData = new List<MaterialItemData>();

    // Ȯ��
    public float[] prob;
}
