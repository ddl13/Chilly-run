using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public byte currentHealth, maxHealth;
    public static PlayerHealthController instance;
    public float invincibleLength;
    private float invincibleCounter;
    private SpriteRenderer theSR;
    public GameObject deathEffect;

    private void Awake(){
        instance = this;
    }
    void Start()
    {
        currentHealth = maxHealth;
        theSR = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        if(invincibleCounter > 0){
            invincibleCounter -= Time.deltaTime;

            if(invincibleCounter <=0){
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 1f);
            }
        }
    }

    public void DealDamage(){
        if(invincibleCounter <=0){
        currentHealth -=1;

        if(currentHealth <=0){

            currentHealth = 0;

            Instantiate(deathEffect, transform.position, transform.rotation);

            LevelManager.instance.RespawnPlayer();

            
        } else{
                invincibleCounter = invincibleLength;
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, .5f);

                PlayerController.instance.KnockBack();

                AudioManager.instance.PlaySFX(12);
        }

        UIController.instance.UpdateHealthDisplay();
        }
    }

    public void HealPlayer(){
        currentHealth ++;
        if(currentHealth > maxHealth)
        currentHealth = maxHealth;
 
        UIController.instance.UpdateHealthDisplay();
    }
    
    public void DestroyPlayer(){
        Instantiate(deathEffect, transform.position, transform.rotation);
        currentHealth = 0;
 
        UIController.instance.UpdateHealthDisplay();
        LevelManager.instance.RespawnPlayer();

        
    }

}
