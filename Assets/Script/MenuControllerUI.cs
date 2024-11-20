using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MenuControllerUI : MonoBehaviour
{
    [SerializeField] int gameSceneIndex;
    [SerializeField] GameObject warningPanel;

    public UnityEvent onScoreReseted;

    public void OnPlay()
    {
        SceneManager.LoadScene(gameSceneIndex);
    }

    public void OnQuit()
    {
        Application.Quit();
    }

    public void ResetScore()
    {
        ScoreData scoreData = FindObjectOfType<ScoreData>();
        scoreData.ResetData();
        if (onScoreReseted != null)
        {
            onScoreReseted.Invoke();
        }
    }


}
