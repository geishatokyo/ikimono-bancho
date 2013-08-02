using UnityEngine;
using System.Collections;

public class NestScript : MonoBehaviour {
	
	private int OutNest = 0,able=0;
	private GameObject PlayerObj;
	
	public Material NoExit;
	public Material DoExit;
	
	private GameObject MessageObject;
	private float MessageTimer;
	private int MessageFlag;
	public UILabel MessageLabel;
	
	private int FoundFlag;

	// Use this for initialization
	void Start () {
		FoundFlag=0;
		Time.timeScale = 1;
		MessageFlag = 0;
		MessageTimer=0f;
		TextAsset Text = Resources.Load("StartMessage") as TextAsset;
		MessageLabel = GameObject.Find("Message").GetComponent<UILabel>();
		MessageLabel.text = Text.text;
		
		PlayerObj = GameObject.FindWithTag("Player");
		PlayerObj.GetComponent<Revolution>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		var ObjectArray = GameObject.FindGameObjectsWithTag("Enemy");
		var MaxEnemy = GameObject.FindGameObjectsWithTag("Enemy").Length;
		
		var i=0;
		for(i=0;i<MaxEnemy;i++){
			if(ObjectArray[i].GetComponent<Enemy>().HomingFlag == 1){
				FoundFlag = 1;
				break;
			}
			else if(ObjectArray[i].GetComponent<Enemy>().HomingFlag == 0){
				FoundFlag = 0;
			}
		}
		
		if(MessageFlag == 0)MessageTimer += Time.deltaTime;
		if(MessageTimer > 3.0){
			MessageLabel.text = "";
		}
		
		if(FoundFlag == 1){
			able=1;
			renderer.material = NoExit;
		}
		else if(FoundFlag == 0){
			able=0;
			renderer.material = DoExit;
		}
		//else renderer.material = ;
		if(PlayerObj != null){
			if(PlayerObj.transform.position.sqrMagnitude > 25 && OutNest == 0)OutNest = 1;
			
			if(PlayerObj.transform.position.sqrMagnitude < 25 && OutNest == 1 && able == 0){
				OutNest = 0;
				Time.timeScale = 0;
				
				Application.LoadLevelAdditive("ReturnConfirmation");
			}
			
			if(OutNest==1 && GameObject.FindWithTag("Enemy") == null)Application.LoadLevel("TitleMenu");
		}
	}
}
