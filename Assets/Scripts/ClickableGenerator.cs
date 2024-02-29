using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickableGenerator : MonoBehaviour
{
    int count;
    Image image;
    public Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        image = GetComponent<Image>();
    }

    public void updateCount(int categoryID) 
    {
        if (count < sprites.Length-1)
        {
            count++;
            image.sprite = sprites[count];
        }
        else 
        {
            if (categoryID == 9)
            {
                InventoryManager.Instance.CreateItem(categoryID);
            }
            if (categoryID == 10 || categoryID == 11) 
            {
                InventoryManager.Instance.CreateItemTwoVersion(categoryID);
            }
            count = 0;
            image.sprite = sprites[count];
            
        }

    }
}
