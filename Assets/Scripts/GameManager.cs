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
    public int BestScore { get; private set; }

    public Image nextBaloonImage;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;

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

        LoadBestScore();
    }

    private void Start()
    {
        InvokeRepeating("SaveGame", 30f, 10f);
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
        GameModule.Instance.GameplayStart();
    }

    public void GameOver()
    {
        AdInterstitialModule.Instance.AdModuleInterstitial();
        PlayerController player = FindAnyObjectByType<PlayerController>();
        player.enabled = false;

        gameOverPanel.SetActive(true);
        GameModule.Instance.GameplayStop();
        GameModule.Instance.Happytime();
        SaveBestScore();
    }

    public void ResetGame()
    {
        gameReset = true;
        gameStart = false;

        CurrentScore = 0;
        scoreText.text = CurrentScore.ToString("0");
        PlayerController player = FindAnyObjectByType<PlayerController>();
        player.enabled = true;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SaveGame()
    {
        PlayerPrefs.SetInt("CurrentScore", CurrentScore);
        PlayerPrefs.Save();
        Debug.Log("Oyun kaydedildi: Skor = " + CurrentScore);
    }

    private void SaveBestScore()
    {
        if (CurrentScore > BestScore)
        {
            BestScore = CurrentScore;
            PlayerPrefs.SetInt("BestScore", BestScore);
            PlayerPrefs.Save();
            Debug.Log("Yeni rekor: " + BestScore);
        }
    }

    public void LoadBestScore()
    {
        if (PlayerPrefs.HasKey("BestScore"))
        {
            BestScore = PlayerPrefs.GetInt("BestScore");
        }
        else
        {
            BestScore = 0;
        }
        Debug.Log("Yüklenen Best Score: " + BestScore);
    }

    private void OnEnable()
    {
        // Sahne yüklendiðinde çaðrýlan fonksiyonu dinle
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // Sahne yüklendiðinde çaðrýlan fonksiyonu kaldýr
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Sahne yüklendiðinde referanslarý yeniden ayarlayýn
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Sahnedeki UI elemanlarýný yeniden bul
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        bestScoreText = GameObject.Find("BestScoreText").GetComponent<TextMeshProUGUI>();

        gameStartPanel = GameObject.Find("GameStartPanel");
        gameOverPanel = GameObject.Find("GameOverPanel");
        nextBaloonImage = GameObject.Find("NextBaloon").GetComponent<Image>();

        // Skoru güncelle
        scoreText.text = CurrentScore.ToString("0");
        bestScoreText.text = "Best: " + BestScore.ToString("0");

        // Eðer oyun resetlendiyse gameStartPanel'i kapat
        if (!gameReset)
        {
            gameStartPanel?.SetActive(true);
        }
        else
        {
            gameStartPanel?.SetActive(false);
            gameReset = false;

            // Balon tagýna ait tüm nesneleri yok et
            GameObject[] baloons = GameObject.FindGameObjectsWithTag("Baloon");
            foreach (GameObject baloon in baloons)
            {
                Destroy(baloon);
            }
        }

        gameOverPanel?.SetActive(false);

    }
}
