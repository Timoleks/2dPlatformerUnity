using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverUI : MonoBehaviour {

	public void Quit(){
		// Application.Quit();
		SceneManager.LoadScene(0);
	}
	public void Retry(){
		Application.LoadLevel(Application.loadedLevel);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

	}
}
