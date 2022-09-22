using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject leader;

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        // Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Leaderboard()
    {
        leader.SetActive(true);
    }

    public void CloseLeader()
    {
        leader.SetActive(false);
    }
}
