using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FirstPlayDialog : MonoBehaviour
{
    
    public class dialogObject
    {
        public string dname;
        public string dialog;
        public int imgID;

        public dialogObject(string name, string dialog, int imgID)
        {
            this.dname = name;
            this.dialog = dialog;
            this.imgID = imgID;
        }
    }
    public GameObject canvas;
    public static FirstPlayDialog Instance;
    public GameObject dialogPanel;
    public GameObject boojang;
    public TMP_Text dname;
    public TMP_Text dialog;
    public Sprite[] imgs;
    int index = 0;
    dialogObject[] arr;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        dialogPanel.SetActive(false);
    }

    public void viewdialogPanel()
    {
        dialogPanel.SetActive (true);
        inputDialogObjects();
        setDialog();
    }

    void inputDialogObjects()
    {
        string playerName = PlayerData.instance.playerName;
        string groupName = PlayerData.instance.groupName;

        List<dialogObject> list = new List<dialogObject>();
        list.Add(new dialogObject(playerName, "(오늘은 나의 첫 출근 날이다.)", 2));
        list.Add(new dialogObject(playerName, "(얼렁뚱땅 엔터테인먼트라는 곳에 출근하게 됐다.)", 2));
        list.Add(new dialogObject(playerName, "(얼렁뚱땅 엔터테인먼트라니... 이름부터 불길하지만)", 2));
        list.Add(new dialogObject(playerName, "(겨우 얻은 첫 직장인 만큼 열심히 하고 싶다!)", 2));
        list.Add(new dialogObject(playerName, "(...라고 생각한 지 1시간도 되지 않았는데...)", 2));
        list.Add(new dialogObject(playerName, "...네?", 2));
        list.Add(new dialogObject("부장님", groupName + "의 콘서트 기획이랑 운영을 맡아주세요.", 0));
        list.Add(new dialogObject(playerName, "부장님?! 저 오늘 입사했는데요??", 0));
        list.Add(new dialogObject(playerName, "(회사는 출근 첫날부터 내게 큰 폭탄을 던져버렸다.)", 0));
        list.Add(new dialogObject(playerName, "(" + groupName + "은 얼렁뚱땅 엔터테인먼트에서 데뷔한 지 이제 2년도 채 되지 않은 신인 아이돌 그룹이다.)", 0));
        list.Add(new dialogObject(playerName, "(아직은 이름이 잘 알려지지 않은 그룹이지만 실력은 출중한 것으로 알고 있다.)", 0));
        list.Add(new dialogObject(playerName, "(홍보만 잘 하면 분명 성공할 팀이라고 생각한다. 그래서 홍보가 매우 중요한 상황인데...)", 0));
        list.Add(new dialogObject(playerName, "(그 중요한 일을 제가요?! 입사한지 하루밖에 안된 제가요?!)", 0));
        list.Add(new dialogObject(playerName, "(이 현실이 믿기지 않아서 부장님께 여러번 되물어봤지만 돌아오는 답은 같았다.)", 0));
        list.Add(new dialogObject("부장님", "앞으로 " + groupName +"의 콘서트 기획부터 운영까지 모두 " + playerName + " 사원이 맡게 될 겁니다.", 1));
        list.Add(new dialogObject("부장님", "잘 할 수 있겠죠? ㅎㅎ", 1));
        list.Add(new dialogObject(playerName, "(잘 해야죠... ㅎㅎ)", 1));
        list.Add(new dialogObject("부장님", "우선 MD 부스에서 팔 MD 물품들부터 차근차근 제작하고 판 다음에", 0));
        list.Add(new dialogObject("부장님", "판 돈으로 콘서트 지역을 늘리면서 제작할 MD 품목들도 늘리면 될 겁니다.", 0));
        list.Add(new dialogObject("부장님", "물건을 제작할 때마다 에너지가 1씩 소비되고", 0));
        list.Add(new dialogObject("부장님", "소비한 에너지는 회사 내 상점에서 구매한 물품들로 충전 가능 하니 참고하세요.", 0));
        list.Add(new dialogObject("부장님", "그러면 콘서트 운영 파이팅입니다!", 1));
        list.Add(new dialogObject(playerName, "넵... 파이팅...!!ㅠ", 1));
        arr = list.ToArray();

    }

    public void setDialog() 
    {
        if (index == arr.Length)
        {
            PlayerData.instance.isFirstPlay = false;
            dialogPanel.SetActive(false);
            Destroy(canvas);
            return;
        }

        dname.SetText(arr[index].dname);
        dialog.SetText(arr[index].dialog);
        if (arr[index].imgID == 2)
        {
            boojang.SetActive(false);
        }
        else 
        {
            boojang.SetActive(true);
            Image img = boojang.GetComponent<Image>();
            img.sprite = imgs[arr[index].imgID];
        }
        index++;
    }
}
