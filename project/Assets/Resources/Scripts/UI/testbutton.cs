using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class testbutton : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		this.transform.Translate(0.0f, 0.1f, 0.0f);
	}

	public void Saikai()
	{
		Time.timeScale = 1.0f;
	}
}
