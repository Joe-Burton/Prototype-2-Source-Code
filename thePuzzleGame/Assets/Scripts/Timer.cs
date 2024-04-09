using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private float elapsedTime = 0f;
    private bool timerActive = false;
    public TMP_Text timerText;

    void Start()
    {
        StartTimer();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (timerActive)
                StopTimer();
            else
                StartTimer();
        }

        if (timerActive)
        {
            elapsedTime += Time.deltaTime;
            timerText.text = elapsedTime.ToString("F2");
        }
    }

    void StartTimer()
    {
        timerActive = true;
        Debug.Log("Timer started");
    }

    void StopTimer()
    {
        timerActive = false;
        Debug.Log("Timer stopped at: " + elapsedTime.ToString("F2"));
        // You can put any other actions you want to happen when the timer is stopped manually here
    }
}