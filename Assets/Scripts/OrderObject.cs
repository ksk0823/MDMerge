using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OrderObject : MonoBehaviour
{
    public GameObject orderObject;
    public TMP_Text priceText;
    public TMP_Text expText;

    public int orderId;
    public int orderItemNum;

    //���� �� orderNum �־ �迭 �ʱ�ȭ
    public MaterialItemData[] orderItems;
    public int orderPrice;
    public float orderExp;
    public int orderJem;

    private void Start()
    {
       
    }
}
