using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Add this to use the Text component
using TMPro;

public class Manager : MonoBehaviour
{
    [SerializeField] public GameObject[] Levels;
    [SerializeField] public GameObject ResetScreen, End;

    [SerializeField] public int countScore = 0; // Change this to "int" instead of "public"

    [SerializeField] private TextMeshProUGUI finalScoreText; // Add this field for the Text component

    int currentLevel;

    public void wrongAnswer()
    {
        //ResetScreen.SetActive(true);
        nextLevel()
    }

    public void ResetGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void correctAnswer()
    {
        IncreaseScore(); // Increase score when a correct choice is made
        nextLevel();
    }

    public void nextLevel(){

        if (currentLevel + 1 != Levels.Length)
        {
            Levels[currentLevel].SetActive(false);

            currentLevel++;
            Levels[currentLevel].SetActive(true);
        }
        else
        {
            End.SetActive(true);
            Levels[currentLevel].SetActive(false);
            finalScoreText.text = "Final Score: " + countScore; // Display the final score
        }
    }

    // Add this method to increase the score
    private void IncreaseScore()
    {
        countScore += 10; // You can adjust the points awarded for a correct answer here
    }
}
