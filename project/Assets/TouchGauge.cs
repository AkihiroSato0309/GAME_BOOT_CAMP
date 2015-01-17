using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TouchGauge : MonoBehaviour {

	public int recoverGaugeFrame;
	private float recoverNum;
	private float currentAmount = 0.0f;

	// Use this for initialization
	void Start () {
		recoverNum = 1.0f / recoverGaugeFrame;
	}
	
	// Update is called once per frame
	void Update () {
		currentAmount += recoverNum;
		gameObject.GetComponent<Image> ().fillAmount = currentAmount;

		if (currentAmount >= 1.0f) {
			// Add touch stack gauge
			Destroy (gameObject);
		}
	}
}
