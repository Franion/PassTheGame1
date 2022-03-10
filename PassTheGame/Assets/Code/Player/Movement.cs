using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform playerTransform;
    public Rigidbody2D rb2d;
    public float speed;
    public float jumpPower;
    public Animator playerAnimator;
    public GroundChecker groundChecker;

    private bool isRot;

    private void Start()
    {
        isRot = false;
    }

    private void Update()
    {
        playerAnimator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));

        if (Input.GetAxis("Horizontal") > 0.01)
        {
            playerTransform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (Input.GetAxis("Horizontal") < -0.01)
        {
            playerTransform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && groundChecker.IsGrounded)
        {
            Vector2 jumpForce = Vector2.up * jumpPower;
            rb2d.AddForce(jumpForce, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        float movX = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(movX * speed, rb2d.velocity.y);
    }
}