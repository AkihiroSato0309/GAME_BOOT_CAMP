using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FeverGauge : MonoBehaviour {

	public delegate void AddedEventHandler ();
	public delegate void RemovedEventHandle ();
	public event AddedEventHandler OnFilled;
	public event RemovedEventHandle OnEmpty;

	[SerializeField]
	private int requiredNumForStartingFever;
	[SerializeField]
	private float removeAmountFrame;
	private float oneGaugeAmount;
	private float currentAmount = 0.0f;
	private const float MAX_AMOUNT = 1.0f;
	private bool isFevering = false;

	// Use this for initialization
	void Start () {
		oneGaugeAmount = MAX_AMOUNT / requiredNumForStartingFever;
	}
	
	// Update is called once per frame
	void Update () {
		GameObject.Find ("FeverGauge").GetComponent<Image> ().fillAmount = currentAmount;

		if (!isFevering && currentAmount >= MAX_AMOUNT) {
			isFevering = true;
			if (this.OnFilled != null) this.OnFilled ();
		}

		if (isFevering) {
			currentAmount -= 1.0f / removeAmountFrame;
			if (currentAmount <= 0) {
				isFevering = false;
				if (OnEmpty != null) OnEmpty ();
			}
		}
	}

	// Call this function when player ball get a coin
	public void AddGauge () {
		currentAmount += oneGaugeAmount;
		currentAmount = Mathf.Clamp (currentAmount, 0.0f, 1.0f);
	}
}
