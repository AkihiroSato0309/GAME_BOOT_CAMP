﻿using UnityEngine;
using System.Collections;

public class TouchActionGauge : MonoBehaviour {

	private GameObject touchGaugeStack;
	private GameObject touchRecoverGauge;

	// Use this for initialization
	void Start () {
		touchGaugeStack = transform.FindChild ("TouchGaugeStack").gameObject;
		touchRecoverGauge = transform.FindChild ("TouchRecoverGauge").gameObject;
		touchRecoverGauge.GetComponent<TouchRecoverGauge> ().OnFilled += touchGaugeStack.GetComponent<TouchGaugeStack> ().AddGauge;
	}
	
	// Update is called once per frame
	void Update () {
		if (touchGaugeStack.GetComponent<TouchGaugeStack> ().GetCurrentGaugeNum () < 8 && !touchRecoverGauge.GetComponent<TouchRecoverGauge> ().IsActive ()) {

			touchRecoverGauge.GetComponent<TouchRecoverGauge> ().Recover ();
		}
	}

	// Please confirm whether or not TouchGaugeStack is not empty before you call this function
	public void UseTouchAction () {
		TouchGaugeStack touchGaugeStackScript = touchGaugeStack.GetComponent<TouchGaugeStack> ();
		if (touchGaugeStackScript.GetCurrentGaugeNum() <= 0) return;
		touchGaugeStackScript.RemoveGauge ();
	}

	public GameObject GetTouchGaugeStack () {
		return touchGaugeStack.gameObject;
	}

	public int GetCurrentGaugeNum() {
		TouchGaugeStack touchGaugeStackScript = touchGaugeStack.GetComponent<TouchGaugeStack> ();
		return touchGaugeStackScript.GetCurrentGaugeNum ();
	}
}
