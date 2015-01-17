using UnityEngine;
using System.Collections;

public class BlockGenerator : MonoBehaviour {
//========================================================================================
// 定数
//========================================================================================
	
	
//========================================================================================
// 変数
//========================================================================================
	//--public----------------------
	public float m_appearRenge;				// ブロック出現距離
	public float m_appearAxel;				// 出現頻度上昇値
	public float m_feverRenge;				// フィーバー時の出現距離					

	//--pirvate---------------------
	private GameObject m_block;
	private float m_scoreHolder;
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
		m_block = Resources.Load ("") as GameObject;
		executeUpdate = UpdateNormal;
		m_generateCounter = m_scoreHolder / m_appearRenge;
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
			BlockGenerate();
		}
	}


	//--------------------------------------------------------
	// フィーバー時の更新処理
	//--------------------------------------------------------
	void UpdateFever()
	{
		int count = (int)(m_scoreHolder / m_feverRenge);
		if(count > m_generateCounter)
		{
			BlockGenerate();
		}
	}

	//--------------------------------------------------------
	// スコアを取得する
	//--------------------------------------------------------
	public void SetScore(float score)
	{
		m_scoreHolder = score;
	}

	//--------------------------------------------------------
	// ブロックを生成する
	//--------------------------------------------------------
	public void ChangeMode()
	{
		if(executeUpdate == UpdateNormal)
		{
			executeUpdate = UpdateFever;
		}
		else
		{
			executeUpdate = UpdateFever;
		}

		m_generateCounter = (int)(m_scoreHolder / m_feverRenge);
	}

	//--------------------------------------------------------
	// ブロックを生成する
	//--------------------------------------------------------
	void BlockGenerate()
	{
		Vector3 appearPos = new Vector3(Random.Range(-5.0f, 5.0f), m_scoreHolder + 10.0f, 0.0f);
		Instantiate(m_block, appearPos, Quaternion.identity);
	}

}
