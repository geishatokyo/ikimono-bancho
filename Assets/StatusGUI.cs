using UnityEngine;
using System.Collections;

public class StatusGUI : MonoBehaviour {
	
	public Texture2D HpBarFull;
	public Texture2D BarEmpty;
	public Texture2D StaminaBarFull;
	private float PlayerHP,PlayerStamina,ShiftTiming;
	private float left = Screen.width/100;
	private float top = Screen.height/100;
	private float Rate,StaminaRate;

	// Use this for initialization
	void Start () {
		PlayerHP = Player.HP;
		Rate = 200 / PlayerHP;
		StaminaRate = 200 / Player.StaminaMax;
	}
	
	void OnGUI () {
		//HP bar display
		HPDisp();
		
		//Stamina bar display
		StaminaDisp();
		
		//ReturnToMenu();
	}
	
	// Update is called once per frame
	void Update () {
		PlayerHP = Player.HP;
		PlayerStamina = Player.stamina;
	}
	
	void HPDisp(){
		GUI.BeginGroup (new Rect (left,top,200,32));
		GUI.DrawTexture (new Rect (0,0,200,32),BarEmpty,ScaleMode.StretchToFill, true, 10.0f);
			GUI.BeginGroup (new Rect (1,1,(Rate*PlayerHP)-2, 30));
	    	GUI.DrawTexture (new Rect (0,0,200,30),HpBarFull,ScaleMode.StretchToFill, true, 10.0f);
			GUI.contentColor = Color.black;
			GUI.Label(new Rect(2,2,100,25),PlayerHP + "/" + Player.MaxHP);
	 		GUI.EndGroup ();
	    GUI.EndGroup ();
	}
	
	void StaminaDisp(){
		GUI.BeginGroup (new Rect (left,top+40,200,32));
		GUI.DrawTexture (new Rect (0,0,200,32),BarEmpty,ScaleMode.StretchToFill, true, 10.0f);
			GUI.BeginGroup (new Rect (1,1,(StaminaRate*PlayerStamina)-2, 30));
	    	GUI.DrawTexture (new Rect (0,0,200,30),StaminaBarFull,ScaleMode.StretchToFill, true, 10.0f);
			GUI.Label(new Rect(2,2,100,25),PlayerStamina + "/" + Player.StaminaMax);
	 		GUI.EndGroup ();
	    GUI.EndGroup ();
	}
}
