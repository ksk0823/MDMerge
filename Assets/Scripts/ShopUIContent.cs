using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopUIContent : MonoBehaviour
{
    // Start is called before the first frame update
    public Image[] images;
    public TextMeshProUGUI[] texts;
    public Button button;
    [Header("Shop Item Info")]
    public int index;
    public string contentName;
    public int money;
    public int energy;
}
