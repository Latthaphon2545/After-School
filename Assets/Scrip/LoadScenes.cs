using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LoadScenes : MonoBehaviour
{
    public string sceneName;
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Level()
    {
        Destroy(this.gameObject);
        SceneManager.LoadScene("LevelSclect");
    }

    public void Back()
    {
        Destroy(this.gameObject);
        SceneManager.LoadScene("MainMenu");
    }
}
