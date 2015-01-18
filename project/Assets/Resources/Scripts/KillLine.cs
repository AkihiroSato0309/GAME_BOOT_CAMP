﻿//========================================================================================
//
// 製作者 : 大榮圭祐
//
//========================================================================================

using UnityEngine;
using System.Collections;

public class KillLine : MonoBehaviour {
	//========================================================================================
	// 定数
	//========================================================================================
	
	
	//========================================================================================
	// 変数
	//========================================================================================
	//--public----------------------
	
	
	//--pirvate---------------------
	

	//========================================================================================
	// プロパティ。イベント
	//========================================================================================
	//public delegate void KillingBallEventHandler();
	//public event KillingBallEventHandler OnKilledBall;


	//========================================================================================
	// 関数
	//========================================================================================
	//--------------------------------------------------------
	// 初期化処理
	//--------------------------------------------------------
	void Start () 
	{
		
	}
	
	//--------------------------------------------------------
	// 更新処理
	//--------------------------------------------------------
	void Update () 
	{
		
	}

	//--------------------------------------------------------
	// 衝突時処理
	//--------------------------------------------------------
	private void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("KillLineが" + other.gameObject.tag + "と衝突");

		// 壁だったら, 何もしない
		if (other.gameObject.tag == "Wall") return;
		
		// ボールだったら, ボールを非表示にする
		if (other.gameObject.tag == "Ball")
		{
			KillBall( other.gameObject ); 
		}
		// それ以外のオブジェクトなら, オブジェクトを削除
		else
		{
			Destroy(other.gameObject);
			Debug.Log("削除対象オブジェクトであったため、KillLineはオブジェクトを削除");
		}
	}

	//--------------------------------------------------------
	// ボール削除処理
	//--------------------------------------------------------
	private void KillBall( GameObject ball )
	{
		// 最初は不可視化しておく
		ball.renderer.enabled = false;

		// ボール破壊時のエフェクトを表示
		GameObject effect = Instantiate( Resources.Load( @"Prefabs/Particles/DethParticle" ) ) as GameObject;
		effect.transform.position = this.transform.position + new Vector3( 0, 2, 0 );
		
		// 死亡エフェクトが終わるときにボールをリスポーンするよう設定
		var effectScript = effect.GetComponent<AutoFuncExecute> ();
		effectScript.SetDeleteTimeAndExecuteFunc (1.0f, delegate() { RespwanBall( ball ); } );

		// イベントハンドラを呼び出す
		//if (OnKilledBall != null) this.OnKilledBall();
	}
	
	//--------------------------------------------------------
	// ボールリスポーン処理
	//--------------------------------------------------------
	private void RespwanBall( GameObject ball )
	{
		// リスポーンエフェクト終了時に, ボールを可視化, カメラと同じ場所に座標をセットするように設定
		AutoFuncExecute.ExecuteFuncWithDeleteEventHandler ShowBall = delegate() {
			ball.renderer.enabled = true;
			ball.transform.position = this.transform.parent.position + new Vector3 (0, 0, 10);
			ball.rigidbody2D.velocity = new Vector2(0.0f, 0.0f);
		};

		// リスポーンエフェクト再生
		var effect = Instantiate( Resources.Load( @"Prefabs/Particles/RespawnParticle" ) ) as GameObject;
		effect.transform.position = this.transform.parent.position + new Vector3 (0, 0, 8);

		// リスポーンエフェクトが終わるときにボールを可視化するよう設定
		var effectScript = effect.GetComponent<AutoFuncExecute> ();
		effectScript.SetDeleteTimeAndExecuteFunc (2.2f, ShowBall);
	}
}
