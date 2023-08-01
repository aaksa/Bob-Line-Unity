using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{


    GameManager gameManager;


    private int currentScore = 0;
    private int highestScore = 0;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;



    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);

    }

    public void gotoMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    // Start is called before the first frame update
    void Start()
    {
        highestScore = LoadHighestScore();
        currentScore = LoadCurrentScore();
        scoreText.text = "Score  " + currentScore.ToString();
        bestScoreText.text = "Best Score  " + highestScore.ToString();
    }
    public int LoadHighestScore()
    {
        return PlayerPrefs.GetInt("HighestScore", 0);
    }
    public int LoadCurrentScore()
    {
        return PlayerPrefs.GetInt("CurrentScore", 0);
    }

}
