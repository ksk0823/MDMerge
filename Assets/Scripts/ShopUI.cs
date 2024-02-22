using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    public GameObject ShopPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void viewShopMenu()
    {
        ShopPanel.SetActive(true);
    }

    public void quitShopMenu()
    {
        ShopPanel.SetActive(false);
    }
}
