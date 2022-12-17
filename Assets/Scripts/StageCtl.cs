using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCtl : MonoBehaviour
{
    //public static StageCtl instance= null;
    [Header("プレイヤーゲームオブジェクト")]public GameObject playerObj;
    [Header("コンティニュー位置")]public GameObject []continuePoint;
    private PlayerManager playerManager;




}


/*void Start()
    {
        if(playerObj!=null &&continuePoint!=null&&continuePoint.Length>0)
        {
            playerObj.transform.position=continuePoint[0].transform.position;

            playerManager = playerObj.GetComponent<PlayerManager>();
            if (playerManager == null)
            {
                Debug.Log("プレーヤーマネージャーじゃないものがアタッチされてるよ");
            }
        }
        else
        {
            Debug.Log("設定が足りてないよ");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerManager!=null)
        {
            if (continuePoint.Length > GameManager.instance.continueNum)
            {
                playerObj.transform.position = continuePoint[GameManager.instance.continueNum].transform.position;
            }
            else
            {
                Debug.Log("コンティニューポイントの設定が足りてないよ");
            }
        }
    }*/