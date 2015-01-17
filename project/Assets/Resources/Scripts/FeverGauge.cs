using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FeverGauge : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.Find ("FeverGauge").GetComponent<Image> ().fillAmount = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
	}
}
