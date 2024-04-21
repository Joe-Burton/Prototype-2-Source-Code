using UnityEngine;
using UnityEngine.UI;

public class SubmitButton : MonoBehaviour
{
    public InputField NameEntry; // Reference to the InputField where the player enters their name
    public HighScoreManager highScoreManager; // Reference to the script responsible for managing high scores
    public Timer timerScript; // Reference to the Timer script
    public Text timeText; // Reference to the UI Text element to display the player's time

    public void OnSubmitButtonClick()
    {
        string playerName = NameEntry.text; // Get the player's name from the input field
        float bestTime = timerScript.GetElapsedTime(); // Get the elapsed time from the Timer script

        // Call the SaveScore method in the HighScoreManager script
        highScoreManager.SaveScore(playerName, bestTime);

        // Update the UI Text element with the player's time
        UpdateTimeText(bestTime);
    }

    private void UpdateTimeText(float time)
    {
        // Format the time into a string representation
        string formattedTime = FormatTime(time);

        // Update the text of the UI Text element with the formatted time
        timeText.text = "Time: " + formattedTime;
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        int milliseconds = Mathf.FloorToInt((time * 1000f) % 1000f);

        return string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }
}