using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	private int EnemySpeed = 3;
	private float FindRange = 450.0f,AttackRange = 150.0f;
	private Vector3 difference;
	private Vector3 OldPlace;//A vector
	private int flag=0,attack=0,inrange=0,ChangeRange=0,DamageFlag=0; // Flags
	private float timer=0,interval=0,prowl=0,delay=0,DamageTimer=0; //Timers
	public int HomingFlag=0;
	
	public GameObject DamageEffectPrefab;
	
	public float LV = 1;
	public float HP = 100f;//Hit Point
	private float dam = 20f;//Attack Power

	// Use this for initialization
	void Start () {
		OldPlace=transform.position;
		rigidbody.freezeRotation = true;//Do not spin
		//change range
		FindRange = FindRange * (1 - Player.ChLV/100)*(Player.TerritoryRate); // range rate (LV)
	}
	
	// Update is called once per frame
	void Update () {
		//change FindRange (by Player status)
		FindRangeSet();
		
		if(flag==1)timer += Time.deltaTime;//Count time
		if(attack == 1)interval += Time.deltaTime;//Count interval
		if(DamageFlag == 1)DamageTimer += Time.deltaTime;
		if(DamageTimer > 0.5){
			DamageFlag = 0;
			DamageTimer = 0;
		}
		prowl += Time.deltaTime;//Count Prowl
		
		//Homing
		if(GameObject.FindWithTag("Player") != null){
			var x = GameObject.FindWithTag("Player").transform.position.x - transform.position.x;
			var z = GameObject.FindWithTag("Player").transform.position.z - transform.position.z;
			
			//Player into range
			if((GameObject.FindWithTag("Player").transform.position - transform.position).sqrMagnitude < FindRange){
				HomingFlag = 1;
				
				//Attack (Speed Up!)	
				Attack();
					
				//change velocity (move)
				rigidbody.velocity = new Vector3(x,0,z).normalized * EnemySpeed;
				if(flag==0)EnemySpeed=3;
			}
			//Prowl
			else ProwlFunc();
		}
		//Spin
		FaceForward();	
	}
	
	void OnCollisionEnter(Collision collision){
		if(flag==1){//Attack timing
			if(collision.gameObject.tag == "Player" && DamageFlag == 0){
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
			if(Player.HP < Player.MaxHP)Player.HP += LV*2;
			if(Player.ChLV<100)Player.ChExp += LV*1000;
			if(Player.PLLV<100)Player.PLExp += LV*1000;
			Destroy(gameObject);
		}
	}
	
	void FaceForward(){
		difference=transform.position - OldPlace;// A -> B(now) vector
		if (difference.magnitude > 0.01) {
			transform.rotation = Quaternion.LookRotation(difference);
		}
		OldPlace=transform.position;
	}
	
	void ProwlFunc(){
		HomingFlag = 0;
		EnemySpeed = 3;
		//change velocity timing
		if(prowl > 1.0){
			//change velocity
			rigidbody.velocity = new Vector3(Random.Range(-100,100),0,Random.Range(-100,100)).normalized * EnemySpeed;
			prowl = 0;
		}
	}
	
	void FindRangeSet(){
		if((Player.status == 2 || Player.status == 3) && ChangeRange == 0){
			FindRange = FindRange/3;
			ChangeRange = 1;
		}
		else if(Player.status==1 || Player.status == 0){
			FindRange = 450.0f;
			ChangeRange = 0;
		}
	}
	
	void Attack(){
		//into attack range (player)
		if((GameObject.FindWithTag("Player").transform.position - transform.position).sqrMagnitude < AttackRange && attack == 0)inrange =1;
				
		//Attack Delay (by start)
		if(inrange==1)delay += Time.deltaTime;
		if(delay > 1){
			flag = 1;
			delay = 0;
			inrange = 0;
		}
					
		//Attack start
		if(flag==1){
			EnemySpeed=20;
			attack = 1;
		}
		
		//Attack Reset
		if(timer > 0.5){
			flag=0;
			timer=0;
		}
		
		//Attack Interval
		if(interval > 1.5){
			attack = 0;
			interval = 0;
		}
	}
}