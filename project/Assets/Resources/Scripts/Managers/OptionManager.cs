using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void DisplayOption () {
		GameObject.Find ("Timer").GetComponent<Timer> ().StopUpdate ();
		GameObject.Find ("TouchRecoverGauge").GetComponent<TouchRecoverGauge> ().StopUpdate();
		StartCoroutine ("CreateDisplayOption");
	}

	IEnumerator CreateDisplayOption () {
		GameObject optionSceneCanvas = Instantiate (Resources.Load ("Prefabs/UI/OptionSceneCanvas")) as GameObject;
		optionSceneCanvas.name = optionSceneCanvas.name.Replace ("(Clone)", "");
		optionSceneCanvas.SetActive (false);
		optionSceneCanvas.GetComponent<Canvas> ().worldCamera = GameObject.Find ("UICamera").camera;
		yield return null;
		optionSceneCanvas.SetActive (true);
		GameObject.Find ("ContinueButton").GetComponent<Button> ().onClick.AddListener(ContinueGame);
		GameObject.Find ("MenuButton").GetComponent<Button> ().onClick.AddListener(GameObject.Find ("SceneChanger").GetComponent<SceneChanger> ().ChangeToMenuScene);
	}

	public void ContinueGame () {
		GameObject.Find ("Timer").GetComponent<Timer> ().StartUpdate ();
		GameObject.Find ("TouchRecoverGauge").GetComponent<TouchRecoverGauge> ().StartUpdate();
		Destroy (GameObject.Find ("OptionSceneCanvas").gameObject);
	}
}
