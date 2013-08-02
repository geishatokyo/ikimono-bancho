using UnityEngine;
using System.Collections;

public class PlayerSpawnerScript : MonoBehaviour {
	
	public GameObject PlayerModel1,PlayerModel2;

	// Use this for initialization
	void Start () {
		if(CharacterModelScript.CharacterNum == 1){
			Instantiate(PlayerModel1,new Vector3(0,0,0),Quaternion.identity);
		}
		else if(CharacterModelScript.CharacterNum == 2){
			Instantiate(PlayerModel2,new Vector3(0,0,0),Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
