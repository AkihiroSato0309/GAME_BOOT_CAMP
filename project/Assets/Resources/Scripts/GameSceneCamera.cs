﻿//========================================================================================
//
// 製作者 :　
//
//========================================================================================

using UnityEngine;
using System.Collections;

public class GameSceneCamera : MonoBehaviour {
	//========================================================================================
	// 定数
	//========================================================================================
	
	
	//========================================================================================
	// 変数
	//========================================================================================
	//--public----------------------
	public GameObject ball;

	
	//--pirvate---------------------
	
	
	//========================================================================================
	// プロパティ。イベント
	//========================================================================================
	public delegate void CameraMoveEventHandler( float cameraPosY );
	public event CameraMoveEventHandler OnMoved;						// カメラ上昇イベント

	
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
		// ボールが存在していなければ何もしない
		if (ball == null) return;
		
		// ボールとカメラ間のy方向のギャップ（距離）を取得
		// OFFSETは, スクロール開始の基準距離を変更できる. 0で画面中心
		const float OFFSET = 3.0f;
		float distance = this.ball.transform.position.y - (this.transform.position.y + OFFSET);
		
		// ボールがカメラより上にあれば（ボールが画面中央より上へ跳んでいたら）
		if (distance > 0.0f)
		{
			// カメラのy座標を, ボールのy座標と一致させる（ボールに追従する）
			Vector3 position = this.transform.position;
			position.y += distance;
			this.transform.position = position;
			
			// イベントハンドラの呼び出し
			if (OnMoved != null) this.OnMoved (position.y);
		}
	}
}
