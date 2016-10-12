using UnityEngine;
using System.Collections;
//By:Matt Braden
public class CameraFollow : MonoBehaviour {
	//defines the character to reference
	public GameObject ye;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//The camera can follow the character with this.
		float posX = ye.transform.position.x;
		float posY = ye.transform.position.y;
		gameObject.transform.position = new Vector3 (posX, posY, -10f);
	}
}
