using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinTrigger : MonoBehaviour
{
    public GameObject player;
    private Timer Timer;
    public TextMeshProUGUI text;
    public TextMeshProUGUI Win;
    // Start is called before the first frame update
    void Start()
    {
        Timer = player.GetComponent<Timer>();
;   }


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {

            if (Timer != null)
            {
                Timer.enabled = false;
                text.color = Color.green;
                string time = text.text;

            }
        }
    }
}
