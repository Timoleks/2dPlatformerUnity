using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mpl1 : MonoBehaviour {

//	public Transform target;
	private Vector3 _endPos;
	private Vector3 nextPos;
	private float speed = 4f;
	public Transform childTransform;
	[SerializeField]
	private Transform transformB;
	void Start () {

		_endPos = transformB.localPosition;
		nextPos = _endPos;
	}
	void Update(){
		Move();
	}
	private void Move(){
		childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition,nextPos,speed*Time.deltaTime);
	}
}
