using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;

    // Start is called before the first frame update
    void Start()
    {
        // Add listeners for buttons
        button1.onClick.AddListener(() => OnButtonPressed(button1));
        button2.onClick.AddListener(() => OnButtonPressed(button2));
        button3.onClick.AddListener(() => OnButtonPressed(button3));
        button4.onClick.AddListener(() => OnButtonPressed(button4));
        button5.onClick.AddListener(() => OnButtonPressed(button5));
    }

    void OnButtonPressed(Button pressedButton)
    {
        // Switch case based on button's name or tag
        switch (pressedButton.name)
        {
            case "Level01":
                // Debug.Log("Button 1 was pressed");
                // Handle button 1 logic here
                LevelSelect(1);
                break;
            case "Level02":
                // Debug.Log("Button 2 was pressed");
                // Handle button 2 logic here
                LevelSelect(2);
                break;
            case "Level03":
                //Debug.Log("Button 3 was pressed");
                // Handle button 3 logic here
                LevelSelect(3);
                break;
            case "OptionsButton":
                Options();
                break;
            case "ExitButton":
                Debug.Log("Exited");
                Application.Quit();
                break;
            default:
                Debug.Log("Unknown button pressed");
                break;
        }


        
    }
    public void LevelSelect(int level)
    {
        foreach (var scene in SceneManagerHistory.Instance.sceneHistory)
        {
            Debug.Log(scene);
        }
        string result = "Level0" + level.ToString();
        SceneManagerHistory.Instance.LoadScene(result);
    }

    public void Options()
    {
        foreach (var scene in SceneManagerHistory.Instance.sceneHistory)
        {
            Debug.Log(scene);
        }
        SceneManagerHistory.Instance.LoadScene("Options");
    }
}
