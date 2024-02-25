using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialCtrl : MonoBehaviour
{

    Image imageCtrl;
    public MaterialItemData material;

    public void InitMaterial(MaterialItemData m, Transform newParent)
    {
        material = m;
        imageCtrl = GetComponent<Image>();
        imageCtrl.sprite = material.itemImg;
        transform.SetParent(newParent);
    }

}
