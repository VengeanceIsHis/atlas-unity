using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinMenu : MonoBehaviour
{
    public Button MenuButton;
    public Button NextButton;


    // Start is called before the first frame update
    void Start()
    {
        MenuButton.onClick.AddListener(() => OnButtonPressed(MenuButton));
        NextButton.onClick.AddListener(() => OnButtonPressed(NextButton));
    }


    public void MainMenu()
    {
        SceneManagerHistory.Instance.LoadScene("MainMenu");
    }

    public void Next()
    {
        Debug.Log("Hi");
        switch (SceneManager.GetActiveScene().name)
        {
            case "Level01":
                SceneManagerHistory.Instance.LoadScene("Level02");
                break;
            case "Level02":
                SceneManagerHistory.Instance.LoadScene("Level03");
                break;
            case "Level03":
                SceneManagerHistory.Instance.LoadScene("MainMenu");
            break;
            default:
                break;
        }
    }
    void OnButtonPressed(Button pressedButton)
    {
        switch (pressedButton.name)
        {
            case "MenuButton":
                MainMenu();
                break;
            case "NextButton":
                Next();
                break;
            default:
                break;
        }
    }


}
