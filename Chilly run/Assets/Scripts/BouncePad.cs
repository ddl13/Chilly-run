using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    private Animator anim;
    public float bounceForce;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            PlayerController.instance.rb.velocity = new Vector2(PlayerController.instance.rb.velocity.x, bounceForce);
            anim.SetTrigger("bounce");
        }
    }
}
