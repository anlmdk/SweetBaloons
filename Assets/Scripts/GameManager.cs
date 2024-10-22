using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int CurrentScore { get; set; }

    public Image nextBaloonImage;
    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private GameObject gameStartPanel;
    [SerializeField] private GameObject gameOverPanel;


    public bool gameStart = false;
    public static bool gameReset = false;

    public float TimeTillGameOver = 1.5f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void IncreaseScore(int amount)
    {
        CurrentScore += amount;
        scoreText.text = CurrentScore.ToString("0");
    }

    public void GameStart()
    {
        gameStartPanel.SetActive(false);
        gameStart = true;
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void ResetGame()
    {
        gameReset = true;
        gameStart = false;
        CurrentScore = 0;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnEnable()
    {
        // Sahne y�klendi�inde �a�r�lan fonksiyonu dinle
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // Sahne y�klendi�inde �a�r�lan fonksiyonu kald�r
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Sahne y�klendi�inde referanslar� yeniden ayarlay�n
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Sahnedeki UI elemanlar�n� yeniden bul
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        gameStartPanel = GameObject.Find("GameStartPanel");
        gameOverPanel = GameObject.Find("GameOverPanel");
        nextBaloonImage = GameObject.Find("NextBaloon").GetComponent<Image>();

        // Skoru g�ncelle
        scoreText.text = CurrentScore.ToString("0");

        // E�er oyun resetlendiyse gameStartPanel'i kapat
        if (!gameReset)
        {
            gameStartPanel?.SetActive(true);
        }
        else
        {
            gameStartPanel?.SetActive(false);
            gameReset = false;

            // Balon tag�na ait t�m nesneleri yok et
            GameObject[] baloons = GameObject.FindGameObjectsWithTag("Baloon");
            foreach (GameObject baloon in baloons)
            {
                Destroy(baloon);
            }
        }

        gameOverPanel?.SetActive(false);

    }
}
