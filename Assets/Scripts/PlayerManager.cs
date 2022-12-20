using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerManager : MonoBehaviour
{
    public LayerMask terrainLayer;
    private Rigidbody2D rbody; //プレーヤー制御用Rigidbody2D
    float speed;
    Animator animator;

    private const float MOVE_SPEED =3; //移動速度固定値
    private float moveSpeed; //移動速度
    private float jumpPower = 600;//ジャンプの力
    private bool goJump= false;//ジャンプしたか否か
    private bool canJump=false;//ブロックに設置してるか否か
    private bool usingButtons =false;//ボタンを押してるか否か
    

    public enum MOVE_DIR
    {
        //移動方向定義
        STOP,
        LEFT,
        RIGHT,
    };

    private MOVE_DIR moveDirection = MOVE_DIR.STOP;//移動方向
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        animator =GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        canJump = 
			Physics2D.Linecast (transform.position - (transform.right * 0.3f), 
				transform.position - (transform.up * 0.1f), terrainLayer) ||
			Physics2D.Linecast (transform.position + (transform.right * 0.3f),
				transform.position - (transform.up * 0.1f), terrainLayer);
        
        //パソコン用ボタン操作
        if(!usingButtons)
        {
            float x = Input.GetAxisRaw("Horizontal");//方向キーの取得
            animator.SetFloat("speed",Mathf.Abs(x));


            if (x == 0)
            {
                moveDirection= MOVE_DIR.STOP;
            }else{
                if(x < 0)
                {
                    moveDirection=MOVE_DIR.LEFT;
                }else{
                    moveDirection=MOVE_DIR.RIGHT;
                }
            }
            if(Input.GetKeyDown("space")){
                PushJumpButton();
            }
        }

    }
    void FixedUpdate()
    {
        //移動方向で処理を分岐
        switch(moveDirection)
        {
            case MOVE_DIR.STOP://停止
                moveSpeed=0;
                break;
            case MOVE_DIR.LEFT://左に移動
                moveSpeed=MOVE_SPEED *-1;
                transform.localScale =new Vector2(-1,1);
                break;
            case MOVE_DIR.RIGHT://右に移動
                moveSpeed=MOVE_SPEED *1;
                transform.localScale =new Vector2(1,1);
                break;

        }
        rbody.velocity= new Vector2(moveSpeed,rbody.velocity.y);

        //ジャンプ処理
        if(goJump)
        {
            rbody.AddForce(Vector2.up*jumpPower);
            goJump=false;
        }
    
    }
    //左ボタンを押した
    public void PushLeftButton()
    {
        moveDirection= MOVE_DIR.LEFT;
        usingButtons=true;//パソコン入力用
    }
    //右ボタンを押した
    public void PushRightButton()
    {
        moveDirection= MOVE_DIR.RIGHT;
        usingButtons=true;//パソコン入力用
    }
    //移動ボタンを離した
    public void ReleaseMoveButton()
    {
        moveDirection= MOVE_DIR.STOP;
        usingButtons=false;//パソコン入力用
    }
    //ジャンプボタンを押した
    public void PushJumpButton()
    {
        if(canJump)
        {
            goJump= true;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Trap")
        {
            Debug.Log("ゲームオーバー");
            Destroy(this.gameObject);
            GameManager.instance.GameOver();
        }
        if(collision.gameObject.tag=="Finish")
        {
            Debug.Log("ゲームクリア");
            //collision.gameObject.GetComponent<GameManager>().StageClear();
            //gameManager.StageClear();
            GameManager.instance.StageClear();
        }
        if(collision.gameObject.tag=="Item")
        {
            //アイテム取得
            collision.gameObject.GetComponent<ItemManager>().GetItem();
        }
        if(collision.gameObject.tag=="Enemy")
        {
            EnemyManager enemy= collision.gameObject.GetComponent<EnemyManager>();
            if(this.transform.position.y +0.2f> enemy.transform.position.y)//敵の座標より自分の座標が上だったら
            {
                //上から踏んだら
                //敵を削除
                rbody.velocity = new Vector2(rbody.velocity.x,0);
                DaethJump();
                enemy.DestroyEnemy();
            }
            else
            {
                //横からぶつかったら
                Destroy(this.gameObject);
                GameManager.instance.GameOver();

            }
        }

        if(collision.gameObject.tag=="Oak")
        {
            JumpOakManager oak= collision.gameObject.GetComponent<JumpOakManager>();
            {
                Destroy(this.gameObject);
                GameManager.instance.GameOver();
            }
        }
        

    }
    void DaethJump()
    {
        goJump= true;
    }
    
    /*void PlsyerDeath()
    {
        gameManager.GameOver();
    }*/
}
