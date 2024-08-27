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
    public Animator animator; // Animator bileþeni
    public bool grounded = true;
    public float moveSpeed;
    public float jumpForce = 10f; // Zýplama kuvveti
    private float moveDirection; // Hareket yönü

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CapsuleCollider2D>();
        rd = GetComponent<Renderer>();
        animator = gameObject.GetComponent<Animator>(); // Animator bileþenini bul
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
            animator.SetBool("IsJumping", false); // Zýplama animasyonunu durdur
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
        moveDirection = 0f; // Hareket yönünü sýfýrla

        if (Input.GetMouseButtonDown(0))
        {
            // Animator'daki tetikleyiciyi ayarla
            animator.SetTrigger("NormalAttack"); 
        }

        if (Input.GetKey("d"))
        {
            moveDirection = 1f; // Sað hareket
        }
        else if (Input.GetKey("a"))
        {
            moveDirection = -1f; // Sol hareket
        }

        // Rigidbody'nin velocity özelliðini kullanarak hareket et
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);

        //// Koþma animasyonu için
        //if (moveDirection != 0)
        //{
        //    animator.SetBool("Run", true);
        //}
        //else
        //{
        //    animator.SetBool("Run", false);
        //}

        // Zýplama
        if (Input.GetKey("w") && grounded == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            grounded = false;
            //animator.SetBool("IsJumping", true); // Zýplama animasyonunu baþlat
        }
    }
}
