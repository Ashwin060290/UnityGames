using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayScript : MonoBehaviour {

    [SerializeField]
    private GameObject pausePanel;

    [SerializeField]
    private Button resumeButton;

    public void PuaseGame()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        resumeButton.onClick.RemoveAllListeners();
        resumeButton.onClick.AddListener(() => ResumeGame());
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GamePlay");
    }

    public void PlayerDied()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        resumeButton.onClick.RemoveAllListeners();
        resumeButton.onClick.AddListener(() => RestartGame());
    }
}
