using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{

    public Rigidbody2D rb;
    public CapsuleCollider2D col;
    private Renderer rd;

    public float moveSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CapsuleCollider2D>();
        rd = GetComponent<Renderer>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {

            transform.localScale = new Vector2(2, 2);
            transform.position = new Vector2(0, 0);
            rd.material.color=Color.black;
            rb.
        }

        if (Input.GetKey("w"))
        {
            rb.AddForce(Vector2.right * moveSpeed);
            Debug.Log("w");
        }

        if (Input.GetKey("s"))
        {
            rb.AddForce(Vector2.left * moveSpeed);
            Debug.Log("s");
        }
    }
}
