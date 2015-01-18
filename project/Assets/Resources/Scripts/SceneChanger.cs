using UnityEngine;
using System.Collections;

public class SceneChanger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ChangeToGameScene () {
		Application.LoadLevel ("Game");
	}

	public void ChangeToItemSelectScene () {
		Application.LoadLevel ("ItemSelect");
	}

	public void ChangeToMenuScene () {
		Application.LoadLevel ("Menu");
	}

	public void ChangeToCharacterSelect () {
		Application.LoadLevel ("CharacterSelect");
	}

	public void ChangeToOptionScene () {
		Application.LoadLevelAdditive ("Option");
	}

	public void ChangeToResultScene () {
		Application.LoadLevel ("Result");
	}

	public void ChangeToStoreScene () {
		Application.LoadLevel ("Store");
	}

	public void ChangeToTitleScene () {
		Application.LoadLevel ("Title");
	}
}
