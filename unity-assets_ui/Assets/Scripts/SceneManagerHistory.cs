using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SceneManagerHistory : MonoBehaviour
{
    public GameObject Manager;
    // Singleton instance
    public static SceneManagerHistory Instance;

    // Stack to track the scene history
    private Stack<string> sceneHistory = new Stack<string>();

    void Awake()
    {
        // Ensure only one instance of SceneManagerHistory exists
        if (Instance == null)
        {
            Instance = this; // Assign this as the singleton instance
            DontDestroyOnLoad(Manager); // Keep it across scene transitions
        }
        else
        {
            Destroy(Manager); // Destroy duplicate instances
        }
    }

    void Start()
    {
        // Add the current scene to the history
        sceneHistory.Push(SceneManager.GetActiveScene().name);
    }

    public void LoadScene(string sceneName)
    {
        // Add the current scene to the history before loading a new one
        string currentScene = SceneManager.GetActiveScene().name;
        sceneHistory.Push(currentScene);

        // Load the new scene
        SceneManager.LoadScene(sceneName);
    }

    public void GoBackToPreviousScene()
    {
        if (sceneHistory.Count > 1)  // Ensure there's a previous scene
        {
            // Pop the current scene off the stack
            sceneHistory.Pop();

            // Get the previous scene and load it
            string previousScene = sceneHistory.Peek();
            SceneManager.LoadScene(previousScene);
        }
        else
        {
            Debug.LogWarning("No previous scene to go back to.");
        }
    }
}