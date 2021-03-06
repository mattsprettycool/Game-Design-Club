using UnityEngine;
using System.Collections;
using System.Threading;
//By: Matt Braden
public class MovementCS : MonoBehaviour {
	//Used to manipulate the rigidbody (an object that you can apply physics to
	public Rigidbody2D rb;
	//You can change this value in the 'inspector' because it is a 'public' variable
	public float maxSpeed = 5;
	//bool is a true/false statement
	public bool canJump = false;
	//this happens when the game starts
	public int colorChange = 1;
	public GameObject[] reds;
	public GameObject[] blues;
	public BoxCollider2D[] redsBox;
	public BoxCollider2D[] bluesBox;
	public GameObject otherR;
	public GameObject otherB;
	public int rX;
	public int bX;
	int i = 1;
	void Start () {
		rX = 0;
		bX = 0;
		//this assigns the rigidbody to the one this is attached to
		rb = GetComponent<Rigidbody2D> ();
		//makes the cursor invisible
		Cursor.visible = false;
	}
	//update every FRAME (make note of that)
	void Update () {
		redsBox = otherR.GetComponentsInChildren<BoxCollider2D> ();
		bluesBox = otherB.GetComponentsInChildren<BoxCollider2D> ();
		if (i == 1) {
			i = 2;
			colorChange=1;
			print("You are blue");
			foreach (BoxCollider2D obj in bluesBox) {
				obj.enabled = true;
			}
			foreach (BoxCollider2D obj in redsBox) {
				obj.enabled = false;
			}
		}
		//you can use my posx,y code over here to move reliably, though I use the rigidbody
		float posx = gameObject.transform.position.x;
		float posy = gameObject.transform.position.y;
		//the speed to add
		float speed = 40f;
		//This is how if statements work. the others are while, for, do, and switch
		//this tests if the velocity is over the max, if it is, it will change it to it. this prevents crazy velocities.
		if (rb.velocity.magnitude > maxSpeed)
			rb.velocity = maxSpeed * rb.velocity.normalized;
		//Input.GetKeyDown will only activate when it is pressed, but getkey will update as long as it is held
		if(Input.GetKey("up")&&canJump==true){
			//adds force to the rigidbody in the specified direction.
			rb.AddForce (transform.up*(speed+1500));
			//Ensures that you cant 'fly'
			canJump = false;
		}if(Input.GetKey("left")){
			rb.AddForce ((-1*transform.right)*speed);
		}if(Input.GetKey("right")){
			rb.AddForce (transform.right*speed);
		}
		if(Input.GetKeyDown ("r")){
			posx=0;
			posy=0;
		}
		if(Input.GetKeyDown("x")){
			//1=red, 2=blue
			if (colorChange == 1) {
				colorChange=2;
				print("You are red");
				foreach (BoxCollider2D obj in redsBox) {
					obj.enabled = true;
				}
				foreach (BoxCollider2D obj in bluesBox) {
					obj.enabled = false;
				}
			} else if (colorChange == 2) {
				colorChange=1;
				print("You are blue");
				foreach (BoxCollider2D obj in bluesBox) {
					obj.enabled = true;
				}
				foreach (BoxCollider2D obj in redsBox) {
					obj.enabled = false;
				}
			}
		}
		//changes the pos to the posx,y 
		gameObject.transform.position = new Vector2(posx,posy);
	}
	void OnCollisionEnter2D(Collision2D col){
		//the three different layers are referenced, and will be updated when layer swapping is a thing
		if (col.gameObject.tag == "Purple")
			canJump = true;
		if (col.gameObject.tag == "Red" && colorChange == 2) {
			canJump = true;
		} else if (col.gameObject.tag == "Red" && colorChange == 1) {
			canJump = false;
		}
		if (col.gameObject.tag == "Blue" && colorChange == 1) {
			canJump = true;
		}else if (col.gameObject.tag == "Blue" && colorChange == 2) {
			canJump = false;
		}
	}
}
