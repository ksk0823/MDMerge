using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorItemData : MonoBehaviour
{
    public int id;
    public bool available = false; // 해금 여부 (사용 가능 여부)
    public List<MaterialItemData> materialsData = new List<MaterialItemData>();
    public int canUseLevel;
    public int unlockMoney;
    public int unlockJewel;
    public bool isClickable;  //용광로 & 도자기인지 아닌지

    // 확률
    public float[] prob;
}
