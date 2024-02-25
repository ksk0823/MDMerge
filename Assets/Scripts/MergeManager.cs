using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MergeManager : MonoBehaviour
{
    public List<MaterialItemData> materialsData = new List<MaterialItemData>();
    public GameObject materialsPrefabs;

    public void MaterialsCreate(int num)
    {
        GameObject go = Instantiate(materialsPrefabs);
        go.GetComponent<MaterialCtrl>().InitMaterial(materialsData[num]);
    }
}
