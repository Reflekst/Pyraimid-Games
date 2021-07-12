using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    [SerializeField] private GameObject startMenu,scoreMenu, endGamePanel;
    [SerializeField] private Text timerText, yourScoreText, bestScoreText;
    [SerializeField] private Button restartGameButton, startGameButton;

    private float startTime;
    void Start()
    {
        restartGameButton.onClick.AddListener(RestartGame);
        startGameButton.onClick.AddListener(StartGame);
        startMenu.SetActive(true);
        scoreMenu.SetActive(false);
        endGamePanel.SetActive(false);
        bestScoreText.text = "-";
    }

    void Update()
    {
        float t = Time.time - startTime;

        //string minutes = ((int)t / 60).ToString();
        //string seconds = (t % 60).ToString();

        //timerText.text = minutes + ":" + seconds;
        timerText.text = t.ToString();
    }

    public void DisplayEndGamePanel()
    {
        endGamePanel.SetActive(true);
        yourScoreText.text = timerText.text;
        if (bestScoreText.text == "-")
        {
            bestScoreText.text = yourScoreText.text;
        }
        else if (int.Parse(yourScoreText.text) <  int.Parse(bestScoreText.text))
        {
            bestScoreText.text = yourScoreText.text;
        }
    }
    
    public void StartGame()
    {
        startMenu.SetActive(false);
        startTime = Time.time;
        scoreMenu.SetActive(true);
        endGamePanel.SetActive(false);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
