using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemytestAI : MonoBehaviour {

	public float speed = 4f;
	public float retreatDistance;
	public float stoppingDistance;
	
	private Transform player;
	private float timeBtwShoot;
	public float StartTimeBtwShoot;

	public GameObject ball;
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;

	}

	// Update is called once per frame
	void Update () {
		if(Vector2.Distance(transform.position,player.position) > stoppingDistance)
		{
			transform.position = Vector2.MoveTowards(transform.position,player.position,speed * Time.deltaTime);
		}
		else if(Vector2.Distance(transform.position,player.position) < stoppingDistance && Vector2.Distance(transform.position,player.position) > retreatDistance){
			transform.position = this.transform.position;
		}
		else if(Vector2.Distance(transform.position,player.position) < retreatDistance){
			transform.position = Vector2.MoveTowards(transform.position,player.position,-speed * Time.deltaTime);
		}
		if(timeBtwShoot <= 0){
			Instantiate(ball,transform.position,Quaternion.identity);
			timeBtwShoot = StartTimeBtwShoot;
		}
		else
		{
			timeBtwShoot -= Time.deltaTime;
		}
	}
}
