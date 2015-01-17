using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TouchGaugeStack : MonoBehaviour {

	[SerializeField]
	private int maxGaugeNum;
	[SerializeField]
	private int currentGaugeNum;
	private float oneGaugeNum;
	private float currentAmount = 1.0f;
	private const float MAX_AMOUNT = 1.0f;

	// Use this for initialization
	void Start () {
		oneGaugeNum = MAX_AMOUNT / maxGaugeNum;
	}
	
	// Update is called once per frame
	void Update () {
		currentAmount = oneGaugeNum * currentGaugeNum;
		gameObject.GetComponent<Image> ().fillAmount = currentAmount;
	}

	public int GetCurrentGaugeNum () {
		return currentGaugeNum;
	}

	public int GetGaugeMaxNum () {
		return maxGaugeNum;
	}

	public void AddGauge () {
		++currentGaugeNum;
	}

	public void RemoveGauge () {
		--currentGaugeNum;
	}
}
