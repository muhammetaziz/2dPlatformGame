using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
     
    Rigidbody2D rb;
    public float pipeSpeed;
    void Start()
    { 
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.left * pipeSpeed; 
    }
}
