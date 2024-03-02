using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;
using System.Linq;
using System.Diagnostics;
using Unity.VisualScripting;

public class GenerateOrder : MonoBehaviour
{
    public static GenerateOrder Instance;
    //public PlayerData playerData;
    public GameObject prefab;
    public int maxOrderCount = 10;

    public GameObject contentPanel; // Content Panel을 참조하는 변수

    Coroutine myCoroutine; //코루틴 실행중인지 확인을 위한 변수
    bool hasInvoked = false;

    public Sprite[] fanSprites = new Sprite[4];
    public Sprite[] orderSprites = new Sprite[3];

    GameObject Booth;
    GameObject Camera;
    GameObject Printer1;
    GameObject Printer2;
    GameObject Factory1;
    GameObject Factory2;
    GameObject Sewing1;
    GameObject Sewing2;
    GameObject Accessory;
    GameObject Pottery;
    GameObject Furnace1;
    GameObject Furnace2;

    // Start is called before the first frame update
    void Start()
    {
        Booth = GameObject.Find("BoothData");
        Camera = GameObject.Find("CameraData");
        Printer1 = GameObject.Find("PrinterData1");
        Printer2 = GameObject.Find("PrinterData2");
        Factory1 = GameObject.Find("FactoryData1");
        Factory2 = GameObject.Find("FactoryData2");
        Sewing1 = GameObject.Find("SewingData1");
        Sewing2 = GameObject.Find("SewingData2");
        Accessory = GameObject.Find("AccessoryData");
        Pottery = GameObject.Find("PotteryData");
        Furnace1 = GameObject.Find("FurnaceData1");
        Furnace2 = GameObject.Find("FurnaceData2");
        
        //loadOrderInventory();
        Instance = this;
    }

    // Update is called once per frame
 
    void Update()
    {
        
        if (!hasInvoked && myCoroutine == null)
        {
            hasInvoked = true;
            Invoke("StartMyCoroutine", 5f); // 5초 후에 StartMyCoroutine 함수를 호출
        }
    }

    /*
    void loadOrderInventory() 
    {
        if (PlayerData.instance.orderInventory == null)
        {
            // 첫 플레이 시
            PlayerData.instance.orderInventory = new List<OrderObject>();
        }
        else 
        {
            foreach (OrderObject order in PlayerData.instance.orderInventory)
            {
                GameObject newPrefab = Instantiate(prefab, transform.position, Quaternion.identity);
                newPrefab.SetActive(false);
                newPrefab.GetComponent<OrderObject>().orderObject = order.orderObject;
                newPrefab.GetComponent<OrderObject>().priceText = order.priceText;
                newPrefab.GetComponent<OrderObject>().expText = order.expText;
                newPrefab.GetComponent<OrderObject>().orderId = order.orderId;
                newPrefab.GetComponent<OrderObject>().orderItemNum = order.orderItemNum;
                newPrefab.GetComponent<OrderObject>().orderItems = order.orderItems;
                newPrefab.GetComponent<OrderObject>().orderPrice = order.orderPrice;
                newPrefab.GetComponent<OrderObject>().orderExp = order.orderExp;
                newPrefab.GetComponent<OrderObject>().orderJem = order.orderJem;

                newPrefab.transform.SetParent(contentPanel.transform);

                newPrefab.transform.Find("OrderSlot").GetComponent<Image>().sprite = orderSprites[order.orderItemNum - 1];
                for (int i = 0; i < order.orderItemNum; i++)
                {
                    newPrefab.transform.Find("OrderSlot").Find("itemImage" + i.ToString()).GetComponent<Image>().sprite
                    = newPrefab.GetComponent<OrderObject>().orderItems[i].itemImg;
                }
                newPrefab.transform.Find("OrderSlot").Find("priceText").GetComponent<TMP_Text>().SetText(order.orderPrice.ToString());
                newPrefab.transform.Find("OrderSlot").Find("expText").GetComponent<TMP_Text>().SetText(order.orderExp.ToString());
                newPrefab.SetActive(true);
            }
        }
    }

    public void saveOrderInventory()
    {
        if (contentPanel.transform.childCount > 0)
        {
            OrderObject[] orderGOs = contentPanel.GetComponentsInChildren<OrderObject>();
            foreach (OrderObject order in orderGOs)
            {
                OrderObject orderP = new OrderObject();

                orderP.orderObject = order.orderObject;
                orderP.priceText = order.priceText;
                orderP.expText = order.expText;
                orderP.orderId = order.orderId;
                orderP.orderItemNum = order.orderItemNum;

                List<MaterialItemData> tempList = new List<MaterialItemData>();
                foreach (MaterialItemData mit in order.orderItems)
                {
                    MaterialItemData tempItem = new MaterialItemData();
                    tempItem.id = mit.id;
                    tempItem.categoryID = mit.categoryID;
                    tempItem.itemImg = mit.itemImg;
                    tempItem.priceForOrder = mit.priceForOrder;
                    tempItem.priceForPlayer = mit.priceForPlayer;
                    tempItem.exp = mit.exp;
                    tempItem.jewel = mit.jewel;
                    tempList.Add(tempItem);
                }
                orderP.orderItems = tempList.ToArray();

                orderP.orderPrice = order.orderPrice;
                orderP.orderExp = order.orderExp;
                orderP.orderJem = order.orderJem;

                PlayerData.instance.orderInventory.Add(order);
            }
            //PlayerData.instance.orderInventory = orderGOs.ToListPooled();
        }
        else
        {
            return;
        }

    }
    */

    void StartMyCoroutine()
    {
        myCoroutine = StartCoroutine(CreateCustomerCoroutine());
        hasInvoked = false; // 코루틴이 시작되면 다시 Invoke를 호출할 수 있도록 설정
    }


