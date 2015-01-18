using UnityEngine;
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
	}

	// Please confirm whether or not TouchGaugeStack is not empty before you call this function
	public void UseTouchAction () {
		TouchGaugeStack touchGaugeStackScript = touchGaugeStack.GetComponent<TouchGaugeStack> ();
		touchGaugeStackScript.RemoveGauge ();
		touchRecoverGauge.GetComponent<TouchRecoverGauge> ().Recover ();
	}

	public GameObject GetTouchGaugeStack () {
		return touchGaugeStack.gameObject;
	}
}
