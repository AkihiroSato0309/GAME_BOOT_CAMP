using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoinUI : MonoBehaviour {

	[SerializeField]
	private int coinNum = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Text> ().text = " x " + coinNum.ToString ();
	}

	public void AddCoin () {
		++coinNum;
	}

	public int GetCoinNum () {
		return coinNum;
	}
}
