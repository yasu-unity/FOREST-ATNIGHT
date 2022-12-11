using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpOakManager : MonoBehaviour
{
    [SerializeField] LayerMask terrainLayer;
    private Rigidbody2D rigidbody2D ; //Rigidbody2D
    private float jumpPower = 600;//ジャンプの力
    private bool canJump=false;//ブロックに設置してるか否か

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();//自分についてるrididbodyを取得
    }

    // Update is called once per frame
    void Update()
    {
        canJump = 
			Physics2D.Linecast (transform.position - (transform.right * 0.3f), 
				transform.position - (transform.up * 0.1f), terrainLayer) ||
			Physics2D.Linecast (transform.position + (transform.right * 0.3f),
				transform.position - (transform.up * 0.1f), terrainLayer);
    }    
    

    public void JumpMove()
    {
        //もしぶつかったゲームオブジェクトのタグがPlayerだった場合
        if(canJump==true)
        {
            rigidbody2D.AddForce(Vector2.up* jumpPower);
        }
    }
    void FixedUpdate()
    {
        JumpMove();
    }
}
        

