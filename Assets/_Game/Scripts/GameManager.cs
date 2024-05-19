using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager :  Singleton<GameManager>
{
    private int scores = 0;
    private bool isFinnal;
    private bool isGameOver;

    private void Start()
    {
        Time.timeScale = 1;
        UIManager.Instance.SetScoreText("Score: " + scores);
    }

    private void Update()
    {
        if (isFinnal)
        {
            UIManager.Instance.ShowFinnalPanel(true);
            Time.timeScale = 0;
        }
        if (isGameOver)
        {
            UIManager.Instance.ShowGameOverPanel(true);
            Time.timeScale = 0;
        }
    }

    public void SetScore(int score)
    {
        scores = score;
    }

    public int GetScore()
    {
        return scores;
    }

    public bool IsFinnal()
    {
        return isFinnal;
    }

    public void SetIsFinnal(bool isFinnal)
    {
        this.isFinnal = isFinnal;
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

    public void SetIsGameOver(bool isGameOver)
    {
        this.isGameOver = isGameOver;
    }

    public void IncrementScore()
    {
        scores++;
        UIManager.Instance.SetScoreText("Score: " + scores);
    }

    public void Replay()
    {
        Time.timeScale = 1;
        scores = 0;
        isFinnal = false;
        UIManager.Instance.SetScoreText("Score: " + scores);
        UIManager.Instance.ShowFinnalPanel(false);
        LevelManager.Instance.RePlay();
    }

    public void NextLevel()
    {
        Time.timeScale = 1;
        LevelManager.Instance.NextLevel();
    }
}
