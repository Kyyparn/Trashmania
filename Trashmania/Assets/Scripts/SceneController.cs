using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {


	public void GoToMain() {
		SceneManager.LoadScene("MainMenu");
        MusicManager.instance.MenuTheme();
        MusicManager.instance.ResetMusic();
    }

	public void GoToGame() {
		SceneManager.LoadScene("GameScene");
        MusicManager.instance.ExitMenu();

        Cursor.visible = false;
    }

	public void EndGame() {
		Application.Quit();
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#endif
	}
}
