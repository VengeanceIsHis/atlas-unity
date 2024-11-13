using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public Canvas WinCanvas;
    public TextMeshProUGUI WinText;
    public TextMeshProUGUI TimerText;
    private float timer;
    private string Format;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        string formtime = FormatTime(timer);

        TimerText.text = formtime;
        Format = formtime;
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        float seconds = time % 60;

        return string.Format("{0}:{1:00}.{2:00}", minutes, Mathf.Floor(seconds), (seconds - Mathf.Floor(seconds)) * 100);
    }

    public void Win()
    {
        string newtime = Format;
        TimerText.enabled = false;
        WinCanvas.gameObject.SetActive(true);
        WinText.text = newtime;

        Cursor.lockState = CursorLockMode.None;  // Unlock the cursor
        Cursor.visible = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Flag"))
        {
            Win();
        }
    }
}
