using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{

    public int playScore = 0;
    public Text scoreText;
    public GameObject gameOverScreen;

    public AudioSource die;


    // [ContextMenu("Increase Score")]
    public void addScore()
    {
        playScore++;
        scoreText.text = playScore.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        die.Play();
    }
}
