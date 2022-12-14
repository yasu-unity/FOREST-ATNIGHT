using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public int stageNo; //ステージナンバー
    public int continueNum; //コンティニューナンバー
    public static GameManager instance;//どこからでもアクセスできる

    [SerializeField] Text scoreText;
    [SerializeField] GameObject GameOverText;

    int score = 0;
    void Start()
    {

        scoreText.text = "SCORE:" + GameData.instance.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddScore(int val)
    {
        GameData.instance.score += val;
        scoreText.text = "SCORE:" + GameData.instance.score.ToString();
    }
    public void GoBackStageSelect()
    {
        SceneManager.LoadScene("StageSelect");


    }
    public void GoBackTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
    public void Continue(int stageNo)
    {
        SceneManager.LoadScene("GameScene" + stageNo);
    }
    //バックボタンを押した
    /*public void PushBackButton()
    {
        GoBackStageSelect();
    }*/
    //ステージクリア処理
    public void StageClear()
    {
        //セーブデータ更新
        if (PlayerPrefs.GetInt("CLEAR", 0) < stageNo)
        {
            //セーブされているステージNoより今のステージNoが大きければ
            PlayerPrefs.SetInt("CLEAR", stageNo);	//ステージナンバーを記録
        }
        //3秒後にステージセレクト画面へ
        Invoke("GoBackStageSelect", 3.0f);

    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }
    public void GameOver()
    {
        GameOverText.SetActive(true);
    }
}
