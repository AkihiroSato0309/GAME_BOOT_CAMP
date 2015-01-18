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
		// オブジェクトの初期化
		StartCoroutine("InitObjects");
	}
	
	//--------------------------------------------------------
	// 更新処理
	//--------------------------------------------------------
	void Update () 
	{
		
	}

	//--------------------------------------------------------
	// オブジェクト初期化処理
	//--------------------------------------------------------
	private IEnumerator InitObjects()
	{
		// オブジェクトのインスタンス化
		GameObject ball = CreateBall();
		GameObject shockWaver = Instantiate (Resources.Load (@"Prefabs/Objects/ShockWaver")) as GameObject;
		GameObject stageGenerator = Instantiate (Resources.Load (@"Prefabs/Objects/StageGenerator")) as GameObject;
		
		// インスタンス化が終わるよう1フレーム待つ
		yield return null;

		// ボールのスクリプト取得
		Ball ballScript = ball.GetComponent<Ball> ();

		// 衝撃波のスクリプト取得
		ShockWaver shockWaverScript = shockWaver.GetComponent<ShockWaver> ();

		// カメラスクリプト取得
		GameSceneCamera cameraScript = camera.GetComponent<GameSceneCamera> ();
		
		// 各UIスクリプト取得
		Meter meterUIScript = canvas.transform.FindChild ("Meter").GetComponent<Meter> ();
		Timer timerScript = canvas.transform.FindChild ("Timer").GetComponent<Timer> ();
		CoinUI coinUIScript = canvas.transform.FindChild ("CoinUI").FindChild("Coin").GetComponent<CoinUI> ();
		FeverGauge feverGuageScript = canvas.transform.FindChild ("FeverUI").FindChild ("FeverGauge").GetComponent<FeverGauge> ();
		TouchActionGauge touchActionGauge = canvas.transform.FindChild ("TouchActionGauge").GetComponent<TouchActionGauge> ();
		
		// ステージ生成機スクリプト取得
		StageGenerator stageGeneratorScript = stageGenerator.GetComponent<StageGenerator> ();
		
		// カメラスクリプトにオブジェクトとイベントハンドラを設定
		cameraScript.ball = ball;
		cameraScript.OnMoved += meterUIScript.SetMeter;
		cameraScript.OnMoved += stageGeneratorScript.SetScore;

		// 衝撃波スクリプトにオブジェクトを渡す
		shockWaverScript.SetTouchActionGauge (touchActionGauge);

		// ステージ生成スクリプトにオブジェクトを設定
		stageGeneratorScript.SetCoinUI (coinUIScript);
		stageGeneratorScript.SetFeverGuage (feverGuageScript);

		// タイマーにイベントハンドラを設定
		timerScript.OnOver += FinishGame;

		// フィーバーUIにイベントハンドラを設定
		feverGuageScript.OnFilled += stageGeneratorScript.ChangeMode;
		feverGuageScript.OnFilled += ballScript.ChangeMode;
		feverGuageScript.OnEmpty += stageGeneratorScript.ChangeMode;
		feverGuageScript.OnEmpty += ballScript.ChangeMode;
	}

	//--------------------------------------------------------
	// ボール生成処理
	//--------------------------------------------------------
	private GameObject CreateBall()
	{
		string animalName = "GorillaBall";

		switch (AnimalManager.s_animalID)
		{
		case AnimalManager.eAnimals.Gorilla:
			animalName = "GorillaBall";
			break;
		case AnimalManager.eAnimals.Lion:
			animalName = "LionBall";
			break;
		case AnimalManager.eAnimals.Pig:
			animalName = "PigBall";
			break;
		case AnimalManager.eAnimals.Rhino:
			animalName = "GorillaBall";
			break;
		case AnimalManager.eAnimals.Tiger:
			animalName = "GorillaBall";
			break;
		case AnimalManager.eAnimals.Panda:
			animalName = "PandaBall";
			break;
		default:
			animalName = "PandaBall";
			break;
		}

		GameObject ball = Instantiate (Resources.Load (@"Prefabs/Objects/Ball/" + animalName)) as GameObject;
		ball.name = "Ball";

		// 最初は不可視化しておく
		ball.transform.position = new Vector3 (-999, -999, -999);

		// ボールを可視化する関数を定義
		AutoFuncExecute.ExecuteFuncWithDeleteEventHandler ShowBall = delegate() {
			ball.transform.position = camera.transform.position + new Vector3 (0, 0, 10);
			ball.rigidbody2D.velocity = new Vector2(0.0f, 0.0f);
		};

		// リスポーンエフェクト再生
		var effect = Instantiate( Resources.Load( @"Prefabs/Particles/RespawnParticle" ) ) as GameObject;

		// リスポーンエフェクトが終わるときにボールを可視化するよう設定
		var effectScript = effect.GetComponent<AutoFuncExecute> ();
		effectScript.SetDeleteTimeAndExecuteFunc (2.2f, ShowBall);

		return ball;
	}

	//--------------------------------------------------------
	// ゲーム終了処理
	//--------------------------------------------------------
	private void FinishGame()
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
	private IEnumerator GoToResultScene()
	{
		// 3秒待機
		yield return new WaitForSeconds(3);
		
		// リザルトシーンへ遷移
		Application.LoadLevel("Result");
	}


}
