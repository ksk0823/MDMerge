using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorItemData : MonoBehaviour
{
    public int id;
    public bool available=true; //해금여부(사용가능여부)
    public List<MaterialItemData> materialsData = new List<MaterialItemData>();

    // 확률
    public float[] prob;
}
