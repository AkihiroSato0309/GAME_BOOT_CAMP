using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Meter : MonoBehaviour {

	int meter = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Text> ().text = meter.ToString() + "m";
	}

	public int GetMeter () {
		return meter;
	}

	public void SetMeter (int meter) {
		this.meter = meter;
	}
}
