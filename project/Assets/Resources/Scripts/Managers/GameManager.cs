//========================================================================================
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
		
		// カメラスクリプト取得
		GameSceneCamera cameraScript = camera.GetComponent<GameSceneCamera> ();
		
		// 各UIスクリプト取得
		Meter meterUIScript = canvas.transform.FindChild ("Meter").GetComponent<Meter> ();
		CoinUI coinUIScript = canvas.transform.FindChild ("CoinUI").FindChild("Coin").GetComponent<CoinUI> ();
		
		// ステージ生成機スクリプト取得
		StageGenerator stageGeneratorScript = stageGenerator.GetComponent<StageGenerator> ();
		
		// カメラスクリプトにオブジェクトとイベントハンドラを設定
		cameraScript.ball = ball;
		cameraScript.OnMoved += meterUIScript.SetMeter;
		cameraScript.OnMoved += stageGeneratorScript.SetScore;

		// ステージ生成スクリプトにを設定
		stageGeneratorScript.SetCoinUI (coinUIScript); 
	}

	//--------------------------------------------------------
	// ボール生成処理
	//--------------------------------------------------------
	private GameObject CreateBall()
	{
		// TODO: あとでSwitch文に変えるボールを生成
		GameObject ball = Instantiate (Resources.Load (@"Prefabs/Objects/Ball/Ball")) as GameObject;
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
	private void EndGame()
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
