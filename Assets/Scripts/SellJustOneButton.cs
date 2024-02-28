using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellJustOneButton : MonoBehaviour
{
    public GameObject nowSelected;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SellJustOne()
    {
        PlayerData.instance.money += nowSelected.GetComponent<MaterialCtrl>().material.priceForPlayer;
        Destroy(nowSelected);
    }
}