    IEnumerator CreateCustomerCoroutine()
    {
        while (PlayerData.instance.orderCnt < maxOrderCount)
        {
            GameObject newPrefab = Instantiate(prefab, transform.position, Quaternion.identity);
            newPrefab.SetActive(false);
            newPrefab.transform.SetParent(contentPanel.transform); // Prefab을 Content Panel의 자식으로 설정
             // 생성된 Prefab에 대한 추가적인 설정이 필요한 경우, 여기에 작성하세요.

            int FangirlSprite = Random.Range(0, 4); //0,1,2,3중 하나를 무작위로 선택
            newPrefab.transform.Find("Fangirl").GetComponent<Image>().sprite = fanSprites[FangirlSprite];
        

                int OrderItemNum = Random.Range(1, 4); //1,2,3중 하나를 무작위로 선택

                if (OrderItemNum ==1 || OrderItemNum ==2) //2나 1이면 남은 칸(Image) 삭제해줘야됨.
                {
                    Destroy(newPrefab.transform.Find("OrderSlot").Find("itemImage2").gameObject);
                    if(OrderItemNum == 1)
                    {
                        Destroy(newPrefab.transform.Find("OrderSlot").Find("itemImage1").gameObject);
                    }
                
                }
            newPrefab.transform.Find("OrderSlot").GetComponent<Image>().sprite = orderSprites[OrderItemNum-1];

            newPrefab.GetComponent<OrderObject>().orderItemNum = OrderItemNum;
            newPrefab.GetComponent<OrderObject>().orderItems = PickItem(OrderItemNum);

            int price=0, jem=0;
            float exp = 0;

            for (int i=0; i<OrderItemNum; i++)
            {
                newPrefab.transform.Find("OrderSlot").Find("itemImage" + i.ToString()).GetComponent<Image>().sprite
                    = newPrefab.GetComponent<OrderObject>().orderItems[i].itemImg;
                price += newPrefab.GetComponent<OrderObject>().orderItems[i].priceForOrder;
                exp += newPrefab.GetComponent<OrderObject>().orderItems[i].exp;
                jem += newPrefab.GetComponent<OrderObject>().orderItems[i].jewel;
            }

            //보상 가격,경험치,보석 설정
            newPrefab.GetComponent<OrderObject>().orderPrice = price;
            newPrefab.GetComponent<OrderObject>().orderExp = exp;
            newPrefab.GetComponent<OrderObject>().orderJem = jem + OrderItemNum;

            //그거에 따라 priceText랑 expText바꿔주기
            newPrefab.transform.Find("OrderSlot").Find("priceText").GetComponent<TMP_Text>().SetText(price.ToString());
            newPrefab.transform.Find("OrderSlot").Find("expText").GetComponent<TMP_Text>().SetText(exp.ToString());


            newPrefab.SetActive(true);

            PlayerData.instance.orderCnt++;

            yield return new WaitForSeconds(3f); // 3초 동안 대기
        }

        //Debug.LogWarning("Prefab의 한계 수를 초과하여 더 이상 생성할 수 없습니다.");

        myCoroutine = null;
    }
    public MaterialItemData[] PickItem(int ordernum) //아이템 정하는 함수
    {

        //응원봉부스, 사진기 아이템 추가
        List<MaterialItemData> ItemList = new List<MaterialItemData>();
        ItemList.AddRange(Booth.GetComponent<GeneratorItemData>().materialsData);
        ItemList.AddRange(Camera.GetComponent<GeneratorItemData>().materialsData);
        ItemList.AddRange(Printer1.GetComponent<GeneratorItemData>().materialsData);
        ItemList.AddRange(Printer2.GetComponent<GeneratorItemData>().materialsData);


        //생성기 해금여부에 따라 아이템리스트에 아이템 추가 //수정필요
        if (PlayerData.instance.mapUnlocks[1]) //부산해금 -> 공장생성기 아이템 포함
        {
            ItemList.AddRange(Factory1.GetComponent<GeneratorItemData>().materialsData);
            ItemList.AddRange(Factory2.GetComponent<GeneratorItemData>().materialsData);
        }
        if (PlayerData.instance.mapUnlocks[2]) //인천해금 -> 재봉틀 아이템 포함
        {
            ItemList.AddRange(Sewing1.GetComponent<GeneratorItemData>().materialsData);
            ItemList.AddRange(Sewing2.GetComponent<GeneratorItemData>().materialsData);
        }
        if (PlayerData.instance.mapUnlocks[3]) //광주해금 -> 장신구디스플레이 아이템포함
        {
            ItemList.AddRange(Accessory.GetComponent<GeneratorItemData>().materialsData);
        }
        if (PlayerData.instance.mapUnlocks[4]) //도쿄해금 -> 도자기물레 아이템포함
        {
            ItemList.AddRange(Pottery.GetComponent<GeneratorItemData>().materialsData);
        }
        if (PlayerData.instance.mapUnlocks[5]) //상해해금 -> 용광로 아이템포함
        {
            ItemList.AddRange(Furnace1.GetComponent<GeneratorItemData>().materialsData);
            ItemList.AddRange(Furnace2.GetComponent<GeneratorItemData>().materialsData);
        }

    
        MaterialItemData[] result = new MaterialItemData[ordernum];
        List<MaterialItemData> seleted = new List<MaterialItemData>();

        int i = 0;
        while(i<ordernum)
        {
            int index = Random.Range(0, ItemList.Count); //0~길이 중에 랜덤 하나 뽑기 
            MaterialItemData seletedItem = ItemList[index];

            if (!seleted.Contains(seletedItem))
            {
                seleted.Add(seletedItem);
                result[i] = seletedItem;
                i++;
            }
        }

        return result;


    }

}
