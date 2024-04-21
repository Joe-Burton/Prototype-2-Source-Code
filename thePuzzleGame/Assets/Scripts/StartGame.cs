using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public string puzzleName;
    public string titleSceneName = "Main Title";
    public string youWin;
    public string instructions = "Instructions";

    public void LoadLevel()
    {
        SceneManager.LoadScene(puzzleName);
    }
    
    public void LoadTitleScreen()
    {
        SceneManager.LoadScene(titleSceneName);
    }

    public void LoadInstructions()
    {
        SceneManager.LoadScene(instructions);
    }

}

