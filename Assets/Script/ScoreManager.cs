using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] int score;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI endGameScoreText;

    void Awake()
    {
        score = 0;
        UpdateScoreDisplay();
    }
    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreDisplay();
    }

    void UpdateScoreDisplay()
    {
        scoreText.text = "Score: " + score;
        endGameScoreText.text = "Score: " + score;
    }

}
