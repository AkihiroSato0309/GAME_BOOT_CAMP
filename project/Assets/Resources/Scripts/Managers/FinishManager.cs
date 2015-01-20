using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FinishManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ShowResult () {
		StartCoroutine ("CreateDisplayResult");
	}

	IEnumerator CreateDisplayResult () {
		int meter = GameObject.Find ("Meter").GetComponent<Meter> ().GetMeter ();
		int coin = GameObject.Find ("Coin").GetComponent<CoinUI> ().GetCoinNum ();
		DataSaver.SaveData ( meter, coin );
		GameObject.Find ("Timer").GetComponent<Timer> ().StopUpdate ();
		GameObject.Find ("TouchRecoverGauge").GetComponent<TouchRecoverGauge> ().StopUpdate();
		GameObject resultSceneCanvas = Instantiate (Resources.Load ("Prefabs/UI/ResultSceneCanvas")) as GameObject;
		resultSceneCanvas.name = resultSceneCanvas.name.Replace ("(Clone)", "");
		GameObject.Find ("MenuButton").GetComponent<Button> ().onClick.AddListener (GameObject.Find ("MenuButton").GetComponent<ResultMenuButton> ().ChangeToMenuScene);
		resultSceneCanvas.SetActive (false);
		resultSceneCanvas.GetComponent<Canvas> ().worldCamera = GameObject.Find ("UICamera").camera;
		yield return null;
		resultSceneCanvas.SetActive (true);
	}
}
