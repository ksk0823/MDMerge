using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : MonoBehaviour
{
    private static GameCtrl Instance;
    public static GameCtrl instance
    {
        set
        {
            if (Instance == null)
                Instance = value;
        }
        get { return Instance; }
    }

    //������ �ֹ� ������Ʈ Prefab
    [SerializeField]
    private GameObject orderObjectPrefab;

    //������ �ֹ� �θ� Transfrom? //���ذ� ��..
    [SerializeField]
    private Transform orderObjectTr;

    public bool isCanCreateOrder;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        isCanCreateOrder = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateOrderObject()
    {
        OrderObject orderObject = Instantiate(orderObjectPrefab, _createPos, Quaternion.identity, orderObjectTr).GetComponent<OderObject>();
        int orderedItemNum = RandomFunction.RandomFlag(Order.orderNumPercent);
        orderObject.OrderedItemNum = orderedItemNum;

        DataCtrl.instance.playerData.orderCount++; //�� �ֹ� ����
    }
}
