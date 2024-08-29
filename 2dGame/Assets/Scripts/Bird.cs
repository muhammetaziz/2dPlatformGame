using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float jumpForce;
    public Rigidbody2D rb;
    public PolygonCollider2D col;
    private int puan;
    public TextMeshProUGUI text;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<PolygonCollider2D>();
    }

    void Update()
    {


        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "FlappyPoint")
        {
            Debug.Log("carpýldý");
            puan++;
            text.text =puan.ToString();
        }
        if (other.gameObject.tag == "engel")
        {
            Destroy(gameObject);
        }
    }
}
