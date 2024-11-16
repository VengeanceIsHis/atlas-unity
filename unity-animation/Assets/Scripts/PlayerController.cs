using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    private bool grounded;
    private Rigidbody rb;
    private float speed = 5f;
    private float sprint = 40f;
    [SerializeField] Transform cam;
    public Scene currentscene;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

    // Update is called once per frame
    void Update()
    {
        // WASD buttons enabled
        float direction_x = Input.GetAxis("Horizontal") * speed;
        float direction_z = Input.GetAxis("Vertical") * speed;

        //camera dir
        Vector3 camForward = cam.forward;
        Vector3 camRight = cam.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward.Normalize();
        camRight.Normalize();

        Vector3 moveDir = (direction_x * camRight + direction_z * camForward).normalized;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.velocity = new Vector3(moveDir.x * sprint, rb.velocity.y, moveDir.z * sprint);
        }
        else
        {
            rb.velocity = new Vector3(moveDir.x, rb.velocity.y, moveDir.z);
        }

        grounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            float jumpforce = Mathf.Sqrt(-64f * Physics.gravity.y);
            rb.velocity = new Vector3(rb.velocity.x, jumpforce, rb.velocity.z);
        }



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
