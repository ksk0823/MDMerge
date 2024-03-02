using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GeneratorLockManager : MonoBehaviour
{
    public List<GeneratorItemData> generators;

    public TMP_Text unlockText;
    public GameObject UnlockPanel;
    int unlockID;


    void Start()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("GeneratorData");
        foreach (GameObject go in gos) 
        {
            GeneratorItemData item = go.GetComponent<GeneratorItemData>();
            generators.Add(item);
        }
        generators.Sort((x, y) => x.id.CompareTo(y.id));

        checkPlayerDataGenerators();

        checkIsAvailable();
    }

    void Update()
    {
        
    }

    public void unlockGenerator()
    {
        foreach (GeneratorItemData generator in generators)
        {
            if (generator.id == unlockID)
            {
                if (unlockID == 4)
                {
                    if (!PlayerData.instance.mapUnlocks[1])
                    {
                        unlockText.SetText("부산 콘서트 개최가 필요합니다.");
                        return;
                    }
                }
                if (unlockID == 6)
                {
                    if (!PlayerData.instance.mapUnlocks[2])
                    {
                        unlockText.SetText("인천 콘서트 개최가 필요합니다.");
                        return;
                    }
                }
                if (unlockID == 8)
                {
                    if (!PlayerData.instance.mapUnlocks[3])
                    {
                        unlockText.SetText("광주 콘서트 개최가 필요합니다.");
                        return;
                    }
                }
                if (unlockID == 9)
                {
                    if (!PlayerData.instance.mapUnlocks[4])
                    {
                        unlockText.SetText("도쿄 콘서트 개최가 필요합니다.");
                        return;
                    }
                }
                if (unlockID == 10)
                {
                    if (!PlayerData.instance.mapUnlocks[5])
                    {
                        unlockText.SetText("상해 콘서트 개최가 필요합니다.");
                        return;
                    }
                }


                int tempLevel = generator.canUseLevel;
                int tempMoney = generator.unlockMoney;
                int tempJewel = generator.unlockJewel;

                if (PlayerData.instance.level >= tempLevel
                    && PlayerData.instance.money >= tempMoney
                    && PlayerData.instance.jewel >= tempJewel)
                {
                    PlayerData.instance.money = PlayerData.instance.money - tempMoney;
                    PlayerData.instance.jewel = PlayerData.instance.jewel - tempJewel;
                    if (generator.isClickable)
                    {
                        PlayerData.instance.generators[generator.id] = true;
                        PlayerData.instance.generators[(generator.id)+1] = true;
                        generator.available = true;
                        generators[unlockID+1].GetComponent<GeneratorItemData>().available = true;
                    }
                    else
                    {
                        PlayerData.instance.generators[generator.id] = true;
                        generator.available = true;
                    }

                    checkIsAvailable();
                    UnlockPanel.SetActive(false);
                }
                else 
                {
                    unlockText.SetText("생성기 구매 재화가 부족합니다.\n재정을 확인해주세요.");
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
        foreach (GeneratorItemData generator in generators)
        {
            if (generator.id == id)
            {
                int tempLevel = generator.canUseLevel;
                int tempMoney = generator.unlockMoney;
                int tempJewel = generator.unlockJewel;

                if (tempJewel > 0)
                {
                    string tmpText = "요구 레벨: " + tempLevel.ToString()
                        + "\n필요한 돈: " + tempMoney
                        + "\n필요한 보석: " + tempJewel;
                    unlockText.SetText(tmpText);
                }
                else 
                {
                    string tmpText = "요구 레벨: " + tempLevel.ToString()
                        + "\n필요한 돈: " + tempMoney;
                    unlockText.SetText(tmpText);
                }
                return;
            }
        }

    }

    // 플레이 시작 시 playerData에서 생성기 해금 여부 확인
    public void checkPlayerDataGenerators()
    {
        bool[] bools = PlayerData.instance.generators;
        int index = 0;
        foreach (bool check in bools)
        {
            if (check)
            {
                generators[index].available = true;
            }
            else
            {
                generators[index].available = false;
            }
            index++;
        }
    }

    public void checkIsAvailable() 
    {
        foreach (GeneratorItemData generator in generators) 
        {
            if (generator.id == 4)
            {
                if (!generator.available)
                {
                    GameObject buttonObject = GameObject.FindGameObjectWithTag("factoryButton");
                    Button button = buttonObject.GetComponent<Button>();
                    button.interactable = false;
                }
                else
                {
                    GameObject buttonObject = GameObject.FindGameObjectWithTag("factoryButton");
                    Button button = buttonObject.GetComponent<Button>();
                    
                    Transform buttonTr = buttonObject.transform;
                    if (buttonTr.childCount > 0)
                    {
                        GameObject lockButton = buttonObject.transform.GetChild(0).gameObject;
                        Destroy(lockButton);
                    }

                    button.interactable = true;
                }
            }

            if (generator.id == 6)
            {
                if (!generator.available)
                {
                    GameObject buttonObject = GameObject.FindGameObjectWithTag("sewingButton");
                    Button button = buttonObject.GetComponent<Button>();
                    button.interactable = false;
                }
                else
                {
                    GameObject buttonObject = GameObject.FindGameObjectWithTag("sewingButton");
                    Button button = buttonObject.GetComponent<Button>();
                    button.interactable = true;
                    Transform buttonTr = buttonObject.transform;
                    if (buttonTr.childCount > 0)
                    {
                        GameObject lockButton = buttonObject.transform.GetChild(0).gameObject;
                        Destroy(lockButton);
                    }
                }
            }

            if (generator.id == 8)
            {
                if (!generator.available)
                {
                    GameObject buttonObject = GameObject.FindGameObjectWithTag("accessoryButton");
                    Button button = buttonObject.GetComponent<Button>();
                    button.interactable = false;
                }
                else
                {
                    GameObject buttonObject = GameObject.FindGameObjectWithTag("accessoryButton");
                    Button button = buttonObject.GetComponent<Button>();
                    Transform buttonTr = buttonObject.transform;
                    if (buttonTr.childCount > 0)
                    {
                        button.interactable = true;
                        GameObject lockButton = buttonObject.transform.GetChild(0).gameObject;
                        Destroy(lockButton);
                    }
                }
            }

            if (generator.id == 9)
            {
                if (!generator.available)
                {
                    GameObject buttonObject = GameObject.FindGameObjectWithTag("potteryButton");
                    Button button = buttonObject.GetComponent<Button>();
                    button.interactable = false;

                }
                else
                {
                    GameObject buttonObject = GameObject.FindGameObjectWithTag("potteryButton");
                    Button button = buttonObject.GetComponent<Button>();
                    Transform buttonTr = buttonObject.transform;
                    if (buttonTr.childCount > 0)
                    {
                        button.interactable = true;
                        GameObject lockButton = buttonObject.transform.GetChild(0).gameObject;
                        Destroy(lockButton);
                    }
                }
            }

            if (generator.id == 10)
            {
                if (!generator.available)
                {
                    GameObject buttonObject = GameObject.FindGameObjectWithTag("furnaceButton");
                    Button button = buttonObject.GetComponent<Button>();
                    button.interactable = false;
                }
                else
                {
                    GameObject buttonObject = GameObject.FindGameObjectWithTag("furnaceButton");
                    Button button = buttonObject.GetComponent<Button>();
                    Transform buttonTr = buttonObject.transform;
                    if (buttonTr.childCount > 0)
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
