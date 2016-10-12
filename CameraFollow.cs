using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public GameObject ye;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float posX = ye.transform.position.x;
		float posY = ye.transform.position.y;
		gameObject.transform.position = new Vector3 (posX, posY, -10f);
	}
}
