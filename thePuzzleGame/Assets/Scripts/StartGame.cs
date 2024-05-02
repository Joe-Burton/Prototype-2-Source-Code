using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public string puzzleName;
    public string titleSceneName = "Main Title";

    public void LoadLevel()
    {
        SceneManager.LoadScene(puzzleName);
    }
    
    public void LoadTitleScreen()
    {
        SceneManager.LoadScene(titleSceneName);
    }
}

