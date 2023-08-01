using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{


    public GameObject block;
    public Transform spawnPoint;
    public float spawnRate;
    float[] possibleValues = new float[] { -0.6031f, 0.6031f };

    public Sprite[] spriteArray;

    public GameObject TapText;

    public TextMeshProUGUI scoreText;

    public SpriteRenderer spriteRenderer;



    int score;

    private int currentScore = 0;
    private int highestScore = 0;
    private int currentCharacter = 0;
    private const string CurrentCharacterKey = "CurrentCharacter";




    bool gameStarted = false;


    void Start()
    {
        currentCharacter = PlayerPrefs.GetInt(CurrentCharacterKey, 0);
        //currentCharacter = 2;
        Debug.Log("Saved Character Index Game: " + currentCharacter);


        SetCharacterSprite(currentCharacter);
        highestScore = LoadHighestScore();
    }

    public void UpdateScore(int points)
    {
        currentScore = points;
        //currentScore += score;

        //scoreText.text = "Score: " + currentScore;

        SaveCurrentScore(currentScore);

        if (currentScore > highestScore)
        {
            highestScore = currentScore;
            SaveHighestScore(highestScore);
        }
    }

    public void SaveCurrentScore(int currentScore)
    {
        PlayerPrefs.SetInt("CurrentScore", currentScore);
        PlayerPrefs.Save();
    }

    public int LoadHighestScore()
    {
        return PlayerPrefs.GetInt("HighestScore", 0);
    }

    public void SaveHighestScore(int highestScore)
    {
        PlayerPrefs.SetInt("HighestScore", highestScore);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !gameStarted)
        {
            StartSpawning();
            gameStarted = true;
            TapText.SetActive(false);
          
        }
    }


    private void StartSpawning()
    {
        InvokeRepeating("SpawnBlock", 0.5f, spawnRate);
    }

    private void SpawnBlock()
    {

        // First spawn position (x = -0.6031)
        Vector3 spawnPos1 = spawnPoint.position;
        spawnPos1.x = -0.6031f;
        Quaternion rotation1 = Quaternion.Euler(0f, 190f, 0f);
        Instantiate(block, spawnPos1, rotation1);

        // Second spawn position (x = 0.6031)
        Vector3 spawnPos2 = new Vector3(0.6031f, spawnPoint.position.y + 3.1f, 0f);
        Quaternion rotation2 = Quaternion.Euler(0f, 0f, 0f);
        Instantiate(block, spawnPos2, rotation2);

        float randomValue = possibleValues[Random.Range(0, possibleValues.Length)];
        Quaternion rotation4 = Quaternion.Euler(0f, 0f, 0f);

        if (randomValue == -0.6031f)
        {
            rotation4 = Quaternion.Euler(0f, 190f, 0f);

        }
        else
        {
            rotation4 = Quaternion.Euler(0f, 0f, 0f);

        }
        // Fourth spawn position (x = 0.6031)
        //Vector3 spawnPos2 = spawnPoint.position + new Vector3(0.6031f, 1f, 0f); ;
        Vector3 spawnPos4 = new Vector3(randomValue, spawnPoint.position.y + 6.2f, 0f);
        Instantiate(block, spawnPos4, rotation4);

        score++;
        UpdateScore(score);
        scoreText.text = score.ToString();

    }


    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(0);

    }

    public void SetCharacterSprite(int characterIndex)
    {
        spriteRenderer.sprite = spriteArray[characterIndex];
    }

    // Public setter method for currentCharacter
    public void SetCurrentCharacter(int characterIndex)
    {
        currentCharacter = characterIndex;
        // Save the updated value to PlayerPrefs
        PlayerPrefs.SetInt(CurrentCharacterKey, currentCharacter);
        PlayerPrefs.Save(); // Optional: Save immediately (you can also let Unity handle saving at the end of the frame)
    }



}
