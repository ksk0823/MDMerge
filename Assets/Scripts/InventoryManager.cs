using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

        loadInventory();
    }

    void loadInventory()
    {
        if (PlayerData.instance.inventory == null)
        {
            // 첫 플레이 시
            PlayerData.instance.inventory = new List<MaterialItemData>();
        }
        else
        {

            GameObject[] emptySlots = GetEmptyInventorySlots();

            // 첫 플레이가 아닐 시 기존 인벤토리 불러오기
            foreach (MaterialItemData item in PlayerData.instance.inventory)
            {
                GameObject go = Instantiate(itemPrefab, emptySlots[item.slotNumForPlayer].transform.position, Quaternion.identity);
                go.GetComponent<MaterialCtrl>().InitMaterial(generatorsData[item.categoryID].materialsData[item.id], emptySlots[item.slotNumForPlayer].transform);
            }

            PlayerData.instance.inventory.Clear();
        }
    }

    public void saveInventory() 
    {
        foreach (Slot slot in slots)
        {
            if (!(slot.item == null))
            {
                GameObject go = slot.item;
                MaterialItemData item = new MaterialItemData();
                item.id = go.GetComponent<MaterialCtrl>().material.id;
                item.categoryID = go.GetComponent<MaterialCtrl>().material.categoryID;
                item.slotNumForPlayer = slot.index;
                PlayerData.instance.inventory.Add(item);
            }
        }
    }

    GameObject[] GetEmptyInventorySlots() 
    {
        List<GameObject> emptySlots = new List<GameObject>();

        foreach(Slot s in slots)
        {
            if (s.item == null)
                emptySlots.Add(s.gameObject);
        }

        emptySlots.Sort((x, y) => x.GetComponent<Slot>().index.CompareTo(y.GetComponent<Slot>().index));

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
            if (PlayerData.instance.energy <= 0)
            {
                return;
            }
            else { PlayerData.instance.energy--; }

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
            if (PlayerData.instance.energy <= 0)
            {
                return;
            }
            else { PlayerData.instance.energy--; }

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

    public GameObject[] Myitems()
    {
        List<GameObject> myItems = new List<GameObject>();

        foreach (Slot s in slots)
        {
            if (s.item != null)
                myItems.Add(s.item.gameObject);
        }
        if (myItems.Count == 0) return null;
        else return myItems.ToArray();
    }
}
