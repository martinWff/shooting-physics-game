using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public int currentScore { get; private set; }
    public int mainMenuIndex = 1;
    public int gameOverIndex = 3;

    private float timeScale;

    public bool isPaused { get; private set; }

    public UnityEvent onPaused;
    public UnityEvent onResumed;

    private ScoreData scoreData;

    private GameObject player;

    public UnityEvent<string> onPrizeWon;

    // Start is called before the first frame update
    void Awake()
    {
        timeScale = Time.timeScale;
        scoreData = FindObjectOfType<ScoreData>();
        if (scoreData == null)
        {
            scoreData = new GameObject("ScoreData").AddComponent<ScoreData>();
        }

        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void AddScore(int score)
    {
        currentScore += score;
    }

    public void QuitLevel()
    {
        SaveScore();

        LeaveToMainMenu();
    }

    private void SaveScore()
    {
        if (scoreData != null)
        {
            scoreData.TrySetScore(currentScore);
        }
        else
        {
            Debug.LogWarning("Couldn't quick save the score due to the ScoreData GameObject not being found");
        }
    }

    private void LeaveToMainMenu()
    {
        Time.timeScale = timeScale;
        SceneManager.LoadScene(mainMenuIndex);
    }

    public void PauseGame()
    {
        timeScale = Time.timeScale;
        Time.timeScale = 0;
        isPaused = true;
        if (onPaused != null)
        {
            onPaused.Invoke();
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = timeScale;
        isPaused = false;
        if (onResumed != null)
        {
            onResumed.Invoke();
        }
    }

    public void ChangePauseState()
    {
        if (isPaused)
        {
            ResumeGame();
        } else
        {
            PauseGame();
        }
    }

    public void SetGameOver()
    {
        SaveScore();
        SceneManager.LoadScene(gameOverIndex);
    }

    public void Reward(PrizeObject prize)
    {
        if (prize != null)
        {
            prize.Reward(player);
            if (onPrizeWon != null)
            {
                onPrizeWon.Invoke(prize.GetPrizeText());
            }
        }
    }
}
