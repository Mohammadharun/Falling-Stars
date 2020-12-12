using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverUI;
    public Text secondsSurvivesText;
    bool gameOver;

    private void Start()
    {
        FindObjectOfType<Player>().OnPlayerDeath += OnGameOver;
    }

    private void Update()
    {
        if(gameOver)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    void OnGameOver()
    {
        gameOverUI.SetActive(true);
        secondsSurvivesText.text = Mathf.Round(Time.timeSinceLevelLoad).ToString();
        gameOver = true;
    }
}
