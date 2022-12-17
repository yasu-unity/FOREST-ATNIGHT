using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuePoint : MonoBehaviour
{
    [Header("コンティニュー番号")]public int continueNum;
    [Header("プレーヤー判定")]public PlayerTriggerCheck trigger;

    
}


/*private bool on;
    // Start is called before the first frame update
    void Start()
    {
        if(trigger==null)
        {
            Debug.Log("インスペクターの設定が足りません");
            Destroy(this);

        }
    }

    // Update is called once per frame
    void Update()
    {
        //プレーヤーが範囲内に入ったら
        if(trigger.isOn && !on)
        {
            GameManager.instance.continueNum=continueNum;
            on=true;
        }
    }*/