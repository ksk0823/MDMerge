using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class orderSellBtn : MonoBehaviour
{
    public TMP_Text priceText;
    public TMP_Text expText;

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
            Debug.Log(price);
            Debug.Log(exp);
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
        // 아이템이 다 있는지 체크하는 로직 구현
        // 필요한 조건을 여기에 추가하고, 아이템이 다 있으면 true를 반환하고, 아니면 false를 반환하도록 수정하세요.

        // 예시: 아이템이 다 있을 때만 true 반환

        //if (/* 아이템이 다 있는지 체크하는 조건 */)
        /*{
            return true;
        }
        else
        {
            return false;
        }*/
        return true; //일단 test용으로 true
        
    }
}
