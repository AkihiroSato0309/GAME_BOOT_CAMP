using UnityEngine;
using System.Collections;

public class UIAnimals : MonoBehaviour {

//========================================================================================
// 定数
//========================================================================================
	
	
//========================================================================================
// 変数
//========================================================================================
	//--public----------------------
	
	
	//--pirvate---------------------
	private Sprite[] m_animalSprites;
	private Vector3[] m_animalPos;
	private GameObject m_animalSpriteObj;
	private GameObject[] m_createObjects;
	
//========================================================================================
// プロパティ。イベント
//========================================================================================
	
	
//========================================================================================
// 関数
//========================================================================================
	//--------------------------------------------------------
	// 初期化
	//--------------------------------------------------------
	void Start () 
	{
		SpriteLoad ();
		SetIconPositions ();
		m_animalSpriteObj = Resources.Load ("Prefabs/Objects/AnimalIcon") as GameObject;

		StartCoroutine ("IconGenerate");
	}

	//--------------------------------------------------------
	// 更新処理
	//--------------------------------------------------------
	void Update () 
	{
		
	}

	//--------------------------------------------------------
	// 使用スプライトをロード
	//--------------------------------------------------------
	void SpriteLoad () 
	{
		m_animalSprites = new Sprite[(int)AnimalManager.eAnimals.last];
		m_animalSprites [0] = Resources.Load ("Textures/Ui/AnimalSprite/Gorilla") as Sprite;
		m_animalSprites [1] = Resources.Load ("Textures/Ui/AnimalSprite/Lion") as Sprite;
		m_animalSprites [2] = Resources.Load ("Textures/Ui/AnimalSprite/Panda") as Sprite;
		m_animalSprites [3] = Resources.Load ("Textures/Ui/AnimalSprite/Pig") as Sprite;
		m_animalSprites [4] = Resources.Load ("Textures/Ui/AnimalSprite/Rhino") as Sprite;
		m_animalSprites [5] = Resources.Load ("Textures/Ui/AnimalSprite/Tiger") as Sprite;

	}

	//--------------------------------------------------------
	// 座標をセット
	//--------------------------------------------------------
	void SetIconPositions () 
	{
		m_animalPos = new Vector3[(int)AnimalManager.eAnimals.last];
		m_animalPos [0] = new Vector3 (-3.3f, 4.7f, 0.0f);
		m_animalPos [1] = new Vector3 ( 0.0f, 4.7f, 0.0f);
		m_animalPos [2] = new Vector3 ( 3.3f, 4.7f, 0.0f);
		m_animalPos [3] = new Vector3 (-3.3f, 1.9f, 0.0f);
		m_animalPos [4] = new Vector3 ( 0.0f, 1.9f, 0.0f);
		m_animalPos [5] = new Vector3 ( 3.3f, 1.9f, 0.0f);
	}

	//--------------------------------------------------------
	// アニマルアイコンを作成
	//--------------------------------------------------------
	IEnumerator IconGenerate () 
	{
		m_createObjects = new GameObject[(int)AnimalManager.eAnimals.last];
		for(int i = 0; i < m_animalPos.Length; i++)
		{
			m_createObjects[i] = Instantiate(m_animalSpriteObj, m_animalPos[i], Quaternion.identity) as GameObject;
		}

		yield return null;

		for(int i = 0; i < m_animalPos.Length; i++)
		{
			m_createObjects[i].GetComponent<SelectAnimal>().SetSprite(m_animalSprites[i]);
		}
	}
}
