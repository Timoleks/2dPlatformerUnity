using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWalls : MonoBehaviour {

	public mpl1 mp1;
	public mpl2 mp2;
	public GameObject newSpawnPos;
	public GameObject SpPos;


	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			mp1.enabled = true;
			mp2.enabled = true;
			SpPos.transform.position = newSpawnPos.transform.position;
		}
	}
}
