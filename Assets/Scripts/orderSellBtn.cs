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
            //player��ȭ ����
            int price = int.Parse(priceText.text);
            int exp = int.Parse(expText.text);
            Debug.Log(price);
            Debug.Log(exp);
            //int jem = orderObject.jem
            int jem = 0;
            PlayerData.instance.money += price;
            PlayerData.instance.exp += exp;
            PlayerData.instance.jewel += jem;

            //orderslot ������Ʈ����
            GameObject parentObject = transform.parent.gameObject;
            Destroy(parentObject);
            PlayerData.instance.orderCnt--;

        }
    }
    private bool CheckItemsAvailable()  //�������� �� �ִٸ�  ���ǹ�

    {
        // �������� �� �ִ��� üũ�ϴ� ���� ����
        // �ʿ��� ������ ���⿡ �߰��ϰ�, �������� �� ������ true�� ��ȯ�ϰ�, �ƴϸ� false�� ��ȯ�ϵ��� �����ϼ���.

        // ����: �������� �� ���� ���� true ��ȯ

        //if (/* �������� �� �ִ��� üũ�ϴ� ���� */)
        /*{
            return true;
        }
        else
        {
            return false;
        }*/
        return true; //�ϴ� test������ true
        
    }
}
