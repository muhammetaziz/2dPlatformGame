using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgrounMovement : MonoBehaviour
{
    // Start is called before the first frame update
    // Kayma h�z�
    public float scrollSpeed = 1.5f;

    // Arka plan�n ba�lang�� konumu 

    void Start()
    {
        
    }

    void Update()
    {
       
        
        transform.Translate(Vector2.left*scrollSpeed*Time.deltaTime);
        //// Zamanla orant�l� olarak x pozisyonunu azalt
        //float newPos = Mathf.Repeat(Time.time * scrollSpeed, 20f);
        //transform.position = startPos + Vector2.left * newPos;
    }
} 
