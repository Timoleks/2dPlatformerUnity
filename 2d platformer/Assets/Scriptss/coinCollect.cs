using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinCollect : MonoBehaviour {

	public UpgradeMenu uM;
	public Transform spawnpPrefab;
	public int surprise = 30;
	public string coinSound = "Yo";
	AudioManager audioManager;
	void Start(){
		audioManager = AudioManager.instance;
	}
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Player"){
			Instantiate(spawnpPrefab,transform.position,Quaternion.identity);
			Destroy(gameObject);
			uM.money += surprise;
			audioManager.PlaySound(coinSound);
		}
	}
}
