using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TitleManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.Find ("BestScore").GetComponent<Text> ().text = DataSaver.GetHighestScore ().ToString () + "m";
		GameObject.Find ("Coin").GetComponent<Text> ().text = DataSaver.GetCoinNum ().ToString ();
	}
	
	// Update is called once per frame
	void Update () {
	}
}
