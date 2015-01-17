using UnityEngine;
using System.Collections;

public class SatouUtility : MonoBehaviour {

	// Vector3をVector2へ変換
	static public Vector2 Vec3toVec2 (Vector3 pos) 
	{
		Vector2 tmp;
		tmp.x = pos.x;
		tmp.y = pos.y;
		return tmp;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
