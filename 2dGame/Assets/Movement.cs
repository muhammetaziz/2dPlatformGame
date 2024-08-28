using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    bool IsGrounded;
    Rigidbody2D rb;
    BoxCollider2D col;
    public float jumpForce;
    Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        animator = gameObject.GetComponent<Animator>();
    }
    private void Update()
    {

        //Kosma
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = Vector3.right * speed;
            transform.eulerAngles = new Vector2(0, 0);
            animator.SetBool("RunBool",true);

        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = Vector3.left * speed;
            transform.eulerAngles = new Vector2(0, 180);
            animator.SetBool("RunBool",true);  
        }
        //Zýplama
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            IsGrounded = false;
        }


    }




}
