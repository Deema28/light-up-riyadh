using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public int targetScore = 3;

    public GameObject winPanel;
    public SpriteRenderer cityBackground;
    public Sprite lightBackgroundSprite;

    public AudioSource winAudioSource;
    public AudioClip winSound;

    private bool hasWon = false;

    public TMP_Text scoreText;

    private int score = 0;

    void Awake()
    {
        Instance = this;
        UpdateScore();
    }

    public void AddPoint()
    {
        score++;
        UpdateScore();
        if (!hasWon && score >= targetScore)
        {
            WinGame();
        }
    }

    void UpdateScore()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }
    void WinGame()
    {
        hasWon = true;

        
        if (cityBackground != null && lightBackgroundSprite != null)
        {
            cityBackground.sprite = lightBackgroundSprite;
        }

       
        if (winPanel != null)
        {
            winPanel.SetActive(true);
        }

      
        if (winAudioSource != null && winSound != null)
        {
            winAudioSource.PlayOneShot(winSound);
        }

        Time.timeScale = 0f;
    }

}
