using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject mainCanvas;
    [SerializeField] GameObject gameOverCanvas;
    [SerializeField] GameObject winGameCanvas;

    public void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
        Time.timeScale = 1;
    }

    public void GameOverScene()
    {
        mainCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
    }

    public void WinGameScene()
    {
        mainCanvas.SetActive(false);
        winGameCanvas.SetActive(true);
    }

    public void MainmenuScene()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
