using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderObject : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public int OrderedItemNum;
    public int[] itemCode;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = DataCtrl.instance.orders[OrderedItemNum].orderSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
