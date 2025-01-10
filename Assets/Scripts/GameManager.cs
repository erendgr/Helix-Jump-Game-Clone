using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool levelComplete;
    
    public GameObject gameOverPanel;
    public GameObject levelCompletePanel;
    
    public static int currentLevel;
    public static int numberOfPassedRings;
    
    public TextMeshProUGUI currentLevelText;
    public TextMeshProUGUI nextLevelText;
    
    public Slider progressBar;

    private void Awake()
    {
        currentLevel = PlayerPrefs.GetInt("currentLevel", 1);
    }

    void Start()
    {
        Time.timeScale = 1;
        numberOfPassedRings = 0;
        gameOver = false;
        levelComplete = false;
    }


    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(0);
            }
        }
        
        currentLevelText.text = currentLevel.ToString();
        nextLevelText.text = (currentLevel + 1).ToString();
        
        int progress = numberOfPassedRings * 100 / FindObjectOfType<LevelGenerator>().ringAmount;
        progressBar.value = progress;
        
        if (levelComplete)
        {
            levelCompletePanel.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                PlayerPrefs.SetInt("currentLevel", currentLevel + 1);
                SceneManager.LoadScene(0);
            }
        }
    }
}
