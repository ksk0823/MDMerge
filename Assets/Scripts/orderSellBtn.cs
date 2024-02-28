using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class orderSellBtn : MonoBehaviour
{
    public TMP_Text priceText;
    public TMP_Text expText;

    public GameObject[] myitems;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SellOrder()
    {
       
        if (CheckItemsAvailable())
        {
            //player재화 변동
            int price = int.Parse(priceText.text);
            int exp = int.Parse(expText.text);
            Debug.Log("order price = " + price);
            Debug.Log("order exp = " + exp);
            //int jem = orderObject.jem
            int jem = 0;
            PlayerData.instance.money += price;
            PlayerData.instance.exp += exp;
            PlayerData.instance.jewel += jem;

            //orderslot 오브젝트삭제
            GameObject parentObject = transform.parent.gameObject;
            Destroy(parentObject);
            PlayerData.instance.orderCnt--;

        }
    }
    private bool CheckItemsAvailable()  //아이템이 다 있다면  조건문

    {
        int orderItemNum_ = transform.parent.gameObject.GetComponent<OrderObject>().orderItemNum;

        if (InventoryManager.Instance.Myitems() == null) return false; //myitems가 비어있으면 바로 false
        int myItemsLength = InventoryManager.Instance.Myitems().Length;
        myitems = new GameObject[myItemsLength];

        for (int i = 0; i < myItemsLength; i++)
        {
            myitems[i] = InventoryManager.Instance.Myitems()[i];
        }

        MaterialItemData[] orderitems = new MaterialItemData[orderItemNum_];

        int n = 0;
        foreach (MaterialItemData item in transform.parent.gameObject.GetComponent<OrderObject>().orderItems)
        {
            orderitems[n] = item;
            n++;
        }


        int[] destoyIndex = new int[orderItemNum_];
        bool flag = false;
        int j = 0;

        //첫번째 아이템 있는지
        while (j < orderItemNum_)
        {
            for (int i = 0; i < myitems.Length; i++)
            {
                if (orderitems[j].itemImg.name == myitems[i].GetComponent<Image>().sprite.name)
                {
                    destoyIndex[j] = i;
                    flag = true;
                }
            }
            if (flag == false)
            { //못찾으면 
                Debug.Log("주문판매 실패");
                return false;
            }
            else
            {
                j++;
            }
        }
        Debug.Log("주문판매 성공");
        for (int i = 0; i < orderItemNum_; i++)
        {
             Destroy(myitems[destoyIndex[i]].gameObject);
        }

        return true; 
    }
}
