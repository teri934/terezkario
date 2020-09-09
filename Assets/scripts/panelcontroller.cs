using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class panelcontroller : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject GameOverPanel;
    public GameObject WinPanel;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        hidePaused();
        GameOverPanel.SetActive(false);
        WinPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                showPaused();
            }
            else
            {
                Time.timeScale = 1;
                hidePaused();
            }
        }
    }

    public void hidePaused()
    {
        PausePanel.SetActive(false);
    }

    public void showPaused()
    {
        PausePanel.SetActive(true);
    }

    public void pauseControl()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            hidePaused();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        GameOverPanel.SetActive(true);
    }

    public void Win()
    {
        Time.timeScale = 0;
        WinPanel.SetActive(true);
    }
}

