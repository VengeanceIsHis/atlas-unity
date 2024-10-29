using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinTrigger : MonoBehaviour
{
    public Timer timerScript;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {

            if (timerScript != null)
            {
                timerScript.enabled = false;
                text.color = Color.green;
            }
        }
    }
}
