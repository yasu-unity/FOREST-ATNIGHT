using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCtl : MonoBehaviour
{
    //public static StageCtl instance= null;
    [Header("プレイヤーゲームオブジェクト")]public GameObject playerObj;
    [Header("コンティニュー位置")]public GameObject []continuePoint;
    private PlayerManager playerManager;

    private void Start()
    {
        playerObj.transform.position = continuePoint[GameData.instance.continueNum].transform.position;

        playerManager = playerObj.GetComponent<PlayerManager>();
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Continue")
        {
            if (continuePoint.Length > GameData.instance.continueNum)
            {
                playerObj.transform.position = continuePoint[GameData.instance.continueNum].transform.position;
            }
        }
    }
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