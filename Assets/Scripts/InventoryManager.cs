using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<GeneratorItemData> generatorsData = new List<GeneratorItemData> ();

    Slot[] slots;

    public Transform innerPanelTransform;

    public GameObject itemPrefab;

    void Start()
    {
        Instance = this;

        slots = innerPanelTransform.GetComponentsInChildren<Slot>();
    }

    GameObject[] GetEmptyInventorySlots() 
    {
        List<GameObject> emptySlots = new List<GameObject>();

        foreach(Slot s in slots)
        {
            if (s.item == null)
                emptySlots.Add(s.gameObject);
        }

        if (emptySlots.Count == 0) 
        {
            return null;
        } else { return emptySlots.ToArray(); }
    }

    public void CreateItem(int categoryID)
    {
        GameObject[] emptySlots = GetEmptyInventorySlots();

        if (emptySlots != null)
        {
            int randomNum = Random.Range(0, emptySlots.Length);
            
            GameObject go = Instantiate(itemPrefab, emptySlots[randomNum].transform.position, Quaternion.identity);
            go.GetComponent<MaterialCtrl>().InitMaterial(generatorsData[categoryID].materialsData[0], emptySlots[randomNum].transform);
        }
    }

    public void CreateItemTwoVersion(int categoryID)
    {
        GameObject[] emptySlots = GetEmptyInventorySlots();

        int randomCategoryID = Random.Range(categoryID, categoryID+2);

        if (emptySlots != null)
        {
            int randomNum = Random.Range(0, emptySlots.Length);

            GameObject go = Instantiate(itemPrefab, emptySlots[randomNum].transform.position, Quaternion.identity);
            go.GetComponent<MaterialCtrl>().InitMaterial(generatorsData[randomCategoryID].materialsData[0], emptySlots[randomNum].transform);
        }
    }

    public void CreateUpgradeItem(int categoryId, int newNumber, Transform newParent)
    {
        GameObject go = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
        go.GetComponent<MaterialCtrl>().InitMaterial(generatorsData[categoryId].materialsData[newNumber], newParent);
       
    }
    
}
