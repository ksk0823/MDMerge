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
    public static int[] prices = new int[59]; //@ 개별 판매 가격 설정하면 이것도 초기화시켜야됨

    //확률 설정. 지금은 다 똑같이
    public void setItemProb()
    {
        float equalProbability = 1.0f / ItemNum;
        for (int i = 0; i < percents.Length; i++)
        {
            percents[i] = equalProbability;
        }
    }

    //스프라이트 코드 부여
    public static Sprite[] itemSprites = new Sprite[59];

    //드롭되는 스프라이트 
    public void LoadItemSprites()
    {
        //공장1
        itemSprites[0] = Resources.Load<Sprite>("SpriteKSK/공장1/실 코바늘");
        itemSprites[1] = Resources.Load<Sprite>("SpriteKSK/공장1/뜨개질어느정도된");
        itemSprites[2] = Resources.Load<Sprite>("SpriteKSK/공장1/머플러");
        itemSprites[3] = Resources.Load<Sprite>("SpriteKSK/공장1/비니");
        itemSprites[4] = Resources.Load<Sprite>("SpriteKSK/공장1/캡모자");
        itemSprites[5] = Resources.Load<Sprite>("SpriteKSK/공장1/버킷햇");

        //공장2
        itemSprites[6] = Resources.Load<Sprite>("SpriteKSK/공장2/원단조각");
        itemSprites[7] = Resources.Load<Sprite>("SpriteKSK/공장2/나시");
        itemSprites[8] = Resources.Load<Sprite>("SpriteKSK/공장2/반팔티");
        itemSprites[9] = Resources.Load<Sprite>("SpriteKSK/공장2/맨투맨");
        itemSprites[10] = Resources.Load<Sprite>("SpriteKSK/공장2/후드");
        itemSprites[11] = Resources.Load<Sprite>("SpriteKSK/공장2/바시티자켓");

        //재봉틀1
        itemSprites[12] = Resources.Load<Sprite>("SpriteKSK/재봉틀1/부직포 원단");
        itemSprites[13] = Resources.Load<Sprite>("SpriteKSK/재봉틀1/장바구니");
        itemSprites[14] = Resources.Load<Sprite>("SpriteKSK/재봉틀1/스크런치");
        itemSprites[15] = Resources.Load<Sprite>("SpriteKSK/재봉틀1/파우치");
        itemSprites[16] = Resources.Load<Sprite>("SpriteKSK/재봉틀1/미니크로스백");
        itemSprites[17] = Resources.Load<Sprite>("SpriteKSK/재봉틀1/백팩");

        //재봉틀2
        itemSprites[18] = Resources.Load<Sprite>("SpriteKSK/재봉틀2/솜뭉치");
        itemSprites[19] = Resources.Load<Sprite>("SpriteKSK/재봉틀2/인형옷");
        itemSprites[20] = Resources.Load<Sprite>("SpriteKSK/재봉틀2/스트레스볼");
        itemSprites[21] = Resources.Load<Sprite>("SpriteKSK/재봉틀2/미니 인형");
        itemSprites[22] = Resources.Load<Sprite>("SpriteKSK/재봉틀2/대형 인형");

        //사진기
        itemSprites[23] = Resources.Load<Sprite>("SpriteKSK/사진기/필름");
        itemSprites[24] = Resources.Load<Sprite>("SpriteKSK/사진기/폴라로이드");
        itemSprites[25] = Resources.Load<Sprite>("SpriteKSK/사진기/티켓포카");
        itemSprites[26] = Resources.Load<Sprite>("SpriteKSK/사진기/엽서세트");
        itemSprites[27] = Resources.Load<Sprite>("SpriteKSK/사진기/포스터");
        itemSprites[28] = Resources.Load<Sprite>("SpriteKSK/사진기/포토북");

        //출력기1
        itemSprites[29] = Resources.Load<Sprite>("SpriteKSK/출력기1/스티커");
        itemSprites[30] = Resources.Load<Sprite>("SpriteKSK/출력기1/포토카드");
        itemSprites[31] = Resources.Load<Sprite>("SpriteKSK/출력기1/포카홀더");
        itemSprites[32] = Resources.Load<Sprite>("SpriteKSK/출력기1/콜렉트북");

        //출력기2
        itemSprites[33] = Resources.Load<Sprite>("SpriteKSK/출력기2/섬유");
        itemSprites[34] = Resources.Load<Sprite>("SpriteKSK/출력기2/미니배너");
        itemSprites[35] = Resources.Load<Sprite>("SpriteKSK/출력기2/슬로건");
        itemSprites[36] = Resources.Load<Sprite>("SpriteKSK/출력기2/패브릭 포스터");

        //응원봉부스
        itemSprites[37] = Resources.Load<Sprite>("SpriteGYB/128/04-1 bat1");
        itemSprites[38] = Resources.Load<Sprite>("SpriteGYB/128/04-2 bat2");
        itemSprites[39] = Resources.Load<Sprite>("SpriteGYB/128/04-3 bat3");
        itemSprites[40] = Resources.Load<Sprite>("SpriteGYB/128/04-4 lightbulb");
        itemSprites[41] = Resources.Load<Sprite>("SpriteGYB/128/04-5 lightstick");

        //장신구 디스플레이
        itemSprites[42] = Resources.Load<Sprite>("SpriteGYB/128/05-1 bead");
        itemSprites[43] = Resources.Load<Sprite>("SpriteGYB/128/05-2 beads 2");
        itemSprites[44] = Resources.Load<Sprite>("SpriteGYB/128/05-3 bead ring");
        itemSprites[45] = Resources.Load<Sprite>("SpriteGYB/128/05-4 bead earr");
        itemSprites[46] = Resources.Load<Sprite>("SpriteGYB/128/05-5 bead b");
        itemSprites[47] = Resources.Load<Sprite>("SpriteGYB/128/05-6 bead neck");
        itemSprites[48] = Resources.Load<Sprite>("SpriteGYB/128/05-7 ring");

        //도자기물레
        itemSprites[49] = Resources.Load<Sprite>("SpriteGYB/128/06-4 cup");
        itemSprites[50] = Resources.Load<Sprite>("SpriteGYB/128/06-5 mug cup");
        itemSprites[51] = Resources.Load<Sprite>("SpriteGYB/128/06-6 mug cup and coaster");

        //용광로1
        itemSprites[52] = Resources.Load<Sprite>("SpriteGYB/128/07-4 plastic key ring");
        itemSprites[53] = Resources.Load<Sprite>("SpriteGYB/128/07-5 plastic thermos");
        itemSprites[54] = Resources.Load<Sprite>("SpriteGYB/128/07-6 plastic stand a");


        //용광로2
        itemSprites[55] = Resources.Load<Sprite>("SpriteGYB/128/08-4 metal badge");
        itemSprites[56] = Resources.Load<Sprite>("SpriteGYB/128/08-5 metal mini key ring 1");
        itemSprites[57] = Resources.Load<Sprite>("SpriteGYB/128/08-6 metal mini key ring 2");
        itemSprites[58] = Resources.Load<Sprite>("SpriteGYB/128/08-7 metal mini key ring ");


        // 나머지 아이템 스프라이트들의 로딩 코드
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

