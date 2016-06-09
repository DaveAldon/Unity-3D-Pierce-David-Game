using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; //Resource needed to do scene management for loading scenes

public class NewGameButton : MonoBehaviour {

	public void SetActive (bool loadRequest) {
		if (loadRequest == true) {
			SceneManager.LoadScene ("2"); //Loads a scene with the given name as a String
		}
	}
}
