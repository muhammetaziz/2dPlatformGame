using System.Threading;
using TMPro;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public int PlayerCoin;
    public TextMeshProUGUI cointext;
    public Rigidbody2D rb;
    public CapsuleCollider2D col;
    private Renderer rd;
    public Animator animator; // Animator bile�eni
    public bool grounded = true;
    public float moveSpeed;
    public float jumpForce = 10f; // Z�plama kuvveti
    private float moveDirection; // Hareket y�n�

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CapsuleCollider2D>();
        rd = GetComponent<Renderer>();
        animator = gameObject.GetComponent<Animator>(); // Animator bile�enini bul
    }

    private void Update()
    {
        PlayerMovement();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "engel")
        {
            PlayerCoin++;
            Destroy(other.gameObject);
            cointext.text = "Puan: " + PlayerCoin;
        }
        if (other.gameObject.tag == "Yer")
        {
            grounded = true;
            animator.SetBool("IsJumping", false); // Z�plama animasyonunu durdur
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Yer")
        {
            grounded = false;
        }
    }

    private void PlayerMovement()
    {
        moveDirection = 0f; // Hareket y�n�n� s�f�rla

        if (Input.GetMouseButtonDown(0))
        {
            // Animator'daki tetikleyiciyi ayarla
            animator.SetTrigger("NormalAttack"); 
        }

        if (Input.GetKey("d"))
        {
            moveDirection = 1f; // Sa� hareket
        }
        else if (Input.GetKey("a"))
        {
            moveDirection = -1f; // Sol hareket
        }

        // Rigidbody'nin velocity �zelli�ini kullanarak hareket et
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);

        //// Ko�ma animasyonu i�in
        //if (moveDirection != 0)
        //{
        //    animator.SetBool("Run", true);
        //}
        //else
        //{
        //    animator.SetBool("Run", false);
        //}

        // Z�plama
        if (Input.GetKey("w") && grounded == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            grounded = false;
            //animator.SetBool("IsJumping", true); // Z�plama animasyonunu ba�lat
        }
    }
}
