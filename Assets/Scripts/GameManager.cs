using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public TextMeshProUGUI scoreText, lifeText;

    private int currentScore = 0;

    private int currentLife = 5;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }

    public void SetScore(int score)
    {
        currentScore += score;
        scoreText.text = "Score: " + currentScore.ToString();
    }

    public void GameOver()
    {
        GameObject gameOverPanel = GameObject.Find("GameOverPanel");

        gameOverPanel.SetActive(true);

        currentLife -= 1;

        lifeText.text = currentLife.ToString();

        Time.timeScale = 0f;
    }
}
