using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectedAnimal : MonoBehaviour {

//========================================================================================
// 定数
//========================================================================================
	
	
//========================================================================================
// 変数
//========================================================================================
	//--public----------------------
	
	
	//--pirvate---------------------
	private AnimalManager.eAnimals m_selectedID;
	private Sprite[] m_animalSprites;
	
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
		SpriteLoad ();
		m_selectedID = AnimalManager.s_animalID;
	}
	
	//--------------------------------------------------------
	// 更新処理
	//--------------------------------------------------------
	void Update () 
	{
		if(m_selectedID != AnimalManager.s_animalID)
		{
			Debug.Log( m_animalSprites[(int)m_selectedID]);
			m_selectedID = AnimalManager.s_animalID;
			this.GetComponent<Image>().sprite = m_animalSprites[(int)m_selectedID];

		}
	}

	//--------------------------------------------------------
	// 使用スプライトをロード
	//--------------------------------------------------------
	void SpriteLoad () 
	{
		m_animalSprites = new Sprite[(int)AnimalManager.eAnimals.last];
		Resources.LoadAll ("Textures/Ui/AnimalSprite");
		m_animalSprites [0] = Resources.Load<Sprite> ("Textures/Ui/AnimalSprite/Gorilla") as Sprite;
		m_animalSprites [1] = Resources.Load<Sprite> ("Textures/Ui/AnimalSprite/Lion") as Sprite;
		m_animalSprites [2] = Resources.Load<Sprite> ("Textures/Ui/AnimalSprite/Panda") as Sprite;
		m_animalSprites [3] = Resources.Load<Sprite> ("Textures/Ui/AnimalSprite/Pig") as Sprite;
		m_animalSprites [4] = Resources.Load<Sprite> ("Textures/Ui/AnimalSprite/Rhino") as Sprite;
		m_animalSprites [5] = Resources.Load<Sprite> ("Textures/Ui/AnimalSprite/Tiger") as Sprite;
		Debug.Log (m_animalSprites [1]);
	}
}
