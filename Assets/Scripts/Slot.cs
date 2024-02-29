using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
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

    public void OnDrop(PointerEventData eventData) 
    {
        if (!item)
        {
            DragManager.beingDraggedItem.transform.SetParent(transform);
        }
        else 
        {
            MaterialCtrl dragItem = DragManager.beingDraggedItem.GetComponent<MaterialCtrl>();
            MaterialCtrl soltItem = item.GetComponent<MaterialCtrl>();

            GeneratorItemData tempMaterialCategory = InventoryManager.Instance.generatorsData[dragItem.material.categoryID];
            MaterialItemData checkingMaterialID = tempMaterialCategory.materialsData[dragItem.material.id];

            if (checkingMaterialID.id == tempMaterialCategory.materialsData.Capacity-1)
            {
                DragManager.beingDraggedItem.transform.SetParent(transform);

                item.transform.SetParent(DragManager.beingDraggedItem.GetComponent<DragManager>().startParent);

                return;
            }

            if (dragItem.material.id == soltItem.material.id)
            {
                int backupCategoryID = dragItem.material.categoryID;
                int backupID = dragItem.material.id;
                Destroy(dragItem.gameObject);
                Destroy(soltItem.gameObject);

                InventoryManager.Instance.CreateUpgradeItem(backupCategoryID, backupID + 1, transform);
            }
            else 
            {
                DragManager.beingDraggedItem.transform.SetParent(transform);

                item.transform.SetParent(DragManager.beingDraggedItem.GetComponent<DragManager>().startParent);
            }
        }
    }

}
