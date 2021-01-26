using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Scoremanager : MonoBehaviour
{
    GameManagerScript GameManager;
    public TextMeshProUGUI EndScore;
    public int ScoreNumber;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void ChangeScore()
    {
        GameManager = FindObjectOfType<GameManagerScript>();
        ScoreNumber = GameManager.DisplayScore;
    }

    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "GameOver")
        {
            EndScore = FindObjectOfType<TextMeshProUGUI>(GameObject.FindGameObjectWithTag("EndScoreTag"));
            EndScore.text = "Score: " + ScoreNumber;
        }
    }

}
