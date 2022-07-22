using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public float jumpForce;
    private bool isGrounded;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;
    private bool canDoubleJump;
    private Animator anim;
    private SpriteRenderer sr;
    public float knockBackLength, knockBackForce;
    private float knockBackCounter;
    public static PlayerController instance;
    public float bounceForce;
    public bool stopInput;

    private void Awake(){
        instance = this;
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        if(!PauseMenu.instance.isPaused && !stopInput)
        {
        if(knockBackCounter <=0){
        rb.velocity = new Vector2(moveSpeed * Input.GetAxisRaw("Horizontal"), rb.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);
        
        if(isGrounded){
    canDoubleJump = true;
    }

        if(Input.GetButtonDown("Jump")){
            if(isGrounded){
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        AudioManager.instance.PlaySFX(7);
            }

            else{
        if(canDoubleJump){
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        canDoubleJump = false;
        AudioManager.instance.PlaySFX(7);
        }
        }
        }

        if(rb.velocity.x < 0){
    sr.flipX = true;}

    else if(rb.velocity.x > 0){
    sr.flipX = false;
    }
    }else{
            knockBackCounter -= Time.deltaTime;
            if(!sr.flipX){
        rb.velocity = new Vector2(-knockBackForce, rb.velocity.y);
            } else {
        rb.velocity = new Vector2(knockBackForce, rb.velocity.y);
    }
    }
    }
    anim.SetBool("isGrounded", isGrounded);
    anim.SetFloat("moveSpeed", Mathf.Abs(rb.velocity.x));
}

public void KnockBack(){
    knockBackCounter = knockBackLength;
    rb.velocity = new Vector2(0f, knockBackForce);

    anim.SetTrigger("hurt");
}

public void Bounce(){
    rb.velocity = new Vector2(rb.velocity.x, bounceForce);
    AudioManager.instance.PlaySFX(7);
}
}

