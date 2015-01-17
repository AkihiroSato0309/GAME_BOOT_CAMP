using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FeverGauge : MonoBehaviour {

	[SerializeField]
	private int requiredNumForStartingFever;
	private float oneGaugeNum;
	private float currentAmount = 0.0f;
	private const float MAX_AMOUNT = 1.0f;

	// Use this for initialization
	void Start () {
		oneGaugeNum = MAX_AMOUNT / requiredNumForStartingFever;
	}
	
	// Update is called once per frame
	void Update () {
		GameObject.Find ("FeverGauge").GetComponent<Image> ().fillAmount = currentAmount;
	}

	// Call this function when player ball get a coin
	public void IncreaseGauge () {
		currentAmount += oneGaugeNum;
	}
}
