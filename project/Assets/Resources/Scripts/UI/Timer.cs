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

	// Event
	public delegate void TimeOverEventHandler();
	public event TimeOverEventHandler OnOver;

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
			// Generate finish word
			isActive = false;
			// Call event handlers
			OnOver();
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
