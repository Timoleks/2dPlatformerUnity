using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeHeal : MonoBehaviour {

	public UpgradeMenu uM;
	public Transform spawnpPrefab;
	public int surprise = 100;
	public string coinSound = "Yo";
	AudioManager audioManager;
	public Transform rocket;
	public Transform[] rocketSpawns;
	void Start(){
		audioManager = AudioManager.instance;

	}
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Player"){
			Instantiate(spawnpPrefab,transform.position,Quaternion.identity);
			Destroy(gameObject);
			uM.stats.maxHealth += surprise;
			uM.stats.healthRegenRate += 2f;
			for(int i = 0 ;i<rocketSpawns.Length;i++){
				Instantiate(rocket,rocketSpawns[i].position,Quaternion.identity);
			}
	
			audioManager.PlaySound(coinSound);
		}
	}
}
