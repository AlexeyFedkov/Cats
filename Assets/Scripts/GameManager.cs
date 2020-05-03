using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public AudioSource levelMusic;
    public bool onPause;
    public bool isFaled;

    public KeyCode pauseButton = KeyCode.P;
    public GameObject pauseObject;

    [Space] public GameObject gameOverObject;
    public GameObject winObject;
    public GameObject lastShotGameOverInternal;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(pauseButton))
        {
            Pause(true);
        }
    }

    public void Pause(bool isPause)
    {
        onPause = isPause;
        pauseObject.SetActive(isPause);
        Time.timeScale = isPause ? 0 : 1;
    }

    public void TryAgain()
    {
        pauseObject.SetActive(false);
        gameOverObject.SetActive(false);
        winObject.SetActive(false);
        lastShotGameOverInternal.SetActive(false);
        isFaled = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        levelMusic.Play();
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        if (isFaled) return;
        isFaled = true;
        levelMusic.Stop();
        Invoke(nameof(GameOverInternal), 1);
    }

    private void GameOverInternal()
    {
        gameOverObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void Win()
    {
        if (isFaled) return;
        isFaled = true;
        levelMusic.Stop();
        Invoke(nameof(WinInternal), 1);
    }

    private void WinInternal()
    {
        winObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void LastShotGameOver()
    {
        Debug.Log("Last");
        if (isFaled) return;
        isFaled = true;
        levelMusic.Stop();
        Invoke(nameof(LastShotGameOverInternal), 1);
    }

    private void LastShotGameOverInternal()
    {
        lastShotGameOverInternal.SetActive(true);
        Time.timeScale = 0;
    }
}
