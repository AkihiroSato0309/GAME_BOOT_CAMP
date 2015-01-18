﻿//========================================================================================
//
// 製作者 :　大榮圭祐
//
//========================================================================================

using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	//========================================================================================
	// 定数
	//========================================================================================
	
	
	//========================================================================================
	// 変数
	//========================================================================================
	//--public----------------------
	public GameObject camera;
	public GameObject canvas;
	
	//--pirvate---------------------
	
	
	//========================================================================================
	// プロパティ。イベント
	//========================================================================================
	
	
	//========================================================================================
	// 関数
	//========================================================================================
	//--------------------------------------------------------
	// 初期化処理
	//--------------------------------------------------------
	void Start () 
	{
		StartCoroutine("Momiage");

		/*
		// ステージ生成機作成
		GameObject stageGenerator = Instantiate (Resources.Load (@"Prefabs/Objects/StageGenerator")) as GameObject;

		// カメラスクリプト取得
		GameSceneCamera cameraScript = camera.GetComponent<GameSceneCamera> ();

		// 各UIスクリプト取得
		Meter meterUIScript = canvas.transform.FindChild("Meter").GetComponent<Meter> ();

		// ステージ生成機スクリプト取得
		StageGenerator stageGeneratorScript = stageGenerator.GetComponent<StageGenerator> ();

		// カメラスクリプトにイベントハンドラ設定
		cameraScript.OnMoved += meterUIScript.SetMeter;
		cameraScript.OnMoved += stageGeneratorScript.SetScore;
		*/
	}
	
	//--------------------------------------------------------
	// 更新処理
	//--------------------------------------------------------
	void Update () 
	{
		
	}

	//--------------------------------------------------------
	// ゲーム終了処理
	//--------------------------------------------------------
	public void EndGame()
	{
		// スコアを記憶する
		//float score = this.gameInfoHolder.getHeight();
		//ScoreSaver.SaveScore(score);
		
		// 少し待った後にシーン遷移を呼ぶ
		StartCoroutine("GoToResultScene");
	}
	
	//--------------------------------------------------------
	// リザルトシーン遷移処理
	//--------------------------------------------------------
	public IEnumerator GoToResultScene()
	{
		// 3秒待機
		yield return new WaitForSeconds(3);
		
		// リザルトシーンへ遷移
		Application.LoadLevel("Result");
	}

	//--------------------------------------------------------
	// リザルトシーン遷移処理
	//--------------------------------------------------------
	public IEnumerator Momiage()
	{
		// 3秒待機
		yield return null;
		
		// ステージ生成機作成
		GameObject stageGenerator = Instantiate (Resources.Load (@"Prefabs/Objects/StageGenerator")) as GameObject;
		
		// カメラスクリプト取得
		GameSceneCamera cameraScript = camera.GetComponent<GameSceneCamera> ();
		
		// 各UIスクリプト取得
		Meter meterUIScript = canvas.transform.FindChild("Meter").GetComponent<Meter> ();
		
		// ステージ生成機スクリプト取得
		StageGenerator stageGeneratorScript = stageGenerator.GetComponent<StageGenerator> ();
		
		// カメラスクリプトにイベントハンドラ設定
		cameraScript.OnMoved += meterUIScript.SetMeter;
		cameraScript.OnMoved += stageGeneratorScript.SetScore;
	}
}
