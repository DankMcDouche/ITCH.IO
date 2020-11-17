using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMNGR : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(this);
    }
    public void StartMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void StartGameOverScene()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void StartMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
