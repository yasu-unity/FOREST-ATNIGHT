using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScript : MonoBehaviour
{
    void Update()
    {
        //画面のどこかをクリックしたらゲーム開始
        if(Input.GetMouseButtonDown(0))
        {
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("StageSelect");
        }
    }
}
