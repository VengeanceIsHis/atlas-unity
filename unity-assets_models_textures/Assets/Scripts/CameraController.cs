using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
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
        rotationX -= MouseY;

        rotationX = Mathf.Clamp(rotationX, -40, 40);

        Vector3 nextRotation = new Vector3(rotationX, rotationY);
        currentRotation = Vector3.SmoothDamp(currentRotation, nextRotation, ref velocity, smooth);

        transform.localEulerAngles = currentRotation;

        transform.position = Target.position - transform.forward * distance;
    }
}
