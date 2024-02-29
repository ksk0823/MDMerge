using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GeneratorLockManager : MonoBehaviour
{
    GameObject[] generators;

    public TMP_Text unlockText;
    public GameObject UnlockPanel;
    int unlockID;


    void Start()
    {
        generators = GameObject.FindGameObjectsWithTag("GeneratorData");
        checkIsAvailable();
    }

    void Update()
    {
        
    }

    public void unlockGenerator()
    {
        foreach (GameObject generator in generators)
        {
            GeneratorItemData item = generator.GetComponent<GeneratorItemData>();

            if (item.id == unlockID)
            {
                int tempLevel = item.canUseLevel;
                int tempMoney = item.unlockMoney;
                int tempJewel = item.unlockJewel;

                if (PlayerData.instance.level >= tempLevel
                    && PlayerData.instance.money >= tempMoney
                    && PlayerData.instance.jewel >= tempJewel)
                {
                    PlayerData.instance.money = PlayerData.instance.money - tempMoney;
                    PlayerData.instance.jewel = PlayerData.instance.jewel - tempJewel;
                    item.available = true;
                    checkIsAvailable();
                    UnlockPanel.SetActive(false);
                }
                else 
                {
                    // �� ���� �˾�
                }
            }
        }
    }

    public void viewUnlockPanel(int id)
    {
        UnlockPanel.SetActive(true);
        unlockID = id;
        setUnlockText(id);
    }

    public void quitUnlockPanel()
    {
        UnlockPanel.SetActive(false);
    }

    public void setUnlockText(int id)
    {
        foreach (GameObject generator in generators)
        {
            GeneratorItemData item = generator.GetComponent<GeneratorItemData>();

            if (item.id == id)
            {
                int tempLevel = item.canUseLevel;
                int tempMoney = item.unlockMoney;
                int tempJewel = item.unlockJewel;

                if (tempJewel > 0)
                {
                    string tmpText = "�䱸 ����: " + tempLevel.ToString()
                        + "\n�ʿ��� ��: " + tempMoney
                        + "\n�ʿ��� ����: " + tempJewel;
                    unlockText.SetText(tmpText);
                }
                else 
                {
                    string tmpText = "�䱸 ����: " + tempLevel.ToString()
                        + "\n�ʿ��� ��: " + tempMoney;
                    unlockText.SetText(tmpText);
                }
                return;
            }
        }

    }

    public void checkIsAvailable() 
    {
        foreach (GameObject generator in generators) 
        {
            GeneratorItemData item = generator.GetComponent<GeneratorItemData>();
            
            if (item.id == 4)
            {
                if (!item.available)
                {
                    GameObject buttonObject = GameObject.FindGameObjectWithTag("factoryButton");
                    Button button = buttonObject.GetComponent<Button>();
                    button.interactable = false;
                    //buttonObject.GetComponentInChildren<Button>().interactable = true;
                }
                else
                {
                    GameObject buttonObject = GameObject.FindGameObjectWithTag("factoryButton");
                    Button button = buttonObject.GetComponent<Button>();
                    if (!button.interactable)
                    {
                        button.interactable = true;
                        GameObject lockButton = buttonObject.transform.GetChild(0).gameObject;
                        Destroy(lockButton);
                    }
                }
            }

            if (item.id == 6)
            {
                if (!item.available)
                {
                    GameObject buttonObject = GameObject.FindGameObjectWithTag("sewingButton");
                    Button button = buttonObject.GetComponent<Button>();
                    button.interactable = false;
                }
                else
                {
                    GameObject buttonObject = GameObject.FindGameObjectWithTag("sewingButton");
                    Button button = buttonObject.GetComponent<Button>();
                    if (!button.interactable)
                    {
                        button.interactable = true;
                        GameObject lockButton = buttonObject.transform.GetChild(0).gameObject;
                        Destroy(lockButton);
                    }
                }
            }

            if (item.id == 8)
            {
                if (!item.available)
                {
                    GameObject buttonObject = GameObject.FindGameObjectWithTag("accessoryButton");
                    Button button = buttonObject.GetComponent<Button>();
                    button.interactable = false;
                }
                else
                {
                    GameObject buttonObject = GameObject.FindGameObjectWithTag("accessoryButton");
                    Button button = buttonObject.GetComponent<Button>();
                    if (!button.interactable)
                    {
                        button.interactable = true;
                        GameObject lockButton = buttonObject.transform.GetChild(0).gameObject;
                        Destroy(lockButton);
                    }
                }
            }

            if (item.id == 9)
            {
                if (!item.available)
                {
                    GameObject buttonObject = GameObject.FindGameObjectWithTag("potteryButton");
                    Button button = buttonObject.GetComponent<Button>();
                    button.interactable = false;

                }
                else
                {
                    GameObject buttonObject = GameObject.FindGameObjectWithTag("potteryButton");
                    Button button = buttonObject.GetComponent<Button>();
                    if (!button.interactable)
                    {
                        button.interactable = true;
                        GameObject lockButton = buttonObject.transform.GetChild(0).gameObject;
                        Destroy(lockButton);
                    }
                }
            }

            if (item.id == 10)
            {
                if (!item.available)
                {
                    GameObject buttonObject = GameObject.FindGameObjectWithTag("furnaceButton");
                    Button button = buttonObject.GetComponent<Button>();
                    button.interactable = false;
                }
                else
                {
                    GameObject buttonObject = GameObject.FindGameObjectWithTag("furnaceButton");
                    Button button = buttonObject.GetComponent<Button>();
                    if (!button.interactable)
                    {
                        button.interactable = true;
                        GameObject lockButton = buttonObject.transform.GetChild(0).gameObject;
                        Destroy(lockButton);
                    }
                }
            }
        }
    }
}
