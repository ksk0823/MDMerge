using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialCtrl : MonoBehaviour
{
    public string dataName;

    SpriteRenderer sr;
    MaterialItemData material;
    bool isSelected;
    GameObject contactMaterial;

    public void InitMaterial(MaterialItemData m)
    {
        material = m;
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = material.itemImg;
    }

    private void OnMouseDown()
    {
        isSelected = true;
    }

    private void OnMouseDrag()
    {
        // 클릭 중에 마우스 포인터에 따라 위치가 바뀌도록
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    private void OnMouseUp()
    {
        isSelected = false;
        if (contactMaterial != null)
        {
            Destroy(contactMaterial);
            Destroy(gameObject);
            GameObject.Find(dataName).GetComponent<MergeManager>().MaterialsCreate(material.id + 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isSelected && material.id == collision.GetComponent<MaterialCtrl>().material.id) 
        {
            if (contactMaterial != null)
            {
                contactMaterial.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
                contactMaterial = null;
            }
            contactMaterial = collision.gameObject;
            contactMaterial.GetComponent<SpriteRenderer>().color = new Color(0.7f, 0.7f, 0.7f);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (material.id == collision.GetComponent<MaterialCtrl>().material.id)
        {
            contactMaterial.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
            contactMaterial = null;
        }
    }


}
