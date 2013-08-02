using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	private int PlayerSpeed = 15;
	private Vector3 difference;
	private Vector3 OldPlace;//A vector
	private float timer=0,LieTimer=0,StaminaTimer=0,DamageTimer=0;//timers
	private int DamageFlag=0;//Flags
	static public int status = 0;//player status(default:0,attack:1,lie:2,lie&attack:3)
	
	public GameObject DamageEffectPrefab;
	
	static public float PLLV = 1,PLPrevLV=1,ChLV=1,ChPrevLV=1;//Level(float)
	static public float MaxHP,InitHP;//Hit Point
	static public float stamina,StaminaMax;//Stamina (use for attack)
	static public float PLExp=0,PLNextExp=100,ChExp=0,ChNextExp=100;
	private float initdam,dam;//Attack Power
	static public float TerritoryRate=1;
	
	static public float HP = 100 + (PLLV*10)*TerritoryRate;
	
	void Awake(){
		stamina=100;
		initdam=30*(1+ChLV/100)*(TerritoryRate);//damage rate (LV)
		StaminaMax = stamina = stamina + (ChLV*10)*(TerritoryRate);
	}
	
	// Use this for initialization
	void Start () {
		OldPlace=transform.position;
		rigidbody.freezeRotation = true;//Do not spin
		//InitFlag = 1;
	}
	
	// Update is called once per frame
	void Update () {
		//Count timers
		if(status==1 || status==3)timer += Time.deltaTime;//
		if(Input.GetKey(KeyCode.Space))LieTimer += Time.deltaTime;
		else LieTimer=0;
		StaminaTimer += Time.deltaTime;
		if(DamageFlag == 1)DamageTimer += Time.deltaTime;
		if(DamageTimer > 0.5){
			DamageFlag = 0;
			DamageTimer = 0;
		}
		
		//Attack (Speed Up!)
		Attack();
		
		//Lie (Speed Down)
		Lie();
		
		//move
		rigidbody.velocity = new Vector3(PlayerSpeed * Input.GetAxis("Horizontal"),0, PlayerSpeed * Input.GetAxis("Vertical"));
		
		//Spin
		FaceForward();
		
		//stamina recovery
		StaminaRecavary();
		
		if(PLExp >= PLNextExp && PLLV<100){
			PLLV +=1;
			PLNextExp *= 2.0f;
		}
		if(ChExp >= ChNextExp && ChLV < 100){
			ChLV+=1;
			ChNextExp *= 1.5f;
		}
		PlayerPrefs.SetFloat("Player.LV",PLLV);	
		PlayerPrefs.SetFloat("Player.Exp",PLExp);
		PlayerPrefs.SetFloat("Player.NextExp",PLNextExp);
		
		if(CharacterModelScript.CharacterNum == 1){
			PlayerPrefs.SetFloat("Chara1.LV",ChLV);
			PlayerPrefs.SetFloat("Chara1.Exp",ChExp);
			PlayerPrefs.SetFloat("Chara1.NextExp",ChNextExp);
		}
		else if(CharacterModelScript.CharacterNum == 2){
			PlayerPrefs.SetFloat("Chara2.LV",ChLV);
			PlayerPrefs.SetFloat("Chara2.Exp",ChExp);
			PlayerPrefs.SetFloat("Chara2.NextExp",ChNextExp);
		}
		else if(CharacterModelScript.CharacterNum == 3){
			PlayerPrefs.SetFloat("Chara3.LV",ChLV);
			PlayerPrefs.SetFloat("Chara3.Exp",ChExp);
			PlayerPrefs.SetFloat("Chara3.NextExp",ChNextExp);
		}
		else if(CharacterModelScript.CharacterNum == 4){
			PlayerPrefs.SetFloat("Chara4.LV",ChLV);
			PlayerPrefs.SetFloat("Chara4.Exp",ChExp);
			PlayerPrefs.SetFloat("Chara4.NextExp",ChNextExp);
		}
		
		//PlayerPrefs.SetFloat("TestHP",HP);
		PlayerPrefs.Save();
	}
	
	//collision
	void OnCollisionEnter(Collision collision){
		if(status==1 || status==3){//Atack timing
			if(collision.gameObject.tag == "Enemy" && DamageFlag == 0){
				collision.gameObject.SendMessage("Damage",dam,SendMessageOptions.DontRequireReceiver);
				DamageFlag = 1;
			}
		}
	}
	
	void Damage(int dam){
		HP -= dam;
		Instantiate(DamageEffectPrefab,transform.position,transform.rotation);
		//Destroy
		if(HP<=0){
			HP=0;
			Application.LoadLevel("TitleMenu");
		}
	}
	
	void Lie(){
		if(LieTimer > 1.0 && status != 3)status=2;
		if(status==2)PlayerSpeed=5;
		if(status != 1 && LieTimer <= 1.0 && status != 3)status=0;
		if(status==0)PlayerSpeed=15;
	}
	
	void Attack(){
		if(stamina > 10){//stamina check
			if(Input.GetKeyUp(KeyCode.Space) && status == 2){
				status = 3;
				stamina -= 10;
			}
			else if (Input.GetKeyUp(KeyCode.Space)){
				status=1;
				stamina -= 20;
			}
			if(status==1)PlayerSpeed=45;
			if(status==3){
				PlayerSpeed=45;
				dam=initdam*2;
			}
		}
		//Attack Motion Reset
		if(timer > 0.2){
			status=0;
			timer=0;
			dam=initdam;
		}
	}
	
	void FaceForward(){
		difference=transform.position - OldPlace;// A -> B(now) vector
		if (difference.magnitude > 0.01) {
			transform.rotation = Quaternion.LookRotation(difference);
		}
		OldPlace=transform.position;
	}
	
	void StaminaRecavary(){
		if(StaminaTimer > 0.1 && stamina < StaminaMax){
			stamina += 1;
			StaminaTimer = 0;
		}
	}
}