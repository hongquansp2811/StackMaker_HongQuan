using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    public enum SceneName
    {
        Level1 = 1,
        Level2 = 2,
        Level3 = 3,
        Level4 = 4,
        Level5 = 5,
    }

    public SceneName currentScene;

    public void Start()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        if (Enum.TryParse(sceneName, out SceneName scene))
        {
            currentScene = scene;
        }
    }

    public void NextLevel()
    {
        // Chuyển đến Scene kế tiếp
        currentScene = (SceneName)(((int)currentScene) + 1);

        // Kiểm tra xem Scene kế tiếp có tồn tại hay không
        if (SceneManager.GetSceneByName(currentScene.ToString()) != null)
        {
            // Load Scene kế tiếp
            SceneManager.LoadScene(currentScene.ToString());
        }
        else
        {
            Debug.LogWarning("Không có Scene tiếp theo.");
        }
    }

    public void RePlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
