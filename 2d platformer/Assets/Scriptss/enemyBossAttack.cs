using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class enemyBossAttack : MonoBehaviour {

	public float MoveSpeed =2f;
	private float attackDist = 13f;
	private float rocketTimes = 1f;
	private bool isReloading = false;
	private bool isBossAlive = true;
	public float startHealth = 1000f;
	public float health;
	public Transform rocket;
	public Transform rocketSpawnPos;
	private bool isMove = false;
	private bool isAlive = false;
	public Transform target;
	public Animator animator;
	[SerializeField]
	private Image content;
	BoxCollider2D bk;
	PolygonCollider2D pk;
	public GameObject endgm;
	float fx, fy, fz;
	void Start(){
		fx = transform.localScale.x;
		fy = transform.localScale.y;
		fz = transform.localScale.z;
		bk = GetComponent<BoxCollider2D>();
		pk = GetComponent<PolygonCollider2D>();
		health = startHealth;
		//endgm = GameObject.FindGameObjectWithTag("endGame");
 }

	void Update(){
		//Debug.Log(Vector2.Distance(transform.position,target.transform.position));
		if(target == null){
			isAlive = false;
			StartCoroutine(SearchingForPlayer());
		}
		else{
			isAlive = true;
		}
		if(isBossAlive){
			if(isAlive){
				Enemyai();
			}
	}

	if(isBossAlive == false){
		animator.SetTrigger("death");
		bk.enabled = false;
		pk.enabled = false;
		endgm.SetActive(true);
	}
		//handlebar();

}
	// public void handlebar(){
	// 	content.fillAmount = Map(34,0,100,0,1);
	// }
	// private float Map(float value, float inMin,float inMax,float outMin,float outMax){
	// 	return (value - inMin) * (outMax - outMin) / (inMax - inMin) +outMin;
	// }
	public void DamageBoss(int damage){
		health = health - damage;

		content.fillAmount = health / startHealth;
		if(health == 40){
			animator.SetTrigger("hit_1");
		}
		if(health == 20){
			animator.SetTrigger("hit_2");
		}
		if(health <= 0){
			animator.SetTrigger("hit_2");
			KillBoss();
		}
	}
	public void KillBoss(){

		//animator.ResetTrigger("walk");
		//animator.ResetTrigger("idle_1");
		//animator.SetTrigger("hit_2");
		isBossAlive = false;

	}
	IEnumerator RocketAttack(){
		animator.SetTrigger("skill_2");
		rocketTimes--;
		yield return new WaitForSeconds(0.5f);
		Instantiate(rocket,rocketSpawnPos.position,Quaternion.identity);
	}
	IEnumerator ReloadAttacks(){
		yield return new WaitForSeconds(10f);
		rocketTimes++;
	}
	IEnumerator SearchingForPlayer(){
		GameObject sResult = GameObject.FindGameObjectWithTag("Player");
		if(sResult == null){
			yield return new WaitForSeconds(0.5f);
			StartCoroutine(SearchingForPlayer());
		}
		else{
			target = sResult.transform;
		}
	}
	public void Enemyai(){
		//Debug.Log(Vector2.Distance(transform.position,target.position));

			MoveEnemy();

			if(Vector2.Distance(transform.position,target.position) < attackDist){
				HitEnemy();
			}
		// if(Vector2.Distance(transform.position,target.position) > visionDist){
		// 	isMove = false;
		//
		// }
		// --- --- - -- -  rocket attack
		 if(rocketTimes == 1f && isReloading == false){
			 isReloading = false;
			StartCoroutine(RocketAttack());
			isReloading = true;
		 }
		 if(rocketTimes == 0f && isReloading == true){
			 StartCoroutine(ReloadAttacks());
			 isReloading = false;
		 }
		// -- -- - -- - - -- - -
		if(isMove){
			animator.SetTrigger("walk");
			// if (Time.time - walkStartTime > 2.0f) {
			// 	MoveSpeed = 5f;
			// 	animator.SetTrigger("run");
			// } else {
			// 	animator.SetTrigger("walk");
			// }
		}
		if(!isMove){
			//animator.ResetTrigger("walk");
			animator.SetBool("backidle",true);
		}
		Flip();
	}
	public void MoveEnemy(){
		isMove = true;
		transform.position = new Vector3(Vector3.MoveTowards(transform.position, target.position, MoveSpeed * Time.deltaTime ).x, transform.position.y);

		animator.SetBool("backidle",false);

	}
	public void HitEnemy(){
		animator.SetTrigger("skill_1");
	}
	public void Flip()
	{

			if (target.position.x < transform.position.x)
					transform.localScale = new Vector3(fx, fy, fz);
			else if (target.position.x > transform.position.x)
					transform.localScale = new Vector3(-fx, fy, fz);
	}

}
