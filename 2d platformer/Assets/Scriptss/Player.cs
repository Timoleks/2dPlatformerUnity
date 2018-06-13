using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Platformer2DUserControl))]
public class Player : MonoBehaviour {



	public string deathVoice = "DeathVoice";
	public string damageSound = "DamageSound";
	private AudioManager audioManager;
	public int fallBoundary = -20;

	[SerializeField]
	private StatusIndicator statusIndicator;

	private PlayerStats stats;

	void Start()
	{
		stats = PlayerStats.instance;
		stats.curHealth = stats.maxHealth;
		if(statusIndicator == null){
			Debug.LogError("No statusIndicator object");
		}
		else{
			statusIndicator.SetHealth(stats.curHealth,stats.maxHealth);
		}
		GameMaster.gm.OnShowUpgradeMenu += OnUpgradeShowMenu;
		audioManager = AudioManager.instance;
		InvokeRepeating("RegenHealth",1f/stats.healthRegenRate,1f/stats.healthRegenRate);
	}
	void Update(){
		if(transform.position.y <= fallBoundary){
			GameMaster.KillPlayer(this);
			audioManager.PlaySound(deathVoice);
		}
	}
	void OnUpgradeShowMenu(bool active){
		GetComponent<Platformer2DUserControl>().enabled = !active;
		Weapon _weapon = GetComponentInChildren<Weapon>();
		if(_weapon != null){
			_weapon.enabled = !active;
		}
	}
	void RegenHealth(){
		stats.curHealth +=1;
		statusIndicator.SetHealth(stats.curHealth,stats.maxHealth);
	}
	void OnDestroy(){
		GameMaster.gm.OnShowUpgradeMenu-= OnUpgradeShowMenu;
	}
	public void DamagePlayer (int damage){
		stats.curHealth -= damage;
		if(stats.curHealth <=0){
			audioManager.PlaySound(deathVoice);
 			GameMaster.KillPlayer(this);

		}
		else{
			audioManager.PlaySound(damageSound);
		}
		statusIndicator.SetHealth(stats.curHealth,stats.maxHealth);
	}

}
