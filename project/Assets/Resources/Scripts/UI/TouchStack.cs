using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TouchStack : MonoBehaviour {
	
	private float amount = 1.0f;
	private float oneGaugeFigure;
	private int maxHitPoint;
	private int hitPoint;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	public void InitHitPoint (int hitPoint) {
		this.hitPoint = hitPoint;
		maxHitPoint = hitPoint;
		oneGaugeFigure = amount / maxHitPoint;
	}

	public void UpdateDisplay () {
		amount = oneGaugeFigure * hitPoint;
		gameObject.GetComponent<Image> ().fillAmount = amount;
	}
}
