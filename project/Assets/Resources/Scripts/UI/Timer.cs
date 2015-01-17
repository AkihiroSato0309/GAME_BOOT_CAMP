using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

	[SerializeField]
	private int second;
	private int count = 60;
	private int COUNT_MIN = 0;
	private int COUNT_MAX = 60;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (--count <= COUNT_MIN) {
			--second;
			count = COUNT_MAX;
		}

		gameObject.GetComponent<Text> ().text = second.ToString ();
	}
}
