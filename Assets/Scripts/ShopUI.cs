using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class ShopUI : MonoBehaviour
{

    [SerializeField]
    private Transform ShopUITr;

    public GameObject ShopPanel;

    public TextMeshProUGUI playerMoney;
    public TextMeshProUGUI playerEnergy;

    ShopUIContent temp_ShopUIContent;
    ShopUIContent[] temp_ShopUIContents;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void setContentText()
    {
        temp_ShopUIContents = ShopUITr.GetComponentsInChildren<ShopUIContent>();

        for (int i = 0; i < temp_ShopUIContents.Length; i++)
        {
            temp_ShopUIContents[i].texts[0].SetText(temp_ShopUIContents[i].contentName
                + "\n" + temp_ShopUIContents[i].money +" $"
                + "\nEnergy +" + temp_ShopUIContents[i].energy);
        }
    }

    public void updatePlayerText() {
        playerMoney.SetText(PlayerData.instance.money.ToString());
        playerEnergy.SetText(PlayerData.instance.money.ToString());
    }

    public void BuyButton() {
        if (EventSystem.current.currentSelectedGameObject != null)
        {
            temp_ShopUIContent = EventSystem.current.currentSelectedGameObject.GetComponentInParent<ShopUIContent>();
            if (temp_ShopUIContent != null)
            {
                if (PlayerData.instance.money - temp_ShopUIContent.money >= 0)
                {
                    PlayerData.instance.money -= temp_ShopUIContent.money;
                    PlayerData.instance.energy += temp_ShopUIContent.energy;
                }
            }
        }
        updatePlayerText();
    }

    public void viewShopMenu()
    {
        ShopPanel.SetActive(true);
        setContentText();
    }

    public void quitShopMenu()
    {
        ShopPanel.SetActive(false);
    }
}
