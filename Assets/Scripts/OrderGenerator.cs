using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;

public class GenerateOrder : MonoBehaviour
{
    //public PlayerData playerData;
    public GameObject prefab;
    public int maxOrderCount = 10;

    public GameObject contentPanel; // Content Panel�� �����ϴ� ����

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

    Coroutine myCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        Booth = GameObject.Find("BoothData");
        Camera = GameObject.Find("CameraData");
        Printer1 = GameObject.Find("PrintData1");
        Printer2 = GameObject.Find("PrintData2");
        Factory1 = GameObject.Find("FactoryData1");
        Factory2 = GameObject.Find("FactoryData2");
        Sewing1 = GameObject.Find("SewingData1");
        Sewing2 = GameObject.Find("SewingData2");
        Accessory = GameObject.Find("AccessoryData");
        Pottery = GameObject.Find("PotteryData");
        Furnace1 = GameObject.Find("FurnaceData1");
        Furnace2 = GameObject.Find("FurnaceData2");

       

    }

    // Update is called once per frame
    void Update()
    {
        if(myCoroutine == null)
        {
            myCoroutine = StartCoroutine(CreateCustomerCoroutine());
        }
    }

    IEnumerator CreateCustomerCoroutine()
    {
        while (PlayerData.instance.orderCnt < maxOrderCount)
        {
            GameObject newPrefab = Instantiate(prefab, transform.position, Quaternion.identity);
            newPrefab.SetActive(false);
            newPrefab.transform.SetParent(contentPanel.transform); // Prefab�� Content Panel�� �ڽ����� ����
             // ������ Prefab�� ���� �߰����� ������ �ʿ��� ���, ���⿡ �ۼ��ϼ���.

            int FangirlSprite = Random.Range(0, 4); //0,1,2,3�� �ϳ��� �������� ����
            newPrefab.transform.Find("Fangirl").GetComponent<Image>().sprite = fanSprites[FangirlSprite];
        

                int OrderItemNum = Random.Range(1, 4); //1,2,3�� �ϳ��� �������� ����

                if (OrderItemNum ==1 || OrderItemNum ==2) //2�� 1�̸� ���� ĭ(Image) ��������ߵ�.
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
            if (newPrefab.GetComponent<OrderObject>().orderItems[0] == null) 
                Debug.Log("���ʿ� �����̾ȵ�"); //�̰� ������ �ƴ�  ���⼱ ��... null�� �ƴ�..
            

            int price =0, jem=0;
            float exp = 0;

            for (int i=0; i<OrderItemNum; i++)
            {
                newPrefab.transform.Find("OrderSlot").Find("itemImage" + i.ToString()).GetComponent<Image>().sprite
                    = newPrefab.GetComponent<OrderObject>().orderItems[i].itemImg;
                price += newPrefab.GetComponent<OrderObject>().orderItems[i].priceForOrder;
                exp += newPrefab.GetComponent<OrderObject>().orderItems[i].exp;
                //jem += newPrefab.GetComponent<OrderObject>().orderItems[i].jem;
            }

            //���� ����,����ġ,���� ����
            newPrefab.GetComponent<OrderObject>().orderPrice = price;
            newPrefab.GetComponent<OrderObject>().orderExp = exp;
            newPrefab.GetComponent<OrderObject>().orderJem = jem;

            //�װſ� ���� priceText�� expText�ٲ��ֱ�
            newPrefab.transform.Find("OrderSlot").Find("priceText").GetComponent<TMP_Text>().SetText(price.ToString());
            newPrefab.transform.Find("OrderSlot").Find("expText").GetComponent<TMP_Text>().SetText(exp.ToString());


            newPrefab.SetActive(true);

            PlayerData.instance.orderCnt++;

            yield return new WaitForSeconds(3f); // 3�� ���� ���
        }

        Debug.LogWarning("Prefab�� �Ѱ� ���� �ʰ��Ͽ� �� �̻� ������ �� �����ϴ�.");

        myCoroutine = null;
    }
    public MaterialItemData[] PickItem(int ordernum) //������ ���ϴ� �Լ�
    {

        //�������ν�, ������ ������ �߰�
        List<MaterialItemData> ItemList = new List<MaterialItemData>();
        ItemList.AddRange(Booth.GetComponent<GeneratorItemData>().materialsData);
        ItemList.AddRange(Camera.GetComponent<GeneratorItemData>().materialsData);

        /*
        //������ �رݿ��ο� ���� �����۸���Ʈ�� ������ �߰� //�����ʿ�
        if (Printer1.GetComponent<GeneratorItemData>().available)
            ItemList.AddRange(Printer1.GetComponent<GeneratorItemData>().materialsData);
        if (Printer2.GetComponent<GeneratorItemData>().available)
            ItemList.AddRange(Printer2.GetComponent<GeneratorItemData>().materialsData);
        if (Factory1.GetComponent<GeneratorItemData>().available)
            ItemList.AddRange(Factory1.GetComponent<GeneratorItemData>().materialsData);
        if (Factory2.GetComponent<GeneratorItemData>().available)
            ItemList.AddRange(Factory2.GetComponent<GeneratorItemData>().materialsData);
        if (Sewing1.GetComponent<GeneratorItemData>().available)
            ItemList.AddRange(Sewing1.GetComponent<GeneratorItemData>().materialsData);
        if (Sewing2.GetComponent<GeneratorItemData>().available)
            ItemList.AddRange(Sewing2.GetComponent<GeneratorItemData>().materialsData);
        if (Accessory.GetComponent<GeneratorItemData>().available)
            ItemList.AddRange(Accessory.GetComponent<GeneratorItemData>().materialsData);
        if (Pottery.GetComponent<GeneratorItemData>().available)
            ItemList.AddRange(Pottery.GetComponent<GeneratorItemData>().materialsData);
        if (Furnace1.GetComponent<GeneratorItemData>().available)
            ItemList.AddRange(Furnace1.GetComponent<GeneratorItemData>().materialsData);
        if (Furnace2.GetComponent<GeneratorItemData>().available)
            ItemList.AddRange(Furnace2.GetComponent<GeneratorItemData>().materialsData);
        */
        
        MaterialItemData[] result = new MaterialItemData[ordernum];
        List<MaterialItemData> seleted = new List<MaterialItemData>();

        int i = 0;
        while(i<ordernum)
        {
            int index = Random.Range(0, ItemList.Count); //0~���� �߿� ���� �ϳ� �̱� 
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
