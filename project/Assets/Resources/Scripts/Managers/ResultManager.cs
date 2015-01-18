using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResultManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DataSaver.FirstDataCreate ();
		string latestScore = DataSaver.GetLatestScore ();
		string latestCoinNum = DataSaver.GetLatestCoinNum ();
		GameObject.Find ("Meter").GetComponent<Text> ().text = "Meter:" + latestScore;
		GameObject.Find ("CoinUI").GetComponent<Text> ().text = "Coin:" + latestCoinNum;
		int total = int.Parse (latestScore) + (int)(int.Parse (latestCoinNum) * 0.1f);
		GameObject.Find ("Total").GetComponent<Text> ().text = "Total:" + total + "point";
	}
	
	// Update is called once per frame
	void Update () {
	}
}
