using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Canvas Menu;
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;

    // Start is called before the first frame update
    void Start()
    {
        button1.onClick.AddListener(() => OnButtonPressed(button1));
        button2.onClick.AddListener(() => OnButtonPressed(button2));
        button3.onClick.AddListener(() => OnButtonPressed(button3));
        button4.onClick.AddListener(() => OnButtonPressed(button4));
    }
    public void Pause()
    {
        Time.timeScale = 0;
        Menu.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;

    }
    public void Resume()
    {
        Time.timeScale = 1;
        Menu.gameObject.SetActive(false);
    }

    public void Restart()
    {
        Scene current = SceneManager.GetActiveScene();
        SceneManagerHistory.Instance.LoadScene(current.name);
    }
    public void MainMenu()
    {
        SceneManagerHistory.Instance.LoadScene("MainMenu");
    }
    public void Options()
    {
        
        SceneManagerHistory.Instance.LoadScene("Options");
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }
    void OnButtonPressed(Button pressedButton)
    {
        switch (pressedButton.name)
        {
            case "ResumeButton":
                Resume();
                break;
            case "RestartButton":
                Restart();
                break;
            case "MenuButton":
                MainMenu();
                break;
            case "OptionsButton":
                Options();
                break;
            default:
                break;
        }
    }
}
