using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private static CameraController instance;
    public bool isInverted = false;
    
    private float mouseSensitivity = 3f;
    private float rotationY;
    private float rotationX;

    [SerializeField]
    private Transform Target;

    [SerializeField]
    private float distance = 6.0f;

    private Vector3 currentRotation;
    private Vector3 velocity = Vector3.zero;
    
    [SerializeField]
    private float smooth = 0.2f;


    private void Awake()
    {
        // Ensures there's only one instance of the CameraController
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
        else
        {
            instance = this;
            // Persist across scenes
        }
    }


    public void ToggleInversion(bool value)
    {
        isInverted = value;
    }

    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
        
    }
    // Update is called once per frame
    void Update()
    {


        float MouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float MouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        rotationY += MouseX;
    

        if (isInverted == true)
        {
            rotationX += MouseY;
        }
        else
        {
            rotationX -= MouseY;
        }
        




        rotationX = Mathf.Clamp(rotationX, -40, 40);

        Vector3 nextRotation = new Vector3(rotationX, rotationY);
        currentRotation = Vector3.SmoothDamp(currentRotation, nextRotation, ref velocity, smooth);

        transform.localEulerAngles = currentRotation;

        if (Target != null)
        {
            transform.position = Target.position - transform.forward * distance;
        }
    }

    // Public property to access the instance
    public static CameraController Instance
    {
        get
        {
            // If the instance hasn't been created yet, try to find it in the scene
            if (instance == null)
            {
                instance = FindObjectOfType<CameraController>();
                
         
            }
            return instance;
        }
    }
}
