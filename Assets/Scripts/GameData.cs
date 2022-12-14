using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public int stageNo; //ステージナンバー
    public int continueNum; //コンティニューナンバー
    public int score;
    public static GameData instance;
    //ゲーム内でシーンをまたいで使いたい共通のデータ
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);

        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
