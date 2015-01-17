using UnityEngine;
using System.Collections;

public class ShockWaver : MonoBehaviour {

//========================================================================================
// 定数
//========================================================================================
	
	
//========================================================================================
// 変数
//========================================================================================
	//--public----------------------
	public float m_maxPower = 4.0f;
	public float m_allCutDistance = 5.0f;
	
	//--pirvate---------------------
	private Camera m_mainCamera;
	private GameObject m_ball;
	private GameObject m_shockWaveParticle;
	
//========================================================================================
// 関数
//========================================================================================
	//--------------------------------------------------------
	// 初期化処理
	//--------------------------------------------------------
	void Start () 
	{
		m_mainCamera = Camera.main;
		m_ball = GameObject.FindGameObjectWithTag ("Ball");

		m_shockWaveParticle = Resources.Load ("Prefabs/Particles/ShockEffect") as GameObject;
	}
	
	//--------------------------------------------------------
	// 更新処理
	//--------------------------------------------------------
	void Update () 
	{
		// タッチ時の処理
		if(Input.GetMouseButtonDown(0))
		{
			// マウスのスクリーン座標をワールド座標に変換
			Vector2 mousePos = Input.mousePosition;
			Vector3 worldMousePos = m_mainCamera.ScreenToWorldPoint(
				new Vector3(mousePos.x, mousePos.y, Mathf.Abs(m_mainCamera.transform.position.z)));

			AddPower(worldMousePos);
			EffectCreate(worldMousePos);
		}
	}

	//--------------------------------------------------------
	// ボールに力を加える
	// 第一引数 : 力を発生させる起点
	//--------------------------------------------------------
	void AddPower(Vector3 worldPos)
	{
		
		Vector2 ballPos2D = SatouUtility.Vec3toVec2(m_ball.transform.position);
		Vector2 addForceVelocity = m_ball.transform.position - worldPos;
		addForceVelocity.Normalize();
		
		// ボールとタッチ位置によって移動力を変更
		float dist = Vector3.Distance(worldPos, m_ball.transform.position);
		
		float cutRatio = 1 - dist / m_allCutDistance;
		// まったく影響を及ぼさない場合は処理を抜ける
		if(cutRatio < 0.0f) return;

		float addPower = m_maxPower * cutRatio;
		addForceVelocity *= addPower;
		m_ball.GetComponent<Ball>().AddForce(addForceVelocity);			
	}

	//--------------------------------------------------------
	// エフェクトを発生させる
	//--------------------------------------------------------
	void EffectCreate(Vector3 pos)
	{
		Instantiate (m_shockWaveParticle, pos, Quaternion.identity);
	}

}
