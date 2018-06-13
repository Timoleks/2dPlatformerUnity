using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

	public  UpgradeMenu uM;
	public static GameMaster gm;
	public Weapon wp;
	public movingPlatform goNextlvl;
	public static int maxLives = 3;
	public static int _remainingLives ;
	public static int RemainingLives{
		get{
			return _remainingLives;
		}
	}
	[SerializeField]
	private WaveSpawner waveSpawner;

	void Awake(){
		if(gm == null){
			gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
		}
		wp = GameObject.FindGameObjectWithTag("Weapon").GetComponent<Weapon>();
		//uM = GameObject.FindGameObjectWithTag("uM").GetComponent<UpgradeMenu>();
	}

	public Transform playerPrefab;
	public Transform spawnPoint;
	public int spawnDelay = 2;
	public float spawnEnemyDelay = 1.5f;
	public Transform spawnPrefab;
	public CameraShake cameraShake;
	public string Respawn = "Spawn";
	public string MusicGame = "MusicGame";
	[SerializeField]
	private GameObject gameOverUI;
	[SerializeField]
	public GameObject upgradeMenu;

	//cache
  AudioManager audioManager;
	public string enemyExplosionSound = "Explosion";
	public delegate void UpgradeMenuCallback(bool active);
	public UpgradeMenuCallback OnShowUpgradeMenu;

	void Start(){
		if(cameraShake == null){
			Debug.LogError("No cameraShake object");
		}
		_remainingLives = maxLives;
		audioManager = AudioManager.instance;

		if(audioManager == null){
			Debug.LogError("No audiomanager in scene");
		}
	}
	public void EndGame(){
		Debug.Log("gg");
		gameOverUI.SetActive(true);
	}
	void Update(){
		if(Input.GetKeyDown(KeyCode.Q)){
			ShowUpgradeMenu();
		}
		if(waveSpawner.nextWave == 3){
			waveSpawner.enabled = false;
			goNextlvl.enabled = true;
		}
	}
	void ShowUpgradeMenu(){
		upgradeMenu.SetActive(!upgradeMenu.activeSelf);
		waveSpawner.enabled = !upgradeMenu.activeSelf;
		OnShowUpgradeMenu.Invoke(upgradeMenu.activeSelf);
		//GameObject.FindGameObjectWithTag("PressQ").SetActive(false);
	}
	public IEnumerator _RespawnPlayer(){
		yield return new WaitForSeconds(spawnDelay);
		audioManager.PlaySound(Respawn);
		Instantiate(playerPrefab,spawnPoint.position,spawnPoint.rotation);

		Transform clone = Instantiate(spawnPrefab,spawnPoint.position,spawnPoint.rotation) as Transform;
		Destroy(clone.gameObject,3f);
	}
	public static void KillPlayer(Player player){
		Destroy(player.gameObject);
		_remainingLives--;
		if(_remainingLives <= 0){
			gm.EndGame();
		}else
		{
				gm.StartCoroutine(gm._RespawnPlayer());
		}

	}
	public static void KillEnemy(Enemy enemy){
		gm._KillEnemy(enemy);

	}
	public  void _KillEnemy(Enemy _enemy)
	{
		Transform _clone = Instantiate(_enemy.deathParticles,_enemy.transform.position,Quaternion.identity) as Transform;
		Destroy(_clone.gameObject,3f);
		cameraShake.Shake(_enemy.shakeAmt,_enemy.shakeLength);
		Destroy(_enemy.gameObject);
		audioManager.PlaySound(enemyExplosionSound);
		uM.money += _enemy.moneyDrop;
	}

}
