using UnityEngine;
using System.Collections;

public class FinishText : MonoBehaviour {

	private bool isActive = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!isActive) return;

		transform.localScale += new Vector3 (0.15f, 0.15f, 0.0f);

		if (transform.localScale.x >= 3) {
			StartCoroutine ("WaitFunction");
			isActive = false;
		}
	}

	IEnumerator WaitFunction () {
		yield return new WaitForSeconds (1);
		Time.timeScale = 0;
		GameObject.Find ("FinishManager").GetComponent<FinishManager> ().ShowResult ();
	}
}
