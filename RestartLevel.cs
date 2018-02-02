using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
public class RestartLevel : MonoBehaviour {

	private void Update () {
		if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
	}
}
