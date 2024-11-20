using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingBehaviour : MonoBehaviour
{
    public int nextScene;
    public ScoreData scoreData;

    // Start is called before the first frame update
    void Start()
    {
        scoreData.LoadData();
        SceneManager.LoadScene(nextScene);
    }

}
