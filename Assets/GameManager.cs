using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int score = 0;
    public TMP_Text scoreText; 
    public TMP_Text timerText; 

    private bool isTimerRunning = false;
    private float startTime;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    private void Start()
    {
        UpdateScoreText();
        UpdateTimerText(0); 
    }

    public void UpdateScore(int points)
    {
        score += points;
        UpdateScoreText(); 
        
        if (score >= 4) 
        {
            StopTimer();
        }
    }

    public void StopTimer()
    {
        isTimerRunning = false;
    }

    public void UpdateTimer(float time)
    {
        UpdateTimerText(time); 
    }

    private void UpdateTimerText(float time)
    {
        if (timerText != null)
        {
            timerText.text = "Time: " + time.ToString("F2"); 
        }
    }

    public void StartTimer()
    {
        isTimerRunning = true;
        startTime = Time.time;
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            float timeElapsed = Time.time - startTime;
            UpdateTimer(timeElapsed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartTimer();
        }
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Targets: " + score + "/4"; 
        }
    }

}