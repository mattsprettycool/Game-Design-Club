//by jaisaka
using UnityEngine;
public class Enemy : MonoBehaviour {
	public float speed = 2f; //gotta go fast
	public float length = 8f; //length to go
	public float posX; //x pos
	public float posY;
	public Rigidbody2D thes;

	void Start(){
		posX = gameObject.transform.position.x;
		posY = gameObject.transform.position.y;
	}

	void Update() {
		Vector2 pos = new Vector2 ( posX+Mathf.PingPong(speed * Time.time, length),posY);
		thes.AddForce(pos);
	}
}
