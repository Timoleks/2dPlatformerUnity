using UnityEngine;
using UnityEngine.UI;
public class WaveUI : MonoBehaviour {

	[SerializeField]
	WaveSpawner spawner;

	[SerializeField]
	Animator waveAnimator;

	[SerializeField]
	Text waveCountdownText;

	[SerializeField]
	Text waveCountText;


	private WaveSpawner.SpawnState previousState;
	void Start () {
			if(spawner == null){
				Debug.LogError("nema spawnera");
				this.enabled = false;
			}
			if(waveAnimator == null){
				Debug.LogError("nema waveAnimator");
				this.enabled = false;
			}
			if(waveCountdownText == null){
				Debug.LogError("nema waveCountDownText");
				this.enabled = false;
			}
			if(waveCountText == null){
				Debug.LogError("nema waveCountText");
				this.enabled = false;
			}
			previousState = spawner.State;
	}


	void Update () {
		switch(spawner.State){
			case WaveSpawner.SpawnState.COUNTING:
			// waveAnimator.SetBool("WaveIncoming",false);
			UpdateCountingUI();
			break;
			case WaveSpawner.SpawnState.WAITING:
			UpdateWaitingUI();
			break;
			case WaveSpawner.SpawnState.SPAWNING:
			UpdateSpawningUI();
			break;
		}
		
	}
	void UpdateWaitingUI(){
		if(previousState != WaveSpawner.SpawnState.WAITING && GameObject.FindGameObjectWithTag("Enemy") == null){

			waveAnimator.SetBool("WaveIncoming",false);
			waveAnimator.SetBool("WaveCountdown",true);
	 }

	}
	void UpdateCountingUI() {
		if(previousState != WaveSpawner.SpawnState.COUNTING){
			waveAnimator.SetBool("WaveIncoming",false);
			waveAnimator.SetBool("WaveCountdown",true);
				//Debug.Log("counting");
		}
		waveCountdownText.text = ((int)spawner.WaveCountDown).ToString();

	}
	void UpdateSpawningUI() {
		if(previousState != WaveSpawner.SpawnState.SPAWNING){
			waveAnimator.SetBool("WaveCountdown",false);
			waveAnimator.SetBool("WaveIncoming",true);

			waveCountText.text = spawner.NextWave.ToString();


				//Debug.Log("Spawning");
		}
	}
}
