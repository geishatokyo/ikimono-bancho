using UnityEngine;
using System.Collections;

public class CharacterModelScript : MonoBehaviour {
	
	public GameObject PlayerPrefab1,PlayerPrefab2,PlayerPrefab3,PlayerPrefab4;
	private GameObject DeleteObject;
	private UIButton EnableButton;
	static public int CharacterNum;
	
	// Use this for initialization
	void Start () {
		CharacterNum = 0;
		
		if(Player.PLLV < 10){
			EnableButton = GameObject.Find("Button2").GetComponent<UIButton>();
			EnableButton.isEnabled = false;
		}
		if(Player.PLLV < 20){
			EnableButton = GameObject.Find("Button3").GetComponent<UIButton>();
			EnableButton.isEnabled = false;
		}
		if(Player.PLLV < 30){
			EnableButton = GameObject.Find("Button4").GetComponent<UIButton>();
			EnableButton.isEnabled = false;
		}
		EnableButton = GameObject.Find("Sortie").GetComponent<UIButton>();
		EnableButton.isEnabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(GameObject.FindWithTag("Player") != null){
			GameObject.FindWithTag("Player").GetComponent<Player>().enabled = false;
		}
		if(CharacterNum != 0)EnableButton.isEnabled = true;
	}
	
	void SelectChara1(){
		if(GameObject.FindWithTag("Player") != null){
			DeleteObject = GameObject.FindWithTag("Player");
			Destroy(DeleteObject);
		}
		Instantiate(PlayerPrefab1,new Vector3(1.6f,0.8f,-4.8f),Quaternion.Euler(0f,138f,0f));
		CharacterNum = 1;
		if(PlayerPrefs.GetFloat("Chara1.LV") != 0)Player.ChLV = PlayerPrefs.GetFloat("Chara1.LV");
		else Player.ChLV = 1;
		if(PlayerPrefs.GetFloat("Chara1.Exp") != 0)Player.ChExp = PlayerPrefs.GetFloat("Chara1.Exp");
		else Player.ChExp = 0;
		if(PlayerPrefs.GetFloat("Chara1.NextExp") != 0)Player.ChNextExp = PlayerPrefs.GetFloat("Chara1.NextExp");
		else Player.ChNextExp = 100;
		GameObject.Find("CharaLV").GetComponent<UILabel>().text = "LV" + Player.ChLV;
	}
	
	void SelectChara2(){
		if(GameObject.FindWithTag("Player") != null){
			DeleteObject = GameObject.FindWithTag("Player");
			Destroy(DeleteObject);
		}
		Instantiate(PlayerPrefab2,new Vector3(1.6f,0.8f,-4.8f),Quaternion.Euler(0f,138f,0f));
		CharacterNum = 2;
		if(PlayerPrefs.GetFloat("Chara2.LV") != 0)Player.ChLV = PlayerPrefs.GetFloat("Chara2.LV");
		else Player.ChLV = 1;
		if(PlayerPrefs.GetFloat("Chara2.Exp") != 0)Player.ChExp = PlayerPrefs.GetFloat("Chara2.Exp");
		else Player.ChExp = 0;
		if(PlayerPrefs.GetFloat("Chara2.NextExp") != 0)Player.ChNextExp = PlayerPrefs.GetFloat("Chara2.NextExp");
		else Player.ChNextExp = 100;
		GameObject.Find("CharaLV").GetComponent<UILabel>().text = "LV" + Player.ChLV;
	}
	
	void SelectChara3(){
		if(GameObject.FindWithTag("Player") != null){
			DeleteObject = GameObject.FindWithTag("Player");
			Destroy(DeleteObject);
		}
		Instantiate(PlayerPrefab3,new Vector3(1.6f,0.8f,-4.8f),Quaternion.Euler(0f,138f,0f));
		CharacterNum = 3;
		if(PlayerPrefs.GetFloat("Chara3.LV") != 0)Player.ChLV = PlayerPrefs.GetFloat("Chara3.LV");
		else Player.ChLV = 1;
		if(PlayerPrefs.GetFloat("Chara3.Exp") != 0)Player.ChExp = PlayerPrefs.GetFloat("Chara3.Exp");
		else Player.ChExp = 0;
		if(PlayerPrefs.GetFloat("Chara3.NextExp") != 0)Player.ChNextExp = PlayerPrefs.GetFloat("Chara3.NextExp");
		else Player.ChNextExp = 100;
		GameObject.Find("CharaLV").GetComponent<UILabel>().text = "LV" + Player.ChLV;
	}
	
	void SelectChara4(){
		if(GameObject.FindWithTag("Player") != null){
			DeleteObject = GameObject.FindWithTag("Player");
			Destroy(DeleteObject);
		}
		Instantiate(PlayerPrefab4,new Vector3(1.6f,0.8f,-4.8f),Quaternion.Euler(0f,138f,0f));
		CharacterNum = 4;
		if(PlayerPrefs.GetFloat("Chara4.LV") != 0)Player.ChLV = PlayerPrefs.GetFloat("Chara4.LV");
		else Player.ChLV = 1;
		if(PlayerPrefs.GetFloat("Chara4.Exp") != 0)Player.ChExp = PlayerPrefs.GetFloat("Chara4.Exp");
		else Player.ChExp = 0;
		if(PlayerPrefs.GetFloat("Chara4.NextExp") != 0)Player.ChNextExp = PlayerPrefs.GetFloat("Chara4.NextExp");
		else Player.ChNextExp = 100;
		GameObject.Find("CharaLV").GetComponent<UILabel>().text = "LV" + Player.ChLV;
	}
}
