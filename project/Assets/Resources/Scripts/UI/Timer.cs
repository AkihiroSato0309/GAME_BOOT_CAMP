using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

	[SerializeField]
	private int second;
	private int count = 60;
	private int COUNT_MIN = 0;
	private int COUNT_MAX = 60;
	private bool isActive = true;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (!isActive) return;

		if (--count <= COUNT_MIN) {
			--second;
			count = COUNT_MAX;
		}

		if (second <= COUNT_MIN) {
			Instantiate (Resources.Load ("Prefabs/UI/Finish"));
			isActive = false;
		}

		gameObject.GetComponent<Text> ().text = second.ToString ();
	}

	public void StopUpdate () {
		isActive = false;
	}

	public void StartUpdate () {
		isActive = true;
	}
}
