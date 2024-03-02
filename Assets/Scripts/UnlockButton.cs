using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnlockButton : MonoBehaviour
{
    public int index;
    public int level;
    public int money;
    public int jem;
    public TMP_Text unlockText;
    public GameObject messageText; //안내문
    public Button lockButton; 
    public Sprite star;

    // Start is called before the first frame update
    void Start()
    {
        messageText.SetActive(false);
        if (PlayerData.instance.mapUnlocks[index])
        {
            unlockText.SetText("해금완료");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UnlockLocation(int index)
    {
        if (unlockText.text == "해금완료") return;
        else if (PlayerData.instance.level < level)
        {
            StartCoroutine(ShowTextForWhile(0.7f, messageText));
            return;
        }else if(PlayerData.instance.money < money)
        {
            StartCoroutine(ShowTextForWhile(0.7f, messageText));
            return;
        }else if(PlayerData.instance.jewel < jem)
        {
            StartCoroutine(ShowTextForWhile(0.7f, messageText));
            return;
        }
        else
        {
            PlayerData.instance.money -= money;
            PlayerData.instance.jewel-= jem;
            unlockText.SetText("해금완료");
            //Sprite starSprite = Resources.Load<Sprite>("Scenes/SpriteGYB/128/# star");
            //if (starSprite != null)
            //    lockButton.GetComponent<Image>().sprite = starSprite;
            //lockButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("Scenes/SpriteGYB/128/# star");
            lockButton.GetComponent<Image>().sprite = star;
            PlayerData.instance.mapUnlocks[index] = true;
            return;
        }
    }
   
    IEnumerator ShowTextForWhile(float timeToShow, GameObject textComponent)
    {
        textComponent.SetActive(true);
        yield return new WaitForSeconds(timeToShow);
        textComponent.SetActive(false);
    }
}
