using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompBox : MonoBehaviour
{
    public GameObject deathEnemyEffect;
    public GameObject collectible;
    [Range(0, 100)]public float chanceToDrop;

    private void OnTriggerEnter2D(Collider2D other){
         
        if(other.CompareTag("Enemy")){

            other.transform.parent.gameObject.SetActive(false);

            Instantiate(deathEnemyEffect, other.transform.position, other.transform.rotation);

            PlayerController.instance.Bounce();

            float dropSelect = Random.Range(0, 100f);

            if(dropSelect <= chanceToDrop){
                Instantiate(collectible, other.transform.position, other.transform.rotation);
            }

            AudioManager.instance.PlaySFX(5);
        }

    } 
}
