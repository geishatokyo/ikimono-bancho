using UnityEngine;
using System.Collections;

public class ShiftScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void ShiftPlay(){
		Application.LoadLevel("PlayGame");
	}
	
	void ShiftExit(){
		Application.Quit();
	}
	
	void ShiftSelect(){
		Application.LoadLevel("CharacterSelect");
	}
	
	void ShiftDictionary(){
		Application.LoadLevel("CharacterDictionary");
	}
	
	void ShiftTitle(){
		Application.LoadLevel("TitleMenu");
	}
	
	void ShiftPlace(){
		Application.LoadLevel("TestScene");
	}
}
