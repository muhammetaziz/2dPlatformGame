using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{ 
    private Rigidbody2D rb; 
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); 
    } 
    void Update()
    { 
        if (Input.GetMouseButtonDown(0))
        { 
            rb.gravityScale *= -1;
        }  
    }
     void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag.Equals("engel"))
        {
            Destroy(collision.gameObject);
        }
    }
}
