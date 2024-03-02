using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class MapUpdater : MonoBehaviour
{
    GameObject[] lockButtons;
    
    public Sprite star;
    // Start is called before the first frame update
    void Start()
    {
        lockButtons = GameObject.FindGameObjectsWithTag("mapLockButton");

        List<GameObject> buttonsList = lockButtons.ToListPooled();
        buttonsList.Sort((x, y) => x.GetComponent<LockButton>().index.CompareTo(y.GetComponent<LockButton>().index));
        lockButtons = buttonsList.ToArray();

        int index = 0;
        foreach (bool isUnlock in PlayerData.instance.mapUnlocks)
        {
            if (isUnlock)
            {
                Image img = lockButtons[index].GetComponent<Image>();
                img.sprite = star;
            }
            index++;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
