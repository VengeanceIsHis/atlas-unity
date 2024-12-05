using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public GameObject player;
    public Camera MainCamera;
    private PlayerController PlayerController;
    public Canvas TimerCanvas;
    public Camera CutSceneCamera;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        PlayerController = player.GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
        TimerCanvas.gameObject.SetActive(false);

        // Play an animation using a Trigger (defined in the Animator Controller)
        animator.speed = .1f;

        
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("Intro01") && stateInfo.normalizedTime >= 1.0f)
        {
            CutSceneCamera.gameObject.SetActive(false);
            MainCamera.transform.position = CutSceneCamera.transform.position;
            MainCamera.transform.rotation = CutSceneCamera.transform.rotation;
            MainCamera.gameObject.SetActive(true);
            TimerCanvas.gameObject.SetActive(true);
        }
    }

}
