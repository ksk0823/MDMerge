using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    public void UpdateNowSeleted()
    {
        transform.parent.parent.parent.Find("SellButton").GetComponent<SellJustOneButton>().nowSelected = transform.gameObject;
    }
    public void ShowItemInfo()
    {
        bool maxLv = false;
        string msg = null;
        msg += material.name + ". ";
        if (material.categoryID == 0 && material.id == 4)
            maxLv = true;
        else if (material.categoryID == 1 && material.id == 5)
            maxLv = true;
        else if (material.categoryID == 2 && material.id == 3)
            maxLv = true;
        else if (material.categoryID == 3 && material.id == 3)
            maxLv = true;
        else if (material.categoryID == 4 && material.id == 5)
            maxLv = true;
        else if (material.categoryID == 5 && material.id == 5)
            maxLv = true;
        else if (material.categoryID == 6 && material.id == 5)
            maxLv = true;
        else if (material.categoryID == 7 && material.id == 4)
            maxLv = true;
        else if (material.categoryID == 8 && material.id == 6)
            maxLv = true;
        else if (material.categoryID == 9 && material.id == 2)
            maxLv = true;
        else if (material.categoryID == 10 && material.id == 2)
            maxLv = true;
        else if (material.categoryID == 11 && material.id == 3)
            maxLv = true;

        if (maxLv)
            msg += "이 아이템은 최대레벨입니다.";
        else
        {
            msg += "합쳐서 다음 아이템을 만들어보세요.";
        }
        transform.parent.parent.parent.Find("InfoText").GetComponent<TMP_Text>().text = msg;
    }
}
