using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelControllerScript : MonoBehaviour {

	public void PlayGame()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void GoBackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
