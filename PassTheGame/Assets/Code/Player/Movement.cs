using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform playerTransform;
    public Rigidbody2D rb2d;
    public float speed;
    public Animator playerAnimator;

    bool isRot;
    void Start()
    {
        isRot = false;
    }

    void Update() 
    {
        playerAnimator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));

        if(Input.GetAxis("Horizontal") < 0.1)
        {
            playerTransform.rotation = Quaternion.Euler(0, 0, 0);
        }else if(Input.GetAxis("Horizontal") > -0.1)
        {
            playerTransform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    void FixedUpdate()
    {
        float movX = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(movX, 0) * speed;
    }
}
