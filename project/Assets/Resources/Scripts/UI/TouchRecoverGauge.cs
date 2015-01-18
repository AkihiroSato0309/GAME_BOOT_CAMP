﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TouchRecoverGauge : MonoBehaviour {

	public delegate void RecoverTouchGaugeStack ();
	public event RecoverTouchGaugeStack OnFilled;

	public int recoverGaugeFrame;
	private bool isActive = false;
	private float recoverNum;
	private float currentAmount = 0.0f;
	private const float MAX_AMOUNT = 1.0f;

	// Use this for initialization
	void Start () {
		recoverNum = MAX_AMOUNT / recoverGaugeFrame;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isActive) return;

		currentAmount += recoverNum;
		gameObject.GetComponent<Image> ().fillAmount = currentAmount;

		if (currentAmount >= MAX_AMOUNT) {
			if (this.OnFilled != null) this.OnFilled ();
			currentAmount = 0.0f;
			gameObject.GetComponent<Image> ().fillAmount = currentAmount;
			isActive = false;
		}
	}

	public void Recover () {
		isActive = true;
	}

	public void StopUpdate () {
		isActive = false;
	}
	
	public void StartUpdate () {
		isActive = true;
	}

	public bool IsActive () {
		return isActive;
	}
}
