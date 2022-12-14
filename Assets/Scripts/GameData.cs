using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public int stageNo; //�X�e�[�W�i���o�[
    public int continueNum; //�R���e�B�j���[�i���o�[
    public int score;
    public static GameData instance;
    //�Q�[�����ŃV�[�����܂����Ŏg���������ʂ̃f�[�^
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
