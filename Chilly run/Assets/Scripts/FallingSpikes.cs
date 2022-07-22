using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSpikes : MonoBehaviour
{
   Rigidbody2D rb;
   BoxCollider2D box;
   public float distance;
   bool isFalling = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
    }

    
    private void Update()
    {
        Physics2D.queriesStartInColliders = false;
        if(isFalling == false){
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distance);

            Debug.DrawRay(transform.position, Vector2.down * distance, Color.red);

            if(hit.transform != null){
                if(hit.transform.tag == "Player"){
                    rb.gravityScale = 11;
                    isFalling = true;
                }    
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other){
    if(other.tag == "Player"){
        Destroy(gameObject);
        //gameObject.SetActive(false);
        } 
        else{
            rb.gravityScale = 0;
            box.enabled = false;
        }

    }
}