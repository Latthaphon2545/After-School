using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    public static bool Paused = false;
    public GameObject PausedMenu;
    // Start is called before the first frame update

    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused)
            {
                Play();
            }
            else
            {
                Stop();
            }
        }
    }

    public void Stop()
    {
        PausedMenu.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
    }

    public void Play()
    {
        PausedMenu.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
    }

    public void MainMunuBut()
    {
        Destroy(this.gameObject);
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("MainMenu"); 
    }
}
