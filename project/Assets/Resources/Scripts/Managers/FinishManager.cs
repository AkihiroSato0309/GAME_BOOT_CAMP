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
		Time.timeScale = 0;
		StartCoroutine ("CreateDisplayResult");
	}

	IEnumerator CreateDisplayResult () {
		GameObject resultSceneCanvas = Instantiate (Resources.Load ("Prefabs/UI/ResultSceneCanvas")) as GameObject;
		resultSceneCanvas.name = resultSceneCanvas.name.Replace ("(Clone)", "");
		resultSceneCanvas.SetActive (false);
		resultSceneCanvas.GetComponent<Canvas> ().worldCamera = GameObject.Find ("UICamera").camera;
		yield return null;
		resultSceneCanvas.SetActive (true);
	}
}
