using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goEndGame : MonoBehaviour {

	//public LevelChanger fadeOut;
	public Transform goPrefabParticle;
	public Transform goParticlePosition;

	void Start(){
		Instantiate(goPrefabParticle,goParticlePosition.position,goPrefabParticle.rotation);
	}

}
