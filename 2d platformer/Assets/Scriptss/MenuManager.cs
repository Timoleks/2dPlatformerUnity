using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour {

		AudioManager audioManager;

		[SerializeField]
		string hoverOverSound = "ButtonHover";

		[SerializeField]
		string ButtonPressSound = "ButtonPress";

		void Start(){
			audioManager = AudioManager.instance;
			if(audioManager == null){
				Debug.LogError("No audiomanager");
			}
		}
		public void StartGame(){
			audioManager.PlaySound(ButtonPressSound);
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
		public void QuitGame(){
			audioManager.PlaySound(ButtonPressSound);
			Application.Quit();
		}

		public void OnMouseOver(){
			audioManager.PlaySound(hoverOverSound);
		}

}
