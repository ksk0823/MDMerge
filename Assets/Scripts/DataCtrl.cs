using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataCtrl : MonoBehaviour
{
    private static DataCtrl Instance;
    public static DataCtrl instance
    {
        set
        {
            if (Instance == null)
                Instance = value;
        }
        get { return Instance; }
    }
    public OrderData orderData;
    public List<Item> items = new List<Item>();

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Start()
    {
        
    }
    
    public struct PlayerData
    {
        public long level;
        public long energy;
        public long gold;
        public long diamond;

        public PlayerData(long _gold)
        {
            gold = _gold;
            energy = 0;
            level = 0;
            diamond = 0;
        }
        
    }
    public struct OrderData
    {
        public int orderNum;
        public int[] orders;
        
        public OrderData(int _orderNum)
        {
            orderNum = _orderNum;
            orders = new int[orderNum];
        }
    }

}

public class Item
{
    public static int ItemNum = 59;
    public static float[] percents = new float[59];
    public static int[] prices = new int[59]; //@ ���� �Ǹ� ���� �����ϸ� �̰͵� �ʱ�ȭ���Ѿߵ�

    //Ȯ�� ����. ������ �� �Ȱ���
    public void setItemProb()
    {
        float equalProbability = 1.0f / ItemNum;
        for (int i = 0; i < percents.Length; i++)
        {
            percents[i] = equalProbability;
        }
    }

    //��������Ʈ �ڵ� �ο�
    public static Sprite[] itemSprites = new Sprite[59];

