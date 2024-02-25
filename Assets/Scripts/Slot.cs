using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public GameObject item
    {
        get 
        {
            if (transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }

    public void OnDrop() 
    {
        if (!item)
        {
            DragManager.beingDraggedItem.transform.SetParent(transform);
        }
        else 
        {
            
        }
    }
}
