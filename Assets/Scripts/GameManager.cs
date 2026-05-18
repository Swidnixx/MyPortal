using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    public int time = 60;
    public int points;
    public int redKeys, greenKeys, goldKeys;

    public GameObject pausePanel;    
    public GameObject winPanel;    
    public GameObject losePanel;

    public Text timeText;
    public Text diamondsText;
    public Text redKeysText;
    public Text greenKeysText;
    public Text goldKeysText;
    public Image freezeImg;

    bool paused;
    bool gameFinished;

    private void Start()
    {
        InvokeRepeating(nameof(Stopper), 3, 1);
    }

    void UpdateUI()
    {
        timeText.text = time.ToString();
        diamondsText.text = points.ToString();
        redKeysText.text = redKeys.ToString();
        greenKeysText.text = greenKeys.ToString();
        goldKeysText.text = goldKeys.ToString();
    }

    private void Update()
    {
        if(gameFinished)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Time.timeScale = 1;
            }
            return;
        }

        if(Input.GetButtonDown("Cancel"))
        {
            if (paused)
                Resume();
            else
                Pause();
        }

        UpdateUI();
    }

    void Pause()
    {
        paused = true;
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    void Resume()
    {
        paused = false;
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    void Stopper()
    {
        freezeImg.enabled = false;
        time--;
        if(time < 1)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        CancelInvoke();
        losePanel.SetActive(true);
        gameFinished = true;
        Time.timeScale = 0;
    }

    public void Win()
    {
        CancelInvoke();
        winPanel.SetActive(true);
        gameFinished = true;
        Time.timeScale = 0;
    }

    public void AddTime(int timeToAdd)
    {
        time += timeToAdd;
        if (time < 1)
            time = 1;

    }

    public void AddKey(KeyType color)
    {
        switch (color)
        {
            case KeyType.Bronze:
                redKeys++;
                break;
            case KeyType.Silver:
                greenKeys++;
                break;
            case KeyType.Gold:
                goldKeys++;
                break;
        }
    }

    public void FreezeTime(int time)
    {
        freezeImg.enabled = true;
        CancelInvoke();
        InvokeRepeating(nameof(Stopper), time, 1);
    }

    internal void UseKey(KeyType key)
    {
        switch (key)
        {
            case KeyType.Bronze:
                redKeys--;
                break;
            case KeyType.Silver:
                greenKeys--;
                break;
            case KeyType.Gold:
                goldKeys--;
                break;
        }
    }

    internal bool HasKey(KeyType properKey)
    {
        switch (properKey)
        {
            case KeyType.Bronze:
                return redKeys > 0;
            case KeyType.Silver:
                return greenKeys > 0;
            case KeyType.Gold:
                return goldKeys > 0;
        }
        return false;
    }
}
