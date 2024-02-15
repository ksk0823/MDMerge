using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderObject : MonoBehaviour
{
    public GameObject orderObject;
    public int orderId;
    public int orderNum;
    //생성 시 orderNum 넣어서 배열 초기화
    public MaterialItemData[] orderItems;
}
