using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager :  Singleton<UIManager>
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject finnalPanel;
    [SerializeField] private GameObject gameOverPanel;

    public void SetScoreText(string txt)
    {
        if (scoreText)
        {
            scoreText.text = txt;
        }
    }

    public void ShowFinnalPanel(bool isShow)
    {
        if (finnalPanel)
        {
            finnalPanel.SetActive(isShow);
        }
    }

    public void ShowGameOverPanel(bool isShow)
    {
        if (gameOverPanel)
        {
            gameOverPanel.SetActive(isShow);
        }
    }
}
