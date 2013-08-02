using UnityEngine;
using System.Collections;

public class PrintStatus : MonoBehaviour {
	
	private UILabel HPLabel,LevelLabel;

	// Use this for initialization
	void Start () {
		if(PlayerPrefs.GetFloat("Player.Exp") != 0)Player.PLExp = PlayerPrefs.GetFloat("Player.Exp");
		if(PlayerPrefs.GetFloat("Player.LV") != 0)Player.PLLV = PlayerPrefs.GetFloat("Player.LV");
		if(PlayerPrefs.GetFloat("Player.NextExp") != 0)Player.PLNextExp = PlayerPrefs.GetFloat("Player.NextExp");
		//if(PlayerPrefs.GetFloat("TestHP") != 0)Player.HP = PlayerPrefs.GetFloat("TestHP");
		
		//var LVDistance = Player.LV - Player.PrevLV;
		
		//Player.PrevLV = Player.LV;
		/*if(LVDistance !=0){
			Player.HP += LVDistance * 10 * Player.TerritoryRate;
		}*/
		Player.InitHP=100;
		Player.HP=Player.MaxHP=Player.InitHP + (Player.PLLV * 10)*(Player.TerritoryRate);
		
		//Print HP to Label
		PrintHP();
		
		//Print HP to Label
		PrintLevel();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void PrintHP(){
		HPLabel = GameObject.Find("HP").GetComponent<UILabel>();
		HPLabel.text += Player.HP + "/" + Player.MaxHP;
	}
	
	void PrintLevel(){
		LevelLabel = GameObject.Find("Level").GetComponent<UILabel>();
		LevelLabel.text += Player.PLLV;	
	}
}
