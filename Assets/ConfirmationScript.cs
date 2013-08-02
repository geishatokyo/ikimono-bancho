using UnityEngine;
using System.Collections;

public class ConfirmationScript : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnDestroy(){
		Time.timeScale = 1;
	}
	
	void Yes(){
		Application.LoadLevel("TitleMenu");
	}
	
	void No(){
		Destroy(this.gameObject);
	}
}
