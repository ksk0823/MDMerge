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

    //생성될 주문 오브젝트 Prefab
    [SerializeField]
    private GameObject orderObjectPrefab;

    //생성될 주문 부모 Transfrom? //이해가 잘..
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

        DataCtrl.instance.playerData.orderCount++; //총 주문 개수
    }
}
