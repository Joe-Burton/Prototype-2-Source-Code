using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;

public class Timer : MonoBehaviour
{
    private float elapsedTime = 0f;
    private bool timerActive = false;
    public TMP_Text timerText;

    
    void Start()
    {
        StartTimer();
        Debug.Log("TimerText object: " + timerText);
    }

    void Update()
    {
        if (timerActive && timerText != null)
        {
            elapsedTime += Time.deltaTime;

            // Convert elapsed time to minutes, seconds, and milliseconds
            int minutes = Mathf.FloorToInt(elapsedTime / 60f);
            int seconds = Mathf.FloorToInt(elapsedTime % 60f);
            int milliseconds = Mathf.FloorToInt((elapsedTime * 1000f) % 1000f);

            // Update timer text
            timerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);

            // Check for space bar input to stop the timer and load the HighScoreScene
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Space bar pressed!");
                StopTimer();
            }
        }
    }

    public void StartTimer()
    {
        timerActive = true;
        Debug.Log("Timer started");
    }

    public void StopTimer()
    {
        if (timerActive && timerText != null)
        {
            timerActive = false;
            Debug.Log("Timer stopped at: " + timerText.text);
            RecordHighScore(elapsedTime);
            SceneManager.LoadScene("HighScoreScene");
        }
    }

    private void RecordHighScore(float time)
    {
        string filePath = Application.dataPath + "/FastestTime.txt";
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine(time);
        }
        Debug.Log("Fastest time saved to file: " + time);
    }

    public float GetElapsedTime()
    {
        return elapsedTime;
    }
}