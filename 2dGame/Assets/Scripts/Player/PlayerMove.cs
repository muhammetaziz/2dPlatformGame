using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    public int PlayerCoin;
    public TextMeshProUGUI cointext;

    public Rigidbody2D rb;
    public CapsuleCollider2D col;
    private Renderer rd;
    private bool grounded;
    Explode explode;
    public float moveSpeed;

    private void Awake()
    {
        explode = GetComponent<Explode>();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CapsuleCollider2D>();
        rd = GetComponent<Renderer>();
    }

    private void Update()
    {
        PlayerMovement();
        if (Input.GetKey(KeyCode.Space))
        {

            transform.localScale = new Vector2(2, 2);
            transform.position = new Vector2(0, 0);
            rd.material.color = Color.black;

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "engel")
        {
            PlayerCoin++;
            Destroy(other.gameObject);
            cointext.text = "Puan: " + PlayerCoin;
        }
        if (other.gameObject.tag == "graund")
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }
    private void PlayerMovement()
    {
        if (Input.GetKey("d"))
        {
            rb.AddForce(Vector2.right * moveSpeed);

        }
        else if (Input.GetKey("a"))
        {
            rb.AddForce(Vector2.left * moveSpeed);
        }
        else if (Input.GetKey("w"))
        {
            if (grounded == false)
            {
                rb.AddForce(Vector2.up * moveSpeed);
            }
        }



    }

}
