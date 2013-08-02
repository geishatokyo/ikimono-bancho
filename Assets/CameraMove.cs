using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
	private GameObject PlayerObj;

	// Use this for initialization
	void Start () {
		PlayerObj = GameObject.FindWithTag("Player");
		transform.position = new Vector3(PlayerObj.transform.position.x,5,PlayerObj.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerObj != null){//trace player
			transform.position = new Vector3(PlayerObj.transform.position.x,10,PlayerObj.transform.position.z - 10);
		}
	}
}
