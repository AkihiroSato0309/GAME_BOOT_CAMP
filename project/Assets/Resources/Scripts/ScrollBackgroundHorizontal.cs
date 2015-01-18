using UnityEngine;
using System.Collections;

public class ScrollBackgroundHorizontal : MonoBehaviour {
	
	[SerializeField]
	private float speed = 1f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float scroll = Mathf.Repeat (Time.time * speed, 1);				// 時間によってYの値が0から1に変化していく.1になったら0に戻り繰り返す.
		Vector2 offset = new Vector2 (scroll, 0);						// Yの値がずれていくオフセットを作成.
		renderer.sharedMaterial.SetTextureOffset ("_MainTex", offset);	// マテリアルにオフセットを設定する.
	}
}

