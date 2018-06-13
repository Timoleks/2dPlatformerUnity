using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HomingMissile : MonoBehaviour {

	public Transform target;
	GameMaster gm;
	Player player;
	private int damage = 60;
	public float speed = 2f;
	public float rotateSpeed = 200f;
	public Transform boomParticle;

	private Rigidbody2D rb;
	AudioManager audioManager;
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		rb = GetComponent<Rigidbody2D>();
		if(gm == null){
			gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
		}
		if(target == null){
			target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		}
		audioManager = AudioManager.instance;
		StartCoroutine(SpeedRocket());
	}

	void FixedUpdate () {

		Vector2 direction = (Vector2)target.position - rb.position;

		direction.Normalize();

		float rotateAmount = Vector3.Cross(direction, transform.up).z;

		rb.angularVelocity = -rotateAmount * rotateSpeed;

		rb.velocity = transform.up * speed;
	}

	IEnumerator SpeedRocket(){
		yield return new WaitForSeconds(1f);
		speed = 6f;
		yield return new WaitForSeconds(12f);
	 	Instantiate(boomParticle,transform.position,Quaternion.identity);
		Destroy(gameObject);
		audioManager.PlaySound(gm.enemyExplosionSound);
	}
	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.tag =="Player"){
		player.DamagePlayer(damage);
	}
	 	Instantiate(boomParticle,transform.position,Quaternion.identity);
		Destroy(gameObject);
		audioManager.PlaySound(gm.enemyExplosionSound);
	}
}
