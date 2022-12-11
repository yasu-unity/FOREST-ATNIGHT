using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScript : MonoBehaviour
{
    // 背景のゲームオブジェクトを設定するpublicインスタンスメンバ
	// 等間隔に並べたときに自然につながるように加工した画像を使用して下さい。
	public GameObject background;

	// 背景の配列を記憶するGameObject型配列のインスタンスメンバ
	GameObject[] list;

	void Start()
	{
		// 背景のスプライトの横幅を取得
		Sprite sp = background.GetComponent<SpriteRenderer>().sprite;
		float imgWidth = sp.bounds.size.x;

		// インスタンスメンバlistに配列を割り当て
		//(15つあればスクロールに過不足無く対応できるので15つ用意します) 
		list = new GameObject[15];

		// listの中のすべての要素に対して処理を繰り返す
		for (int I = 0; I < list.Length; ++I)
		{
			// 新しい背景を生成
			GameObject tmp = Instantiate(background);

			//背景を配置
			tmp.transform.position = new Vector3(imgWidth * I, 1.7f, 0);

			// listの要素に背景を割り当て
			list[I] = tmp;
		}
	}



	void LateUpdate()
	{
		// 背景のスプライトの横幅を取得
		Sprite sp = background.GetComponent<SpriteRenderer>().sprite;
		float imgWidth = sp.bounds.size.x;

		//メインカメラを取得
		Camera camera = Camera.main;

		//カメラの座標をcPosに入れておく
		Vector3 cPos = camera.transform.position;

		// 用意した背景画像を並べる
		for (int I = 0; I < list.Length; ++I)
		{
			//I番目の背景を取得
			GameObject obj = list[I];

			//背景画像がカメラよりも十分に左側にあるかどうかを判定する
			//(ここではスプライトの横幅の1.5倍の大きさ)
			if (obj.transform.position.x <= cPos.x - imgWidth * 1.5f)
			{
				//画像を先頭まで移動させる
				Vector3 pos = obj.transform.position;
				pos.x += imgWidth * list.Length;
				obj.transform.position = pos;
			}

		}

	}
}
