using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public static Pickup instance;

    
    public bool isCoin, isHeal;
    private bool isCollected;

    private void Awake(){
        instance = this;
    }
    
    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player") && !isCollected){
            if(isCoin){
                LevelManager.instance.coinsCollected++;

                isCollected = true;
                //gameObject.SetActive(false);
                Destroy(gameObject);
                

                UIController.instance.UpdateCoinCount();

                AudioManager.instance.PlaySFX(3);
            }

            if(isHeal){
                if(PlayerHealthController.instance.currentHealth != PlayerHealthController.instance.maxHealth){
                    PlayerHealthController.instance.HealPlayer();

                    isCollected = true;
                    //gameObject.SetActive(false);
                    Destroy(gameObject);

                    AudioManager.instance.PlaySFX(10);
                }
            }
        }
    }
}
