using UnityEngine;
using System.Collections;

public class ResultMenuButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ChangeToMenuScene () {
		Time.timeScale = 1;
		GameObject.Find ("Timer").GetComponent<Timer> ().StartUpdate ();
		GameObject.Find ("TouchRecoverGauge").GetComponent<TouchRecoverGauge> ().StartUpdate();
		Application.LoadLevel ("Menu");
	}
}
