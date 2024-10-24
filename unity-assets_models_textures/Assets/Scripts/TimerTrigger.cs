using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    public Timer timerScript;

    // Start is called before the first frame update
    


    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
        {
           
            if (timerScript != null)
            {
                timerScript.enabled = true;
                Debug.Log("Timer started!");
            }
        }
    }
}
