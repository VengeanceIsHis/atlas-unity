using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    public GameObject player;
    private Timer Timer;

    // Start is called before the first frame update
    void Start()
    {
        Timer = player.GetComponent<Timer>();
    }


    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
        {
           
            if (Timer != null)
            {
                Timer.enabled = true;
                Debug.Log("Timer started!");
            }
        }
    }
}
