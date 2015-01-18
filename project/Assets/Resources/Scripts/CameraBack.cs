using UnityEngine;
using System.Collections;

public class CameraBack : MonoBehaviour {
//========================================================================================
// 定数
//========================================================================================
	
	
//========================================================================================
// 変数
//========================================================================================
	//--public----------------------
	
	
	//--pirvate---------------------
	private GameObject m_backGround;
	private int m_textureNum;
	private float m_backHeight;
	
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
		m_backGround = Resources.Load ("Prefabs/Objects/BackGround") as GameObject;
		m_textureNum = 0;
		m_backHeight = m_backGround.transform.localScale.y;

		GameObject obj;
		obj = Instantiate (m_backGround) as GameObject;
		obj.GetComponent<GameBackground>().ChangeMaterial(m_textureNum);
	}
	
	//--------------------------------------------------------
	// 更新処理
	//--------------------------------------------------------
	void Update () 
	{
		// メインカメラより遅いスクロール
		Vector3 mainPos = Camera.main.transform.position;
		mainPos.y /= 9.0f;
		gameObject.transform.position = mainPos;
		int counter = (int)((mainPos.y + 20.0f) / m_backHeight);
		if(counter > m_textureNum)
		{
			GameObject obj;
			m_textureNum=counter;

			obj = Instantiate(m_backGround, new Vector3(0.0f, m_textureNum * m_backHeight, 0.0f), Quaternion.identity) as GameObject;
			if(m_textureNum > 4) 	obj.GetComponent<GameBackground>().ChangeMaterial(4);
			else  					obj.GetComponent<GameBackground>().ChangeMaterial(m_textureNum);
		}
	}
}
