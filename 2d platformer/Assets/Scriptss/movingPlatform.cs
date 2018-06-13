using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour {

	public Transform target;
	public Transform goPrefabParticle;
	public Transform goParticlePosition;
	private Vector3 _startPos;
	private Vector3 _endPos;
	void Start () {
		_startPos = transform.position;
		_endPos = target.position;
		 Instantiate(goPrefabParticle,goParticlePosition.position,goPrefabParticle.rotation);
	}


	// Update is called once per frame
	void FixedUpdate () {
		transform.position = Vector3.Slerp(_startPos,_endPos,Time.time);
		//ShowPlatform();
	}
}
