using UnityEngine;
using System.Collections;

public class MovementCS : MonoBehaviour {
	//bool canJump =true;
	public Rigidbody2D rb;
	public float maxSpeed;
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		Cursor.visible = false;
	}

	void onCollisionEnter2D(Collision2D col){
			//canJump = true;
	}
	void onCollisionExit2D(Collision2D col){
		//canJump = false;
	}

	void Update () {
		float posx = gameObject.transform.position.x;
		float posy = gameObject.transform.position.y;
		float speed = 40f;

		if (rb.velocity.magnitude > maxSpeed)
			rb.velocity = maxSpeed * rb.velocity.normalized;
		if(Input.GetKeyDown("up")){
			rb.AddForce (transform.up*(speed+1500));
		}if(Input.GetKey("left")){
			rb.AddForce ((-1*transform.right)*speed);
		}if(Input.GetKey("down")){
			//posy-=speed*Time.deltaTime;
		}if(Input.GetKey("right")){
			rb.AddForce (transform.right*speed);
		}
		gameObject.transform.position = new Vector2(posx,posy);
	}
}