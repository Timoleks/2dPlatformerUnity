using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movpl2 : MonoBehaviour {

//	public Transform target;
	private Vector3 _endPos;
	private Vector3 _StartPos;
	private Vector3 nexPos;
	private float speed = 4f;
	public Transform childTransform;
	[SerializeField]
	private Transform transformB;
	void Start () {
		_StartPos = childTransform.localPosition;
		_endPos = transformB.localPosition;
		nexPos = _endPos;
	}
	void Update(){
		Move();
	}
	private void Move(){
		childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition,nexPos,speed*Time.deltaTime);
		if(Vector3.Distance(childTransform.localPosition,nexPos) <=0.1){
			ChangeDestination();
		}
	}
	private void ChangeDestination(){
		nexPos = nexPos != _StartPos ? _StartPos : _endPos;
	}
}
