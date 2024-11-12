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
    void Start()
    {
        button1.onClick.AddListener(() => OnButtonPressed(button1));
        button2.onClick.AddListener(() => OnButtonPressed(button2));
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
        
        SceneManagerHistory.Instance.GoBackToPreviousScene();
    }
    public void Apply()
    {
        
        if (Toggle.isOn)
        {
            
            SceneManagerHistory.Instance.GoBackToPreviousScene();

        }
        else
        {
            
            SceneManagerHistory.Instance.GoBackToPreviousScene();
        }
        
    }
}
