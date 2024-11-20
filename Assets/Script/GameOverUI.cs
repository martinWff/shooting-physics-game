using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private string textScore;
    // Start is called before the first frame update
    void Awake()
    {
        ScoreData scoreData = FindObjectOfType<ScoreData>();

        textScore = scoreText.text;

        scoreText.text = string.Format(textScore, scoreData.highestScore, scoreData.lastScore);
        Cursor.lockState = CursorLockMode.None;

    }

    public void SetText()
    {
        ScoreData scoreData = FindObjectOfType<ScoreData>();

        scoreText.text = string.Format(textScore, scoreData.highestScore, scoreData.lastScore);
        Cursor.lockState = CursorLockMode.None;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(1);
    }

 
}
