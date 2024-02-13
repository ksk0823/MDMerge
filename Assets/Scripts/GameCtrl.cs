using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateOrderObject()
    {
        JemObject jemObject = Instantiate(jemObjectPrefab, _createPos, Quaternion.identity, jemObjectTr).GetComponent<JemObject>();
        int jemCode = RandomFunction.RandomFlag(Jem.percents);
        jemObject.jemCode = jemCode;

        DataCtrl.instance.playerData.jems[jemCode]++;
    }
}
