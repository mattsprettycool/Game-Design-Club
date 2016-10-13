using UnityEngine;
using System.Collections;
//By:Jai Saka
public class Enemy : MonoBehaviour {
	public Rigidbody2D rb;
	public float maxSpeed;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		float xpose = gameObject.transform.position.x;
		float ypose = gameObject.transform.position.y;
		StartCoroutine (timeandmove());
		gameObject.transform.position = new Vector2(xpose, ypose);
	}
	IEnumerator timeandmove(){
		float speed = 10f;
		rb.AddForce (transform.right * speed);
		yield return new WaitForSeconds(1);
		rb.AddForce ((-1*transform.right)*speed);
	}
}
