using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public int stageNo; //ステージナンバー
    //public int continueNum; //コンティニューナンバー
    public static GameManager instance;//どこからでもアクセスできる

    [SerializeField] Text scoreText;
    [SerializeField] GameObject GameOverText;
    public AudioClip gameoverSE;//効果音:ゲームオーバー

    private AudioSource audioSource;//オーディオソース

    int score = 0;
    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
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
        GameData.instance.continueNum = 0;

    }
    public void GoBackTitle()
    {
        SceneManager.LoadScene("TitleScene");
        GameData.instance.continueNum = 0;
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
        GameData.instance.continueNum = 0;
        //5秒後にステージセレクト画面へ
        Invoke("GoBackStageSelect", 5.0f);

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
        audioSource.PlayOneShot(gameoverSE);
    }
}
