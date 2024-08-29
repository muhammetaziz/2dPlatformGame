using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
     
    Rigidbody2D rb;
    public float pipeSpeed;
    public Collider2D col;
    void Start()
    { 
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.left * pipeSpeed; 
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "DestroyPipe")
        {
            Destroy(gameObject);
            Debug.Log("trigger");
        }
    }
}
