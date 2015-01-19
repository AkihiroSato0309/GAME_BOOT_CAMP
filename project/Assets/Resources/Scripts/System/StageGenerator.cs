using UnityEngine;
using System.Collections;

public class StageGenerator : MonoBehaviour {
//========================================================================================
// 定数
//========================================================================================
	
	
//========================================================================================
// 変数
//========================================================================================
	//--public----------------------
	public float m_appearRenge = 15.0f;				// ブロック出現距離
	public float m_appearFrequency = 0.002f;		// 出現頻度上昇値
	public float m_feverRenge = 4.0f;				// フィーバー時の出現距離
	public int m_changePercent = 5;

	//--pirvate---------------------
	private CoinUI m_coinUI;
	private FeverGauge m_feverGuage;
	private GameObject m_block;
	private GameObject m_coin;
	private float m_scoreHolder;
	private int m_createBlockRatio;
	private int m_generateCounter;
	
	
//========================================================================================
// プロパティ。イベント
//========================================================================================
	private delegate void ExecuteUpdateEventHandler();
	private ExecuteUpdateEventHandler executeUpdate;
	
	
//========================================================================================
// 関数
//========================================================================================
	//--------------------------------------------------------
	// 初期化処理
	//--------------------------------------------------------
	void Start () 
	{
		m_block = Resources.Load ("Prefabs/Objects/Block") as GameObject;
		m_coin = Resources.Load ("Prefabs/Objects/Coin") as GameObject;
		executeUpdate = UpdateNormal;
		m_generateCounter = (int)(m_scoreHolder / m_appearRenge);
		m_createBlockRatio = 50;
	}
	
	//--------------------------------------------------------
	// 更新処理
	//--------------------------------------------------------
	void Update () 
	{
		// 実行関数
		executeUpdate ();
	}

	//--------------------------------------------------------
	// 通常時の更新処理
	//--------------------------------------------------------
	void UpdateNormal()
	{
		int count = (int)(m_scoreHolder / m_appearRenge);
		if(count > m_generateCounter)
		{
			// 出現オブジェクトの決定
			if(Random.Range(0, 100) < m_createBlockRatio)
			{
				m_createBlockRatio -= m_changePercent;
				ObjectGenerate(m_block);
			}
			else
			{
				m_createBlockRatio += m_changePercent;
				ObjectGenerate(m_coin);
			}

			m_appearRenge -= (m_appearRenge > 7.0f)? m_appearFrequency : 0.0f;
			m_generateCounter = count;
		}
		m_scoreHolder = Camera.main.transform.position.y;
	}


	//--------------------------------------------------------
	// フィーバー時の更新処理
	//--------------------------------------------------------
	void UpdateFever()
	{
		int count = (int)(m_scoreHolder / m_feverRenge);
		if(count > m_generateCounter)
		{
			ObjectGenerate(m_block);
			m_generateCounter = count;
		}
	}

	//--------------------------------------------------------
	// コイン生成時に必要なコインUIをセットする
	//--------------------------------------------------------
	public void SetCoinUI(CoinUI coinUI)
	{
		m_coinUI = coinUI;
	}

	//--------------------------------------------------------
	// コイン生成時に必要なフィーバーゲージをセットする
	//--------------------------------------------------------
	public void SetFeverGuage(FeverGauge feverGuage)
	{
		m_feverGuage = feverGuage;
	}

	//--------------------------------------------------------
	// スコアを取得する
	//--------------------------------------------------------
	public void SetScore(float score)
	{
		m_scoreHolder = score;
	}

	//--------------------------------------------------------
	// モード変更
	//--------------------------------------------------------
	public void ChangeMode()
	{
		if(executeUpdate == UpdateNormal)
		{
			m_generateCounter = (int)(m_scoreHolder / m_feverRenge);
			executeUpdate = UpdateFever;
		}
		else
		{
			m_generateCounter = (int)(m_scoreHolder / m_appearRenge);
			executeUpdate = UpdateNormal;
		}
	}

	//--------------------------------------------------------
	// オブジェクトを生成する
	//--------------------------------------------------------
	void ObjectGenerate(GameObject obj)
	{
		Vector3 appearPos = new Vector3(Random.Range(-4.0f, 4.0f), m_scoreHolder + 10.0f, 0.0f);
		GameObject inst = Instantiate(obj, appearPos, Quaternion.identity) as GameObject;

		if (inst.tag == "Coin") {
			Coin coin = inst.GetComponent<Coin> ();
			coin.OnCollidesWithBall += m_coinUI.AddCoin;
			coin.OnCollidesWithBall += m_feverGuage.AddGauge;
		} 
		else if (inst.tag == "Block") {
			Block block = inst.GetComponent<Block> ();
			block.OnDied += m_coinUI.AddCoin;
			block.OnDied += m_feverGuage.AddGauge;
		}
	}

}