    //��ӵǴ� ��������Ʈ 
    public void LoadItemSprites()
    {
        //����1
        itemSprites[0] = Resources.Load<Sprite>("SpriteKSK/����1/�� �ڹٴ�");
        itemSprites[1] = Resources.Load<Sprite>("SpriteKSK/����1/�߰������������");
        itemSprites[2] = Resources.Load<Sprite>("SpriteKSK/����1/���÷�");
        itemSprites[3] = Resources.Load<Sprite>("SpriteKSK/����1/���");
        itemSprites[4] = Resources.Load<Sprite>("SpriteKSK/����1/ĸ����");
        itemSprites[5] = Resources.Load<Sprite>("SpriteKSK/����1/��Ŷ��");

        //����2
        itemSprites[6] = Resources.Load<Sprite>("SpriteKSK/����2/��������");
        itemSprites[7] = Resources.Load<Sprite>("SpriteKSK/����2/����");
        itemSprites[8] = Resources.Load<Sprite>("SpriteKSK/����2/����Ƽ");
        itemSprites[9] = Resources.Load<Sprite>("SpriteKSK/����2/������");
        itemSprites[10] = Resources.Load<Sprite>("SpriteKSK/����2/�ĵ�");
        itemSprites[11] = Resources.Load<Sprite>("SpriteKSK/����2/�ٽ�Ƽ����");

        //���Ʋ1
        itemSprites[12] = Resources.Load<Sprite>("SpriteKSK/���Ʋ1/������ ����");
        itemSprites[13] = Resources.Load<Sprite>("SpriteKSK/���Ʋ1/��ٱ���");
        itemSprites[14] = Resources.Load<Sprite>("SpriteKSK/���Ʋ1/��ũ��ġ");
        itemSprites[15] = Resources.Load<Sprite>("SpriteKSK/���Ʋ1/�Ŀ�ġ");
        itemSprites[16] = Resources.Load<Sprite>("SpriteKSK/���Ʋ1/�̴�ũ�ν���");
        itemSprites[17] = Resources.Load<Sprite>("SpriteKSK/���Ʋ1/����");

        //���Ʋ2
        itemSprites[18] = Resources.Load<Sprite>("SpriteKSK/���Ʋ2/�ع�ġ");
        itemSprites[19] = Resources.Load<Sprite>("SpriteKSK/���Ʋ2/������");
        itemSprites[20] = Resources.Load<Sprite>("SpriteKSK/���Ʋ2/��Ʈ������");
        itemSprites[21] = Resources.Load<Sprite>("SpriteKSK/���Ʋ2/�̴� ����");
        itemSprites[22] = Resources.Load<Sprite>("SpriteKSK/���Ʋ2/���� ����");

        //������
        itemSprites[23] = Resources.Load<Sprite>("SpriteKSK/������/�ʸ�");
        itemSprites[24] = Resources.Load<Sprite>("SpriteKSK/������/������̵�");
        itemSprites[25] = Resources.Load<Sprite>("SpriteKSK/������/Ƽ����ī");
        itemSprites[26] = Resources.Load<Sprite>("SpriteKSK/������/������Ʈ");
        itemSprites[27] = Resources.Load<Sprite>("SpriteKSK/������/������");
        itemSprites[28] = Resources.Load<Sprite>("SpriteKSK/������/�����");

        //��±�1
        itemSprites[29] = Resources.Load<Sprite>("SpriteKSK/��±�1/��ƼĿ");
        itemSprites[30] = Resources.Load<Sprite>("SpriteKSK/��±�1/����ī��");
        itemSprites[31] = Resources.Load<Sprite>("SpriteKSK/��±�1/��īȦ��");
        itemSprites[32] = Resources.Load<Sprite>("SpriteKSK/��±�1/�ݷ�Ʈ��");

        //��±�2
        itemSprites[33] = Resources.Load<Sprite>("SpriteKSK/��±�2/����");
        itemSprites[34] = Resources.Load<Sprite>("SpriteKSK/��±�2/�̴Ϲ��");
        itemSprites[35] = Resources.Load<Sprite>("SpriteKSK/��±�2/���ΰ�");
        itemSprites[36] = Resources.Load<Sprite>("SpriteKSK/��±�2/�к긯 ������");

        //�������ν�
        itemSprites[37] = Resources.Load<Sprite>("SpriteGYB/128/04-1 bat1");
        itemSprites[38] = Resources.Load<Sprite>("SpriteGYB/128/04-2 bat2");
        itemSprites[39] = Resources.Load<Sprite>("SpriteGYB/128/04-3 bat3");
        itemSprites[40] = Resources.Load<Sprite>("SpriteGYB/128/04-4 lightbulb");
        itemSprites[41] = Resources.Load<Sprite>("SpriteGYB/128/04-5 lightstick");

        //��ű� ���÷���
        itemSprites[42] = Resources.Load<Sprite>("SpriteGYB/128/05-1 bead");
        itemSprites[43] = Resources.Load<Sprite>("SpriteGYB/128/05-2 beads 2");
        itemSprites[44] = Resources.Load<Sprite>("SpriteGYB/128/05-3 bead ring");
        itemSprites[45] = Resources.Load<Sprite>("SpriteGYB/128/05-4 bead earr");
        itemSprites[46] = Resources.Load<Sprite>("SpriteGYB/128/05-5 bead b");
        itemSprites[47] = Resources.Load<Sprite>("SpriteGYB/128/05-6 bead neck");
        itemSprites[48] = Resources.Load<Sprite>("SpriteGYB/128/05-7 ring");

        //���ڱ⹰��
        itemSprites[49] = Resources.Load<Sprite>("SpriteGYB/128/06-4 cup");
        itemSprites[50] = Resources.Load<Sprite>("SpriteGYB/128/06-5 mug cup");
        itemSprites[51] = Resources.Load<Sprite>("SpriteGYB/128/06-6 mug cup and coaster");

        //�뱤��1
        itemSprites[52] = Resources.Load<Sprite>("SpriteGYB/128/07-4 plastic key ring");
        itemSprites[53] = Resources.Load<Sprite>("SpriteGYB/128/07-5 plastic thermos");
        itemSprites[54] = Resources.Load<Sprite>("SpriteGYB/128/07-6 plastic stand a");


        //�뱤��2
        itemSprites[55] = Resources.Load<Sprite>("SpriteGYB/128/08-4 metal badge");
        itemSprites[56] = Resources.Load<Sprite>("SpriteGYB/128/08-5 metal mini key ring 1");
        itemSprites[57] = Resources.Load<Sprite>("SpriteGYB/128/08-6 metal mini key ring 2");
        itemSprites[58] = Resources.Load<Sprite>("SpriteGYB/128/08-7 metal mini key ring ");


        // ������ ������ ��������Ʈ���� �ε� �ڵ�
    }

    public int itemCode;
    public Sprite sprite;
    public int price;

    public Item(int _itemCode)
    {
        itemCode = _itemCode;
        sprite = itemSprites[itemCode];
        price = prices[itemCode];
    }

    
}

