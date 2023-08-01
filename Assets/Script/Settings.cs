using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class Settings : MonoBehaviour
{

    public GameObject[] characters = new GameObject[4];


    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }

    // Start is called before the first frame update
    void Start()
    {
        int savedCharacterIndex = PlayerPrefs.GetInt("CurrentCharacter");
        selecting(savedCharacterIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    // Button click events to change the character index
    public void OnClickCharacter1()
    {
        SetCurrentCharacter(0);
        selecting(0);

    }

    public void OnClickCharacter2()
    {
        SetCurrentCharacter(1);
        selecting(1);

    }

    public void OnClickCharacter3()
    {
        SetCurrentCharacter(2);
        selecting(2);
    }

    public void OnClickCharacter4()
    {
        SetCurrentCharacter(3);
        selecting(3);

    }



    private void selecting(int character)
    {
        // Get the Button component of the character at savedCharacterIndex
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(characters[character]);

        //Button characterButton = characters[character].GetComponent<Button>();

        //// Check if the characterButton is not null before calling OnSelect to avoid errors
        //if (characterButton != null)
        //{
        //    // Simulate a selection event on the characterButton
        //    characterButton.OnSelect(null);
        //}
    }



    public void SetCurrentCharacter(int characterIndex)
    {
        audioManager.PlaySFX(audioManager.click);
        // Save the updated value to PlayerPrefs
        PlayerPrefs.SetInt("CurrentCharacter", characterIndex);
        PlayerPrefs.Save(); // Optional: Save immediately (you can also let Unity handle saving at the end of the frame)

        // Retrieve the saved value and log it to the console
        int savedCharacterIndex = PlayerPrefs.GetInt("CurrentCharacter");
        Debug.Log("Saved Character Index: " + savedCharacterIndex);


    }


}
