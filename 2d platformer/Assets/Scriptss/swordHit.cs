using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordHit : MonoBehaviour {
  AudioManager audioManager;
  Player player;
  public string damageSound = "DamageSound";
  public int damage = 1000;
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
		    player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.DamagePlayer(damage);
		}
	}
}
