
using UnityEngine;
using UnityEngine.SceneManagement;
public class goNextFuckingLevel : MonoBehaviour {

	public LevelChanger fadeOut;
	void OnTriggerEnter2D(Collider2D shit){
		if(shit.gameObject.tag == "Player"){
			fadeOut.FadeToLevel(2);
			GameMaster.maxLives = 1;
		}
	}
}
