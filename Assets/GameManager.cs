using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int score = 0;
    public TMP_Text scoreText; // Reference to the TextMeshPro component
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keeps this object across scenes
        }
        else
        {
            Destroy(gameObject); // Prevent duplicates
        }
    }

    private void Start()
    {
        UpdateScoreText(); // Initialize the UI with the current score
    }

    public void UpdateScore(int points)
    {
        score += points;
        UpdateScoreText(); // Update the UI whenever the score changes
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Targets: " + score + "/10"; // Update the text
        }
    }
}