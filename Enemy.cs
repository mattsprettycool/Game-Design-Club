//by jaisaka
using UnityEngine;
public class Enemy : MonoBehaviour {
	public float speed = 2f; //gotta go fast
	public float length = 8f; //length to go
	public float posX = 0f; //x pos

	void Update() {
		Vector2 pos = new Vector2 ( posX+Mathf.PingPong(speed * Time.time, length),0);
		transform.position = pos;
	}
}
