using UnityEngine;

public class GameManager : MonoBehaviour
{
    // The singleton instance
    private static GameManager instance;

    // The global variable you want to access in all scenes
    public bool Inverted = false;

    // Public property to access the singleton instance
    public static GameManager Instance
    {
        get
        {
            // If the instance does not exist, find it or create one
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("GameManager");
                    instance = obj.AddComponent<GameManager>();
                }

                DontDestroyOnLoad(instance.gameObject); // Ensure it persists across scenes
            }
            return instance;
        }
    }

}