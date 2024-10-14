using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public void PlayMaze()
    {
        SceneManager.LoadScene("maze"); 
    }

   
    public void OpenOptions()
    {
        SceneManager.LoadScene("OptionsScene"); 
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}