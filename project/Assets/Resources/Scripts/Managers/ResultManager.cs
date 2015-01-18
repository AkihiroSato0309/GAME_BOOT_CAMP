using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResultManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DataSaver.FirstDataCreate ();
		string latestScore = DataSaver.GetLatestScore ();
		string latestCoinNum = DataSaver.GetLatestCoinNum ();
		GameObject.Find ("MeterResult").GetComponent<Text> ().text = "Meter:" + latestScore;
		GameObject.Find ("CoinResult").GetComponent<Text> ().text = "Coin:" + latestCoinNum;
		int total = int.Parse (latestScore) + (int)(int.Parse (latestCoinNum) * 0.1f);
		GameObject.Find ("Total").GetComponent<Text> ().text = "Total:" + total + "point";
		GameObject.Find ("MenuButton").GetComponent<Button> ().onClick.AddListener(GameObject.Find ("SceneChanger").GetComponent<SceneChanger> ().ChangeToMenuScene);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
