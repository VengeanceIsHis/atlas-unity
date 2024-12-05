using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public Animator animator;
    private bool grounded;
    private Rigidbody rb;
    private float speed = 5f;
    private float sprint = 40f;
    [SerializeField] Transform cam;
    public Scene currentscene;
    private bool IsRunning;
    public float rotationSpeed = 700f;

    // Start is called before the first frame update
    void Start()
    {
        IsRunning = false;
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;

        // Freeze rotation to prevent rolling
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        // WASD input for movement
        float direction_x = Input.GetAxis("Horizontal") * speed;
        float direction_z = Input.GetAxis("Vertical") * speed;

        // Check if the player is running
        IsRunning = Mathf.Abs(direction_x) > 0 || Mathf.Abs(direction_z) > 0;

        // Update animator based on running state
        animator.SetBool("IsRunning", IsRunning);

        // Get camera direction for movement (flattened to ignore y-axis)
        Vector3 camForward = cam.transform.forward;
        Vector3 camRight = cam.transform.right;

        camForward.y = 0f; // Keep movement in the horizontal plane
        camRight.y = 0f;

        // Normalize directions to maintain consistent speed
        camForward.Normalize();
        camRight.Normalize();

        // Calculate movement direction based on camera orientation and WASD input
        Vector3 moveDir = (direction_x * camRight + direction_z * camForward).normalized;

        // Apply sprinting speed if LeftShift is held
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.velocity = new Vector3(moveDir.x * sprint, rb.velocity.y, moveDir.z * sprint);
        }
        else
        {
            rb.velocity = new Vector3(moveDir.x * speed, rb.velocity.y, moveDir.z * speed);
        }

        // Handle rotation to face the movement direction
        if (moveDir.magnitude > 0f) // Check if there is movement input
        {
            // Calculate target angle based on movement direction relative to the camera's orientation
            float targetAngle = Mathf.Atan2(moveDir.x, moveDir.z) * Mathf.Rad2Deg;

            // Smoothly rotate the player towards the target direction
            Quaternion targetRotation = Quaternion.Euler(0f, targetAngle, 0f);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // Check for grounded status
        grounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);

        // Handle jump logic (make sure the player is grounded)
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            float jumpForce = Mathf.Sqrt(-64f * Physics.gravity.y);
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }

        // Check for level transitions or reset position based on scene name
        switch (SceneManager.GetActiveScene().name)
        {
            case "Level01":
                if (rb.position.y < -5f)
                {
                    transform.position = new Vector3(0, 100, 0);
                }
                break;
            case "Level02":
                if (rb.position.y < -5f)
                {
                    transform.position = new Vector3(0, 100, 0);
                }
                break;
            case "Level03":
                if (rb.position.y < -100f)
                {
                    transform.position = new Vector3(0, 100, 0);
                }
                break;
            default:
                break;
        }
    }

}
