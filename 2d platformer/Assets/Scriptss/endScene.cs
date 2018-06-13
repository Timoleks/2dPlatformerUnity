using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endScene : MonoBehaviour {

	public LevelChanger fadeOut;
	void OnTriggerEnter2D(Collider2D shit){
		if(shit.gameObject.tag == "Player"){
			fadeOut.FadeToLevel(3);
		}
	}
}
