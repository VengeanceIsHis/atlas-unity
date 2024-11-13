using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Toggle Toggle;
    // Start is called before the first frame update
    void Awake()
    {
        
    }
    void Start()
    {
        button1.onClick.AddListener(() => OnButtonPressed(button1));
        button2.onClick.AddListener(() => OnButtonPressed(button2));
        
        Toggle.isOn = false;
        
    }

    void OnButtonPressed(Button pressedButton)
    {
        switch (pressedButton.name)
        {
            case "BackButton":
                Back();
                break;
            case "ApplyButton":
                Apply();
                break;
            default:
                break;
        }
    }

    
    public void Back()
    {
        foreach (var scene in SceneManagerHistory.Instance.sceneHistory)
        {
            Debug.Log(scene);
        }
        SceneManagerHistory.Instance.GoBackToPreviousScene();
    }
    public void Apply()
    {
        if (GameManager.Instance.Inverted == true)
        {
            Debug.Log("true");
        }
        foreach (var scene in SceneManagerHistory.Instance.sceneHistory)
        {
            Debug.Log(scene);
        }
        if (Toggle.isOn)
        {
            GameManager.Instance.Inverted = true;
            SceneManagerHistory.Instance.GoBackToPreviousScene();

        }
        else
        {
            GameManager.Instance.Inverted = false;
            SceneManagerHistory.Instance.GoBackToPreviousScene();
        }
        
    }
}
