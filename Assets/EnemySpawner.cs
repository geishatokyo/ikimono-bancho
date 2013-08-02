using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	
	public GameObject EnemyPrefab0,EnemyPrefab1;
	private int x,z;
	
	// Use this for initialization
	void Start () {
		var min = -40;
		var max = 40;
		var i = 0;
		
		//init Enemy places
		for(i=0;i<10;i++){
			var num = Random.Range(0,2);
			
			//select random place
			do{
				x = Random.Range(min,max);
			}while((-20<x && x<=0) || (0<x && x<20));
			do{
				z = Random.Range(min,max);
			}while((-20<z && z<=0) || (0<z && z<20));
			
			if(num==0)Instantiate(EnemyPrefab0,new Vector3(x,0,z),Quaternion.identity);
			else if(num==1)Instantiate(EnemyPrefab1,new Vector3(x,0,z),Quaternion.identity);
			//else if(num==2)Instantiate(EnemyPrefab2,new Vector3(x,0,z),Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
