using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public bool autoLoadNextLevel = false;
	public float loadNextLevelAfter;

	void Start()
	{
		if (autoLoadNextLevel) {
			Invoke("LoadNextLevel", loadNextLevelAfter);
		}
	}

	public void LoadLevel(string sceneName) {
		SceneManager.LoadScene(sceneName);
	}

	//Loads next level by index
	public void LoadNextLevel() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void QuitRequest() {
		Application.Quit();
	}

}
