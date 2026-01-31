using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 playerDirection;
    public float speed;
    public float jumpForce;

    public Rigidbody rb;
    public LayerMask groundMask;
    public Transform cameraPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked; //if player presses screen, locks mouse onto center screen
        Cursor.visible = false; //mouse visibility while locked is false
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        playerDirection = new Vector3(x, 0, y);
        transform.Translate(playerDirection * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        
    }
    bool IsGrounded() //detect terrain collision
    {
        if (Physics.Raycast(transform.position - new Vector3(0, .9f, 0), //0.9 is the height (our player height) for raycast
            Vector3.down, out RaycastHit hit, .2f, groundMask)) //0.2 is our raycast length
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
