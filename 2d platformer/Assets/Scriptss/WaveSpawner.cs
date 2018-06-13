using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {


	public enum SpawnState{SPAWNING,WAITING,COUNTING};

	[System.Serializable]
	public class Wave{
		public string name;
		public Transform enemy;
		public int count;
		public float rate;

	}
	public Wave[] waves;
	WaveUI waveAnimator;
	public int nextWave = 0;
	public int NextWave{
		get {return nextWave + 1;}
	}
	public float timeBetweenWaves = 4f;
	public Transform[] spawnPoints;
	private float waveCountDown;
	public float WaveCountDown{
		get {return waveCountDown;}
	}
	private float searchCountdown = 1f;
	private SpawnState state = SpawnState.COUNTING;
	public SpawnState State{
		get { return state;}
	}

	void Start(){
		waveCountDown = timeBetweenWaves;

	}
	void Update(){
		if(state == SpawnState.WAITING){
			if(!EnemyIsAlive()){
				WaveCompleted();
			}
			else{
				return;
			}
		}
		if(waveCountDown <=0){
			if (state != SpawnState.SPAWNING ){
					StartCoroutine(SpawnWave(waves[nextWave]));
			}
		}
			else{
				waveCountDown -= Time.deltaTime;
			}
			if(nextWave == 2 ){
				GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyAI>().speed = 1500;
			}
			if(nextWave == 3){
				GameObject.FindGameObjectWithTag("wcdo").SetActive(false);
			}
	}

	void WaveCompleted(){
		//SDebug.Log("Wolna proidena");
		state = SpawnState.COUNTING;

		waveCountDown = timeBetweenWaves;
		if(nextWave + 1>waves.Length - 1){
			nextWave = 0;
			//Debug.Log("Wolni proideni");
		}
		else{
			nextWave++;
		}

	}
	public bool EnemyIsAlive(){
		searchCountdown -= Time.deltaTime;
		if(searchCountdown <=0f)
		{
			searchCountdown = 1f;
		if(GameObject.FindGameObjectWithTag("Enemy") == null){
			return false;
		}
	}
			return true;
	}

	IEnumerator SpawnWave(Wave _wave){
		//Debug.Log("Spawn wolni:" + _wave.name );
		state = SpawnState.SPAWNING;

		for(int i = 0 ; i < _wave.count;i++){
			SpawnEnemy(_wave.enemy);
			yield return new WaitForSeconds(1f/_wave.rate);
		}

		state = SpawnState.WAITING;
		yield break;
	}

 	void SpawnEnemy(Transform _enemy){
		//Debug.Log("Spawn vragov:" + _enemy.name);

		Transform _sp = spawnPoints[ Random.Range(0,spawnPoints.Length)];
		Instantiate(_enemy,_sp.position,_sp.rotation);

	}

}
