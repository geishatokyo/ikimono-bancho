using UnityEngine;
using System.Collections;

public class DictionaryScript : MonoBehaviour {
	
	private int DictionaryPlace,DictionaryMax=1,DictionaryMin=1;
	public GameObject CharaModel1,CharaModel2,CharaModel3,CharaModel4;
	private GameObject DeleteObject;
	
	//public TextAsset TextData;
	public UILabel DataLabel;

	// Use this for initialization
	void Start () {
		TextAsset Text = Resources.Load("Dog") as TextAsset;
		DataLabel = GameObject.Find("Data").GetComponent<UILabel>();
		DataLabel.text = Text.text;
		DictionaryPlace = 1;
		Instantiate(CharaModel1,new Vector3(0f,1.07f,-4.7f),Quaternion.Euler(0f,136f,0f));
		if(PlayerPrefs.GetFloat("Chara1.LV") != 0)Player.ChLV = PlayerPrefs.GetFloat("Chara1.LV");
		GameObject.Find("CharaLV").GetComponent<UILabel>().text = "LV" + Player.ChLV;
		
		if(Player.PLLV > 10)DictionaryMax=2;
		if(Player.PLLV > 20)DictionaryMax=3;
		if(Player.PLLV > 30)DictionaryMax=4;
	}
	
	// Update is called once per frame
	void Update () {
		if(GameObject.FindWithTag("Player") != null){
			GameObject.FindWithTag("Player").GetComponent<Player>().enabled = false;
		}
		if(DictionaryPlace == DictionaryMin)GameObject.Find("Left").GetComponent<UIButton>().isEnabled = false;
		else GameObject.Find("Left").GetComponent<UIButton>().isEnabled = true;
		if(DictionaryPlace == DictionaryMax)GameObject.Find("Right").GetComponent<UIButton>().isEnabled = false;
		else GameObject.Find("Right").GetComponent<UIButton>().isEnabled = true;
	}
	
	void SelectDataRight(){
		if(DictionaryPlace < DictionaryMax){
			DictionaryPlace++;
			
			if(DictionaryPlace == 2)SelectData2();
			else if(DictionaryPlace == 3)SelectData3();
			else if(DictionaryPlace == 4)SelectData4();
		}
	}
	
	void SelectDataLeft(){
		if(DictionaryPlace > DictionaryMin){
			DictionaryPlace--;
			
			if(DictionaryPlace == 1)SelectData1();
			else if(DictionaryPlace == 2)SelectData2();
			else if(DictionaryPlace == 3)SelectData3();
		}
	}
	
	void SelectData1(){
		if(GameObject.FindWithTag("Player") != null){
			DeleteObject = GameObject.FindWithTag("Player");
			Destroy(DeleteObject);
		}
		Instantiate(CharaModel1,new Vector3(0f,1.07f,-4.7f),Quaternion.Euler(0f,136f,0f));
		TextAsset Text = Resources.Load("Dog") as TextAsset;
		DataLabel.text = Text.text;
		if(PlayerPrefs.GetFloat("Chara1.LV") != 0)Player.ChLV = PlayerPrefs.GetFloat("Chara1.LV");
		GameObject.Find("CharaLV").GetComponent<UILabel>().text = "LV" + Player.ChLV;
	}
	
	void SelectData2(){
		if(GameObject.FindWithTag("Player") != null){
			DeleteObject = GameObject.FindWithTag("Player");
			Destroy(DeleteObject);
		}
		Instantiate(CharaModel2,new Vector3(0f,1.07f,-4.7f),Quaternion.Euler(0f,136f,0f));
		TextAsset Text = Resources.Load("Parasite") as TextAsset;
		DataLabel.text = Text.text;
		if(PlayerPrefs.GetFloat("Chara2.LV") != 0)Player.ChLV = PlayerPrefs.GetFloat("Chara2.LV");
		else Player.ChLV = 1;
		GameObject.Find("CharaLV").GetComponent<UILabel>().text = "LV" + Player.ChLV;
	}
	
	void SelectData3(){
		if(GameObject.FindWithTag("Player") != null){
			DeleteObject = GameObject.FindWithTag("Player");
			Destroy(DeleteObject);
		}
		Instantiate(CharaModel3,new Vector3(0f,1.07f,-4.7f),Quaternion.Euler(0f,136f,0f));
		TextAsset Text = Resources.Load("Dog") as TextAsset;
		DataLabel.text = Text.text;
		if(PlayerPrefs.GetFloat("Chara3.LV") != 0)Player.ChLV = PlayerPrefs.GetFloat("Chara3.LV");
		else Player.ChLV = 1;
		GameObject.Find("CharaLV").GetComponent<UILabel>().text = "LV" + Player.ChLV;
	}
	
	void SelectData4(){
		if(GameObject.FindWithTag("Player") != null){
			DeleteObject = GameObject.FindWithTag("Player");
			Destroy(DeleteObject);
		}
		Instantiate(CharaModel4,new Vector3(0f,1.07f,-4.7f),Quaternion.Euler(0f,136f,0f));
		TextAsset Text = Resources.Load("Parasite") as TextAsset;
		DataLabel.text = Text.text;
		if(PlayerPrefs.GetFloat("Chara4.LV") != 0)Player.ChLV = PlayerPrefs.GetFloat("Chara4.LV");
		else Player.ChLV = 1;
		GameObject.Find("CharaLV").GetComponent<UILabel>().text = "LV" + Player.ChLV;
	}
}
