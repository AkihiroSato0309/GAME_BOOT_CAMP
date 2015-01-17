using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
//========================================================================================
// 定数
//========================================================================================
	
	
//========================================================================================
// 変数
//========================================================================================
	//--public----------------------
	public float m_maxPower = 1.0f;
	
	//--pirvate---------------------
	private Camera m_mainCamera;
	
//========================================================================================
// 関数
//========================================================================================
	//--------------------------------------------------------
	// 初期化処理
	//--------------------------------------------------------
	void Start () 
	{
		m_mainCamera = Camera.main;
	}
	
	//--------------------------------------------------------
	// 更新処理
	//--------------------------------------------------------
	void Update () 
	{
		// タッチ時の処理
		if(Input.GetMouseButtonDown(0))
		{
			Vector2 mousePos = Input.mousePosition;
			Vector3 worldMousePos = m_mainCamera.ScreenToWorldPoint(
				new Vector3(mousePos.x, mousePos.y, 0.0f));

			float dist = Vector3.Distance(worldMousePos, gameObject.transform.position);

			Vector3 addForceVelocity = gameObject.transform.position - worldMousePos;
			addForceVelocity.Normalize();
			addForceVelocity *= m_maxPower;


		}
	}
}
