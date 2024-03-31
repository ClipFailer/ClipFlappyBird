using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    int playerScore;
    static int higherScore;
    static int deathNumber;

    [SerializeField] Text scoreText;
    [SerializeField] Text highestScoreText;
    [SerializeField] Text deathsNumberText;
    [SerializeField] GameObject gameOverScreen;

    [SerializeField] BirdScript bird;

    [SerializeField] AudioSource[] sounds;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
            highestScoreText.text += PlayerPrefs.GetInt("higherScore");
        else
        {
            playerScore = 0;
            scoreText.text = $"Score: {playerScore}";
            highestScoreText.text = $"Higher Score: {PlayerPrefs.GetInt("higherScore")}";
        }

        deathsNumberText.text += PlayerPrefs.GetInt("deathsNumber");
    }

    [ContextMenu("Increase score")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;

        if (PlayerPrefs.GetInt("higherScore") < playerScore)
            PlayerPrefs.SetInt("higherScore", playerScore);

        scoreText.text = $"Score: {playerScore}";
        highestScoreText.text = $"Higher Score: {PlayerPrefs.GetInt("higherScore")}";
        sounds[0].Play();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        sounds[1].Play();
        deathNumber++;
        PlayerPrefs.SetInt("deathsNumber", deathNumber);
        deathsNumberText.text = $"Number Of Deaths: {PlayerPrefs.GetInt("deathsNumber")}";
    }

    public void startGame()
    {

        SceneManager.LoadScene("Game");    
    }

    public void backToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void resetScore()
    {
        deathNumber = 0;
        higherScore = 0;
        PlayerPrefs.SetInt("higherScore", higherScore);
        PlayerPrefs.SetInt("deathsNumber", deathNumber);
        highestScoreText.text = $"Highest Score: {PlayerPrefs.GetInt("higherScore")}";
        deathsNumberText.text = $"Number Of Deaths: {PlayerPrefs.GetInt("deathsNumber")}";
    }

    public void exitGame()
    {
        Application.Quit();
        Debug.Log("Quitting.");
    }
}
