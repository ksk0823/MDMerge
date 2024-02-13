using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderObject : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public int OrderNum;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = DataCtrl.instance.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
