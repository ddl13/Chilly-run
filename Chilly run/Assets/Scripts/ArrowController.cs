using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        Destroy(gameObject, 4f);
        transform.Rotate(0, 0, 180);
    }

    
    

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Ground")
        Destroy(gameObject);
    }
}
