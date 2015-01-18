﻿//========================================================================================
//
// 製作者 :　新宮　悠輔
//
//========================================================================================

using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

//========================================================================================
// 変数
//========================================================================================
    //--public----------------------
    public Material[] mat = new Material[3];    //ブロックのマテリアル
    //--private----------------------
    public int hitCount;                       //ブロック衝突回数カウンター
	//--event------------------------
	public delegate void DeathEventHandler();
	public event DeathEventHandler OnDied;

//========================================================================================
// 関数
//========================================================================================
    //--------------------------------------------------------
    // 初期化処理
    //--------------------------------------------------------
	void Start () {                   //ヒットカウント初期化
        renderer.material = mat[2];     //ブロックに最初のマテリアル指定

	}

    //--------------------------------------------------------
    // 更新処理
    //--------------------------------------------------------
	void Update () {
	    
	}

    //--------------------------------------------------------
    // ボール衝突処理
    //--------------------------------------------------------
	void OnCollisionEnter2D(Collision2D col)
    {
		// ボールだったら
		if (col.gameObject.tag == "Ball")
		{			
			hitCount--;     //ヒットカウントを減らす

			switch(hitCount){
			case 0:     //ブロック消滅, イベントハンドラ呼び出し, エフェクト生成
				if (OnDied != null) this.OnDied();
				GameObject effect = Instantiate( Resources.Load( @"Prefabs/Particles/BlockBrake" ) ) as GameObject;
				effect.transform.position = this.transform.position;
				Destroy(this.gameObject);
				break;
			case 1:     //ブロック衝突回数2回目
				renderer.material = mat[0];
				break;
			case 2:     //ブロック衝突回数1回目
				renderer.material = mat[1];
				break;
			}
		}    
    }
}
