using UnityEngine;
using System.Collections;

public class GameBackground : MonoBehaviour {

	[SerializeField]
	private float moveSpd = 0.25f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 offset = new Vector2 (0.0f, Camera.main.gameObject.transform.position.y * moveSpd);						// Yの値がずれていくオフセットを作成.
		renderer.sharedMaterial.SetTextureOffset ("_MainTex", offset);	// マテリアルにオフセットを設定する.
	}
}
